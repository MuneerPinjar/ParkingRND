using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Exceptions
{
    public class SqlUnknownException : BusinessException
    {
        private const BusinessExceptionCode InternalExceptionCode = BusinessExceptionCode.SqlUnknown;

        public SqlUnknownException() : base(InternalExceptionCode)
        {
        }

        public SqlUnknownException(string message) : base(InternalExceptionCode, message)
        {
        }
    }
}
