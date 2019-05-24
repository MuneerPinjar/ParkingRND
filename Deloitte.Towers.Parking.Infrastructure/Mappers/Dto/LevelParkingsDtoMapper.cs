using Deloitte.Towers.Parking.Domain.Dto.Mobile;
using Deloitte.Towers.Parking.Infrastructure.Extensions;
using Deloitte.Towers.Parking.Infrastructure.Mappers.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Mappers.Dto
{
   public class LevelParkingsDtoMapper : IRowMapper<LevelParkingsDto>
    {
        public LevelParkingsDto Map(IDataReader reader)
        {
            if (reader.IsNull())
                return null;

            var dto = new LevelParkingsDto
            {
                AsOf = reader.GetValue<DateTime>("AsOf"),
                ParkId = reader.GetValue<int>("ParkId"),
                ParkName = reader.GetString("ParkName"),
                LevelAvailable = reader.GetValue<int>("AVAILABLE"),
                LevelOccupied = reader.GetValue<int>("Occupied"),
                TotalPerByBuilding  = reader.GetValue<float>("TotalPercentageBuilding"),                
                LevelId = reader.GetValue<int>("LEVELID"),
                TotalAvailable = reader.GetValue<int>("TotalAvailable")

            };

            return dto;
        }
       
    }
}
