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
    public class ParkingDtoRowMapper : IRowMapper<ParkingDto>
    {
        public ParkingDto Map(IDataReader reader)
        {
            if (reader.IsNull())
                return null;

            var dto = new ParkingDto
            {
                VehicleType = reader.GetValue<int>("VehicleType"),
                AvailablePlacesNow = reader.GetValue<int>("AvailablePlaces"),
                AvailablePercentNow = reader.GetValue<decimal>("AvailablePercent"),
                ParkingId = reader.GetValue<int>("ParkingId")
            };

            return dto;
        }
    }
}
