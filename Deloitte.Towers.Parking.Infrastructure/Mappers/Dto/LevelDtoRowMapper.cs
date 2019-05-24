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
    public class LevelDtoRowMapper : IRowMapper<LevelDto>
    {
        public LevelDto Map(IDataReader reader)
        {
            if (reader.IsNull())
                return null;

            var dto = new LevelDto
            {                
                VehicleType = reader.GetEnum<VehicleType>("VehicleType"),
                AvailablePlaces = reader.GetValue<int>("AvailablePlaces"),
                AvailablePercent = reader.GetValue<decimal>("AvailablePercent"),
                ParkingId = reader.GetValue<int>("ParkingId")
            };

            return dto;
        }
    }
}
