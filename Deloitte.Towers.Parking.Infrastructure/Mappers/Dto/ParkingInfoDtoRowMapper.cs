using Deloitte.Towers.Parking.Domain.Dto.Mobile;
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
    public class ParkingInfoDtoRowMapper : IRowMapper<ParkingInfoDto>
    {
        public ParkingInfoDto Map(IDataReader reader)
        {
            if (reader.IsNull())
                return null;

            var dto = new ParkingInfoDto
            {
                CampusId = reader.GetValue<int>("CampusID"),
                ParkingId = reader.GetValue<int>("ParkId"),
                Name = reader.GetString("Name"),
                Description = reader.GetString("Description"),
                TotalCarSpaces = reader.GetValue<int>("TotalCarSpaces"),
                TotalBikeSpaces = reader.GetValue<int>("TotalBikeSpaces"),
                TotalReservedCarSpaces = reader.GetValue<int>("TotalReservedCarSpaces"),
                TotalReservedBikeSpaces = reader.GetValue<int>("TotalReservedBikeSpaces"),
                //TotalAvailableCarSpaces = reader.GetValue<int>("TotalAvailableCarSpaces")
                //TotalAvailableBikeSpaces = reader.GetValue<int>("TotalAvailableBikeSpaces")
            };

            return dto;
        }
    }
}
