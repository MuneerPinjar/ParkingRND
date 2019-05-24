using Deloitte.Towers.Parking.Domain.Contracts.Managers;
using Deloitte.Towers.Parking.Domain.Contracts.Repositories;
using Deloitte.Towers.Parking.Domain.Dto.Mobile;
using Deloitte.Towers.Parking.Domain.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Managers
{
    public class ParkingManager : IParkingManager
    {
        private readonly IParkingRepository _parkingRepository;

        public ParkingManager(IParkingRepository parkingRepository)
        {
            _parkingRepository = parkingRepository;
        }

        public async Task<IEnumerable<ParkingInfoDto>> GetCampusParkingssWithDataAsync()
        {

            try
            {
                var result = await _parkingRepository.GetCampusParkingssWithDataAsync();
                return result;
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }

        public async Task<IEnumerable<LevelDto>> GetLevelStatsAllParkingsAsync(VehicleType[] vehicleType)
        {
            try
            {
                var result = await _parkingRepository.GetLevelStatsAllParkingsAsync(vehicleType);
                return result;
            }
            catch (Exception e)
            {

                throw e;
            }
          
        }

        public async Task<IEnumerable<ParkingDto>> GetParkingsForecastAsync(DateTime currentTime, VehicleType[] vehicleType)
        {
            try
            {
                var parkingsStats = await _parkingRepository.GetParkingsForecastAsync(currentTime, vehicleType);
              //  var result = CheckAndPrepareParkingStats(parkingsStats.ToList(), currentTime);
                return parkingsStats;
            }
            catch (Exception e)
            {

                throw e;
            }
          
        }

        //private static IEnumerable<ParkingDto> CheckAndPrepareParkingStats(List<ParkingDto> parkingStats,
        //   DateTime currentTime)
        //{
        //    const int forecastItemsCount = 28;
        //    var result = new List<ParkingDto>();

        //    foreach (var item in parkingStats)
        //    {
        //        var forecast = item.Forecast;
        //       // item.Forecast = FillParkingForecast(forecast.ToList(), currentTime, forecastItemsCount);

        //        result.Add(item);
        //    }

        //    return result;
        //}

    }
}
