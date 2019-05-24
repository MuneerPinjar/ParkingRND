using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Exceptions
{
    public class EntityDetailsNotFoundException : BusinessException
    {
        private const BusinessExceptionCode InternalExceptionCode = BusinessExceptionCode.EntityDetailsNotFound;

        public EntityDetailsNotFoundException() : base(InternalExceptionCode)
        {
        }

        public EntityDetailsNotFoundException(string message) : base(InternalExceptionCode, message)
        {
        }
    }
}
