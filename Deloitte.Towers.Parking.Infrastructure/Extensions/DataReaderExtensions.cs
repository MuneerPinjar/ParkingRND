using Deloitte.Towers.Parking.Infrastructure.Mappers.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Extensions
{
    public static class DataReaderExtensions
    {
        public static T? GetNullableValue<T>(this IDataReader row, string column) where T : struct
        {
            if (DBNull.Value.Equals(row[column]))
            {
                return null;
            }

            return (T)row[column];
        }

        public static T GetScalar<T>(this IDataReader row, string column) where T : struct
        {
            var value = row.GetNullableValue<T>(column);
            return value ?? default(T);
        }

        public static T GetValue<T>(this IDataReader row, string column)
        {
            if (DBNull.Value.Equals(row[column]))
            {
                throw new ArgumentNullException(column);
            }

            return (T)row[column];
        }

        public static T GetValueIfExistColumn<T>(this IDataReader row, string column)
        {
            var schemaTable = row.GetSchemaTable();
            if (schemaTable != null && schemaTable.Columns.Contains(column))
                return (T)row[column];
            return default(T);
        }

        public static T? GetNullableValueIfExistColumn<T>(this IDataReader row, string column) where T : struct
        {
            bool isColumnExists = false;
            for (int i = 0; i < row.FieldCount; i++)
            {
                if (row.GetName(i) != column) continue;

                isColumnExists = true;
                break;
            }

            if (!isColumnExists) return null;

            return DBNull.Value.Equals(row[column])
                ? (T?)null
                : (T)row[column];
        }

        public static string GetString(this IDataReader row, string column)
        {
            return DBNull.Value.Equals(row[column]) ? null : row[column].ToString();
        }

        public static byte[] GetBytes(this IDataReader row, string column)
        {
            if (DBNull.Value.Equals(row[column]))
            {
                return null;
            }

            return (byte[])row[column];
        }

        public static async Task<T> MapNextResultAsync<T>(this DbDataReader reader, IMapper<T> mapper) where T : class
        {
            if (reader.IsNull() || !await reader.NextResultAsync())
            {
                return default(T);
            }

            var result = await mapper.MapAsync(reader);
            return result;
        }

        public static async Task<T> MapResultAsync<T>(this DbDataReader reader, IMapper<T> mapper) where T : class
        {
            if (reader.IsNull())
            {
                return default(T);
            }

            var result = await mapper.MapAsync(reader);
            return result;
        }

        public static async Task<bool> IsNullOrEmptyAsync(this DbDataReader reader)
        {
            return reader.IsNull() || !await reader.ReadAsync();
        }

        public static async Task<T?> GetNextNullableScalarAsync<T>(this DbDataReader reader, string column) where T : struct
        {
            if (reader.IsNull() || !await reader.NextResultAsync() || !await reader.ReadAsync())
            {
                return null;
            }

            var value = reader.GetNullableValue<T>(column);
            return value;
        }

        public static async Task<T> GetNextScalarAsync<T>(this DbDataReader reader, string column) where T : struct
        {
            var value = await reader.GetNextNullableScalarAsync<T>(column);
            return value ?? default(T);
        }

        public static T GetEnum<T>(this IDataReader reader, string column) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T type must be enum");
            }

            var value = reader.GetScalar<int>(column);
            return (T)Enum.ToObject(typeof(T), value);
        }
    }
}
