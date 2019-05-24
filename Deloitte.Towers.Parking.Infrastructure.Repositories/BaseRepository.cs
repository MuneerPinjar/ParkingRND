using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Deloitte.Towers.Parking.Infrastructure.Repositories.Helpers;
using Deloitte.Towers.Parking.Infrastructure.Extensions;
using Deloitte.Towers.Parking.Infrastructure.Mappers.Common;

namespace Deloitte.Towers.Parking.Infrastructure.Repositories
{
    public class BaseRepository
    {
        private const string DbSchema = "dbo";
        protected readonly string ConnectionString;
        protected readonly DbProviderFactory DbProviderFactory;

        #region constructors

        protected BaseRepository() : this(ConnectionStringHelper.ConnectionStringName)
        {
        }

        protected BaseRepository(string connectionStringName)
        {
            ConnectionString = ConnectionStringHelper.GetConnectionString(connectionStringName);
            var providerName = ConnectionStringHelper.GetDbProviderName(connectionStringName);
            DbProviderFactory = DbProviderFactories.GetFactory(providerName);
        }

        #endregion

        #region private methods

        private void AddDbParametersToDbCommand(DbCommand command, Dictionary<string, object> parameters)
        {
            if (parameters.IsNullOrEmpty())
                return;

            foreach (var dbParameter in parameters.Select(
                parameter => CreateDbParameter(command, parameter.Key, parameter.Value)))
                command.Parameters.Add(dbParameter);
        }

        private DbParameter CreateDbParameter(DbCommand command, string parameterName, object parameterValue)
        {
            var parameter = command.CreateParameter();

            parameter.ParameterName = parameterName;
            if (parameterValue == null)
            {
                parameter.Value = DBNull.Value;
                parameter.IsNullable = true;
            }
            else
            {
                parameter.Value = parameterValue;
            }

            return parameter;
        }

        private string GenerateFnCommandText(string functionName, Dictionary<string, object> parameters)
        {
            functionName = CheckAndPrepareDbObjectName(functionName);

            var strParameters = parameters.IsNullOrEmpty()
                ? string.Empty
                : string.Join(",", parameters.Select(p => p.Key));

            return $"SELECT {functionName}({strParameters})";
        }

        private string CheckAndPrepareDbObjectName(string dataBaseObjectName)
        {
            if (string.IsNullOrEmpty(dataBaseObjectName))
                throw new ArgumentException("dataBaseObjectName");

            if (!dataBaseObjectName.TrimStart().ToLower().StartsWith(DbSchema))
                dataBaseObjectName = $"{DbSchema}.{dataBaseObjectName}";

            return dataBaseObjectName;
        }

        private void OpenDbConnection(DbConnection connection)
        {
            connection.ConnectionString = ConnectionString;
            connection.Open();
        }

        protected async Task OpenDbConnectionAsync(DbConnection connection)
        {
            connection.ConnectionString = ConnectionString;
            await connection.OpenAsync();
        }

        private DbCommand OpenDbConnectionAndCreateDbCommand(DbConnection connection, string commandText,
            Dictionary<string, object> parameters, CommandType commandType = CommandType.Text)
        {
            OpenDbConnection(connection);
            var command = CreateAndPrepareDbCommand(connection, commandText, parameters, commandType);
            return command;
        }

        private async Task<DbCommand> OpenDbConnectionAndCreateDbCommandAsync(DbConnection connection,
            string commandText, Dictionary<string, object> parameters, CommandType commandType = CommandType.Text)
        {
            await OpenDbConnectionAsync(connection);
            var command = CreateAndPrepareDbCommand(connection, commandText, parameters, commandType);
            return command;
        }

