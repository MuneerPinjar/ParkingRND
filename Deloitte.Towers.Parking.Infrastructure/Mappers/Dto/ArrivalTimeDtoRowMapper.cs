using Deloitte.Towers.Parking.Domain.Dto.Web.EndUser;
using Deloitte.Towers.Parking.Infrastructure.Extensions;
using Deloitte.Towers.Parking.Infrastructure.Mappers.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Mappers.Dto
{
    public class ArrivalTimeDtoRowMapper : IRowMapper<ArrivalTimeDto>
    {
        public ArrivalTimeDto Map(IDataReader reader)
        {
            if (reader.IsNull())
                return null;

            var dto = new ArrivalTimeDto
            {
                DayOfTheWeek = reader.GetString("DayOfTheWeek"),
                UserEmailId = reader.GetString("UserEmailId"),
                Time = reader.GetValue<TimeSpan>("ArrivalTime").ToString()
            };

            return dto;
        }
    }
}
