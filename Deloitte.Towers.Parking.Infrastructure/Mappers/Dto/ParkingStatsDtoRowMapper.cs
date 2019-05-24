using Deloitte.Towers.Parking.Domain.Dto.Mobile;
using Deloitte.Towers.Parking.Domain.Model.Enums;
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
    public class ParkingStatsDtoRowMapper : IRowMapper<ParkingStatsDto>
    {
        public ParkingStatsDto Map(IDataReader reader)
        {
            if (reader.IsNull())
                return null;

            var dto = new ParkingStatsDto
            {
                AvailablePlaces = reader.GetValue<int>("PlacesFree"),
                AvailablePercent = reader.GetValue<decimal>("Percent"),
                Time = reader.GetValue<DateTime>("Date"),
                VehicleType = reader.GetValue<int>("VehicleType"),
                ParkingId = reader.GetValue<int>("ParkingId")
            };

            return dto;
        }
    }
}
