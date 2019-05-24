using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Exceptions
{
    public class UnauthorizedException : BusinessException
    {
        private const BusinessExceptionCode InternalExceptionCode = BusinessExceptionCode.Unauthorized;

        public UnauthorizedException() : base(InternalExceptionCode)
        {
        }

        public UnauthorizedException(string message) : base(InternalExceptionCode, message)
        {
        }
    }
}
