using Deloitte.Towers.Parking.Domain.Entities;
using Deloitte.Towers.Parking.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Extensions
{
    public static class ResponseErrorExtensions
    {
        public static void FillInnerExceptions(this ResponseError responseError, Exception exception)
        {
            if (responseError == null || exception == null)
                return;

            var lastError = responseError;
            var innerException = exception.InnerException;
            while (innerException != null)
            {
                var innerError = new ResponseError
                {
                    Code = (int)BusinessExceptionCode.Unknown,
                    Message = innerException.Message,
                    FullMessage = innerException.StackTrace
                };

                lastError.InnerError = innerError;

                lastError = innerError;
                innerException = innerException.InnerException;
            }
        }
    }
}
