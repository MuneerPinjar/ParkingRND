using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Exceptions
{
    public class SurveyQuestionModificationException : BusinessException
    {
        private const BusinessExceptionCode InternalExceptionCode = BusinessExceptionCode.SurveyQuestionModification;

        public SurveyQuestionModificationException() : base(InternalExceptionCode)
        {
        }

        public SurveyQuestionModificationException(string message) : base(InternalExceptionCode, message)
        {
        }
    }
}
