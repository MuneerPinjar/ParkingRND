using Deloitte.Towers.Parking.Domain.Dto.Web.Building;
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
    public class BuildingEditDtoRowMapper : IRowMapper<BuildingLevelEditDto>
    {
        public BuildingLevelEditDto Map(IDataReader reader)
        {
            if (reader.IsNull())
                return null;

            var dto = new BuildingLevelEditDto
            {
                CampusId = reader.GetValue<int>("CampusId"),
                LevelName  = "Level B"+ reader.GetString("Level"),
                LevelId = reader.GetValue<int>("LevelId"),
                CarAreaId = reader.GetValue<int>("CarAreaId"),
                BikeAreaId = reader.GetValue<int>("BikeAreaId"),
                Level = reader.GetString("Level"),
                CampusName = reader.GetString("CampusName"),
                CarParkings = reader.GetValue<int>("CarParkings"),
                BikeParkings = reader.GetValue<int>("BikeParkings"),
                IsActive = reader.GetValue<bool>("IsActive"),
                ReservedCarParkings = reader.GetValue<int>("ReservedCarParkings"),
                ReservedBikeParkings = reader.GetValue<int>("ReservedBikeParkings"),
                AvailableCarParkings = reader.GetValue<int>("AvailableCarParkings"),
                AvailableBikeParkings = reader.GetValue<int>("AvailableBikeParkings"),
            };

            return dto;
        }
    }
}
