using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Exceptions
{
    public class DependentEntitiesNotExistException : BusinessException
    {
        private const BusinessExceptionCode InternalExceptionCode = BusinessExceptionCode.DependentEntitiesNotExist;

        public DependentEntitiesNotExistException() : base(InternalExceptionCode)
        {
        }

        public DependentEntitiesNotExistException(string message) : base(InternalExceptionCode, message)
        {
        }
    }
}
