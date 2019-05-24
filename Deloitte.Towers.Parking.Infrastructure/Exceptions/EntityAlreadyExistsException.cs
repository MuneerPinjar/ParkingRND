using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Exceptions
{
    public class EntityAlreadyExistsException : BusinessException
    {
        private const BusinessExceptionCode InternalExceptionCode = BusinessExceptionCode.EntityAlreadyExists;

        public EntityAlreadyExistsException() : base(InternalExceptionCode)
        {
        }

        public EntityAlreadyExistsException(string message) : base(InternalExceptionCode, message)
        {
        }
    }
}
