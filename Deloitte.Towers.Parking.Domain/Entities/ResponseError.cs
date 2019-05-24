using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Domain.Entities
{
    public class ResponseError
    {
        public int? Code { get; set; }

        public string Message { get; set; }

        public string FullMessage { get; set; }

        public object Detail { get; set; }

        public ResponseError InnerError { get; set; }
    }
}
