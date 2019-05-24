using Deloitte.Towers.Parking.Domain.Dto.Mobile;
using Deloitte.Towers.Parking.Domain.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Domain.Contracts.Repositories
{
    public interface IParkingRepository
    {       
        Task<IEnumerable<ParkingDto>> GetParkingsForecastAsync(DateTime currentTime, VehicleType[] vehicleType);
        Task<IEnumerable<ParkingInfoDto>> GetCampusParkingssWithDataAsync();
        Task<IEnumerable<LevelDto>> GetLevelStatsAllParkingsAsync(VehicleType[] vehicleType);
    }
}