        [SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        private DbCommand CreateDbCommand(DbConnection connection, string commandText, CommandType commandType)
        {
            var command = connection.CreateCommand();
            command.CommandText = commandText;
            command.CommandType = commandType;
            return command;
        }

        private DbCommand CreateAndPrepareDbCommand(DbConnection connection, string commandText,
            Dictionary<string, object> parameters, CommandType commandType, SqlTransaction transaction = null, int? timeout = null)
        {
            var command = CreateDbCommand(connection, commandText, commandType);
            AddDbParametersToDbCommand(command, parameters);
            if (transaction != null)
                command.Transaction = transaction;
            if (timeout.HasValue)
                command.CommandTimeout = timeout.Value;

            return command;
        }

        private TResult ExecuteDbCommand<TResult>(Func<TResult> execDbCommand)
        {
            try
            {
                var result = execDbCommand();
                return result;
            }
            catch (SqlException ex)
            {
                throw ex.ToBusinessException();
            }
        }

        private async Task<TResult> ExecuteDbCommandAsync<TResult>(Func<Task<TResult>> execDbCommand)
        {
            try
            {
                var result = await execDbCommand();
                return result;
            }
            catch (SqlException ex)
            {
                throw ex.ToBusinessException();
            }
        }

        #endregion

        #region protected methods

        /// <exception cref="ArgumentNullException"><paramref name="mapper" /> is <see langword="null" />.</exception>
        protected TResult ExecuteReader<TResult>(string storedProcName, IMapper<TResult> mapper,
            Dictionary<string, object> parameters = null) where TResult : class, new()
        {
            if (mapper == null)
                throw new ArgumentNullException(nameof(mapper));

            storedProcName = CheckAndPrepareDbObjectName(storedProcName);

            using (var connection = DbProviderFactory.CreateConnection())
            {
                var command = OpenDbConnectionAndCreateDbCommand(connection, storedProcName, parameters,
                    CommandType.StoredProcedure);

                var result = ExecuteDbCommand(() =>
                {
                    using (var reader = command.ExecuteReader())
                    {
                        return mapper.MapAsync(reader).Result;
                    }
                });
                return result;
            }
        }

        /// <exception cref="ArgumentNullException"><paramref name="mapper" /> is <see langword="null" />.</exception>
        protected async Task<TResult> ExecuteReaderAsync<TResult>(string storedProcName, IMapper<TResult> mapper,
            Dictionary<string, object> parameters = null) where TResult : class, new()
        {
            if (mapper == null)
                throw new ArgumentNullException(nameof(mapper));

            storedProcName = CheckAndPrepareDbObjectName(storedProcName);

            using (var connection = DbProviderFactory.CreateConnection())
            {
                var command = await OpenDbConnectionAndCreateDbCommandAsync(connection, storedProcName, parameters,
                    CommandType.StoredProcedure);
                var result = await ExecuteDbCommandAsync(async () =>
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        return await mapper.MapAsync(reader);
                    }
                });
                return result;
            }
        }

        protected async Task<TResult> ExecuteReaderAsync<TResult>(SqlConnection connection, SqlTransaction transaction, string storedProcName,
            IMapper<TResult> mapper,
            Dictionary<string, object> parameters = null, int? timeout = null) where TResult : class, new()
        {
            if (mapper == null)
                throw new ArgumentNullException(nameof(mapper));

            storedProcName = CheckAndPrepareDbObjectName(storedProcName);

            var command = CreateAndPrepareDbCommand(connection, storedProcName, parameters, CommandType.StoredProcedure, transaction, timeout);

            var result = await ExecuteDbCommandAsync(async () =>
            {
                using (var reader = await command.ExecuteReaderAsync())
                {
                    return await mapper.MapAsync(reader);
                }
            });
            return result;
        }

        protected async Task<int> ExecuteNonQueryAsync(string storedProcName,
            Dictionary<string, object> parameters = null)
        {
            storedProcName = CheckAndPrepareDbObjectName(storedProcName);

            using (var connection = DbProviderFactory.CreateConnection())
            {
                var command = await OpenDbConnectionAndCreateDbCommandAsync(connection, storedProcName, parameters,
                    CommandType.StoredProcedure);

                var result = await ExecuteDbCommandAsync(async () => await command.ExecuteNonQueryAsync());
                return result;
            }
        }

        protected async Task<int> ExecuteNonQueryAsync(SqlConnection connection, SqlTransaction transaction,
            string storedProcName, Dictionary<string, object> parameters = null, int? timeout = null)
        {
            storedProcName = CheckAndPrepareDbObjectName(storedProcName);

            var command = CreateAndPrepareDbCommand(connection, storedProcName, parameters, CommandType.StoredProcedure, transaction, timeout);

            var result = await ExecuteDbCommandAsync(async () => await command.ExecuteNonQueryAsync());
            return result;
        }

        protected async Task<TResult> ExecuteScalarAsync<TResult>(string storedProcName,
            Dictionary<string, object> parameters = null)
        {
            storedProcName = CheckAndPrepareDbObjectName(storedProcName);

            using (var connection = DbProviderFactory.CreateConnection())
            {
                var command = await OpenDbConnectionAndCreateDbCommandAsync(connection, storedProcName, parameters,
                    CommandType.StoredProcedure);

                var result = await ExecuteDbCommandAsync(async () => await command.ExecuteScalarAsync());
                return (TResult)result;
            }
        }

        protected async Task<TResult> ExecuteFunctionAsync<TResult>(string functionName,
            Dictionary<string, object> parameters = null) where TResult : struct
        {
            var commandText = GenerateFnCommandText(functionName, parameters);

            using (var connection = DbProviderFactory.CreateConnection())
            {
                var command = await OpenDbConnectionAndCreateDbCommandAsync(connection, commandText, parameters);

                var result = await ExecuteDbCommandAsync(async () => await command.ExecuteScalarAsync());
                return (TResult)result;
            }
        }

        #endregion
    }
}

