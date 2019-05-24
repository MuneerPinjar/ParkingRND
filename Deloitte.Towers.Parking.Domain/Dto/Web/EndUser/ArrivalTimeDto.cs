using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Domain.Dto.Web.EndUser
{
    public class ArrivalTimeDto
    {
        public string  DayOfTheWeek { get; set; }

        public string UserEmailId { get; set; }
        public string Time { get; set; }
    }
}
