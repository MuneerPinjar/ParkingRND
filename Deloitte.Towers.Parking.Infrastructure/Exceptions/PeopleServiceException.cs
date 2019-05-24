using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Exceptions
{
    public class PeopleServiceException : BusinessException
    {
        private const BusinessExceptionCode InternalExceptionCode = BusinessExceptionCode.PeopleService;

        public PeopleServiceException() : base(InternalExceptionCode)
        {
        }

        public PeopleServiceException(string message) : base(InternalExceptionCode, message)
        {
        }
    }
}
