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
    public class LevelStatsVehicleDtoRowMapper : IRowMapper<LevelStatsVehicleDto>
    {
        Random random = new Random();
        public LevelStatsVehicleDto Map(IDataReader reader)
        {
            if (reader.IsNull())
                return null;

            var dto = new LevelStatsVehicleDto
            {
                LevelStatsId = random.Next(1000, 7000),
                LevelName = "Level " + reader.GetValue<int>("LevelId"),
                LevelId = reader.GetValue<int>("LevelId"),
                AvailablePlaces = reader.GetValue<int>("AvailablePlaces"),
                OccupiedPlaces = reader.GetValue<int>("OccupiedPlaces"),
                VehicleType = reader.GetEnum<VehicleType>("VehicleType"),
                Rank = reader.GetValue<int>("Rank"),
                ParkingId = reader.GetValue<int>("ParkingId"),
                LevelAvailablePercent = reader.GetValue<decimal>("LevelAvailablePercent")
            };

            return dto;
        }
    }
}
