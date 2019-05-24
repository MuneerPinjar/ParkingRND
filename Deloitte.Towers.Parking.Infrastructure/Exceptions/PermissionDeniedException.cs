using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Exceptions
{
    public class PermissionDeniedException : BusinessException
    {
        private const BusinessExceptionCode InternalExceptionCode = BusinessExceptionCode.PermissionDenied;

        public PermissionDeniedException() : base(InternalExceptionCode)
        {
        }

        public PermissionDeniedException(string message) : base(InternalExceptionCode, message)
        {
        }
    }
}
