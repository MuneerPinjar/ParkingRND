using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Exceptions
{
    public class LevelAlreadyExistsException : BusinessException
    {
        private const BusinessExceptionCode InternalExceptionCode = BusinessExceptionCode.LevelAlreadyExists;

        public LevelAlreadyExistsException() : base(InternalExceptionCode)
        {
        }

        public LevelAlreadyExistsException(string message) : base(InternalExceptionCode, message)
        {
        }
    }
}
