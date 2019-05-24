using Deloitte.Towers.Parking.Domain.Entities;
using Deloitte.Towers.Parking.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Extensions
{
    public static class ExceptionExtensions
    {
        public static ResponseError ToResponseError(this BusinessException businessException)
        {
            if (businessException == null)
            {
                return null;
            }

            var responseError = new ResponseError
            {
                Code = (int)businessException.ExceptionCode,
                Message = businessException.Message,
                FullMessage = businessException.FullMessage,
                Detail = businessException.ExceptionData
            };

            return responseError;
        }
    }
}
