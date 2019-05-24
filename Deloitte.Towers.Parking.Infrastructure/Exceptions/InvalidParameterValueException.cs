using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Exceptions
{
    public class InvalidParameterValueException : BusinessException
    {
        private const BusinessExceptionCode InternalExceptionCode = BusinessExceptionCode.InvalidParameterValue;

        public InvalidParameterValueException() : base(InternalExceptionCode)
        {
        }

        public InvalidParameterValueException(string message) : base(InternalExceptionCode, message)
        {
        }
    }
}
