using Deloitte.Towers.Parking.Domain.Dto.Web.EndUser;
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
   public class UserProfileDtoRowMapper : IRowMapper<UserProfileDto>
    {
        public UserProfileDto Map(IDataReader reader)
        {
            if (reader.IsNull())
                return null;

            var dto = new UserProfileDto
            {
                Email = reader.GetString("EmailId"),
                FirstName = reader.GetString("FirstName"),
                LastName = reader.GetString("LastName"),
                DisplayName = reader.GetString("DisplayName"),
                Vehicledata = reader.GetValue<int>("VehiclePreference").Equals(1) ? "Car" : "Bike",
                LastLoginData = reader.GetValue<DateTime>("LastLogin").ToString("M/dd/yyyy hh:mm:ss"),
                GeoFencingNotification = reader.GetValue<bool>("GeoFencingNotification"),
                ParkingFullNotification = reader.GetValue<bool>("FullParkingNotification"),
                LocationTracking = reader.GetValue<bool>("LocationTracking"),
                IsActive = reader.GetValue<bool>("IsActive"),               
            
            };

            return dto;
        }
    }
}
