using Deloitte.Towers.Parking.Domain.Contracts.Repositories;
using Deloitte.Towers.Parking.Domain.Dto.Mobile;
using Deloitte.Towers.Parking.Domain.Model.Enums;
using Deloitte.Towers.Parking.Infrastructure.Mappers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Repositories
{
    public class ParkingRepository : BaseRepository, IParkingRepository
    {

        private const string GetParkingsWithDataSpName = "[spCampussWithDataGet]";
        private const string GetLevelStatsAllParkings = "[spLevelStatsAllParkings]";
        private const string GetParkingsForecastSpName = "[spForeCast]";

        public async Task<IEnumerable<LevelDto>> GetLevelStatsAllParkingsAsync(VehicleType[] vehicleType)
        {
            try
            {
                var mapper = new LevelDtoListMapper();


                var result = await ExecuteReaderAsync(GetLevelStatsAllParkings, mapper);


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
                var mapper = new ParkingDtoListMapper();
                string vehicleFilter = null;

                if (vehicleType != null && vehicleType.Length > 0)
                    vehicleFilter = string.Join(",", vehicleType.Cast<int>().ToArray());

                var args = new Dictionary<string, object>
            {
                {"@Time", currentTime}
               
            };
                var result = await ExecuteReaderAsync(GetParkingsForecastSpName, mapper, args);

                return result;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<IEnumerable<ParkingInfoDto>> GetCampusParkingssWithDataAsync()
        {
            try
            {
                var mapper = new ParkingInfoDtoListMapper();
                var result = await ExecuteReaderAsync(GetParkingsWithDataSpName, mapper);

                return result;
            }
            catch (Exception e)
            {

                throw e;
            }

        }

      
    }
}
