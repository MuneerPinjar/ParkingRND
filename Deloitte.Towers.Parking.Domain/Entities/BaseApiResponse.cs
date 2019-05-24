using Deloitte.Towers.Parking.Domain.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Domain.Entities
{
    public class BaseApiResponse<TType>
    {
        public BaseApiResponse()
        {
            Errors = new List<ResponseError>();
        }

        public BaseApiResponse(ResponseStatusCode statusCode, TType data = default(TType), params ResponseError[] errors)
        {
            StatusCode = statusCode;
            Data = data;
            Errors = errors.ToList();
        }

        public ResponseStatusCode StatusCode { get; set; }

        public List<ResponseError> Errors { get; set; }

        public TType Data { get; set; }
    }

    public class BaseApiResponse : BaseApiResponse<object>
    {
        public BaseApiResponse(ResponseStatusCode statusCode, object data = null, params ResponseError[] errors)
            : base(statusCode, data, errors)
        {
        }
    }
}
