using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Exceptions
{
    public class DependedEntityExistsException : BusinessException
    {
        private const BusinessExceptionCode InternalExceptionCode = BusinessExceptionCode.DependedEntityExists;

        public DependedEntityExistsException() : base(InternalExceptionCode)
        {
        }

        public DependedEntityExistsException(string message) : base(InternalExceptionCode, message)
        {
        }
    }
}
