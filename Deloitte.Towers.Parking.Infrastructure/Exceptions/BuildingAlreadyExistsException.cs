using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Exceptions
{
    public class BuildingAlreadyExistsException : BusinessException
    {
        private const BusinessExceptionCode InternalExceptionCode = BusinessExceptionCode.BuildingAlreadyExists;

        public BuildingAlreadyExistsException() : base(InternalExceptionCode)
        {
        }

        public BuildingAlreadyExistsException(string message) : base(InternalExceptionCode, message)
        {
        }
    }
}
