using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deloitte.Towers.Parking.Infrastructure.Exceptions;

namespace Deloitte.Towers.Parking.Infrastructure.Extensions
{
    public static class SqlExceptionExtensions
    {
        public static Exception ToBusinessException(this SqlException sqlException)
        {
            if (sqlException == null)
            {
                return null;
            }

            Exception exeption;

            var isSqlExceptionDefined = Enum.IsDefined(typeof(SqlExceptionCode), sqlException.Number);
            if (isSqlExceptionDefined)
            {
                var businessExeption = SqlExceptionMapper.TryExtractBusinessException((SqlExceptionCode)sqlException.Number);
                businessExeption.FullMessage = $"SqlException.Message: {sqlException.Message}, SqlException.StackTrace: {sqlException.StackTrace}";
                exeption = businessExeption;
            }
            else
            {
                exeption = sqlException;
            }

            return exeption;
        }
    }
}
