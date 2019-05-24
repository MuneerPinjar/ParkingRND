using Deloitte.Towers.Parking.Domain.Contracts.Repositories;
using Deloitte.Towers.Parking.Domain.Dto.Web.Building;
using Deloitte.Towers.Parking.Infrastructure.Mappers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Repositories
{
    public class BuildingLevelRepository : BaseRepository, IBuildingLevelRepository
    {
        private const string GetAllSpName = "[SpGetAllBuildingLevel]";
        private const string EditBuildingSpName = "[spBuildinLevelEdit]";
        private const string GetBuildingLevelByIdSpName = "[SpGetBuildingLevelById]";
        public async Task EditBuildingLevelAsync(BuildingLevelEditDto buildingEdit)
        {
            try
            {
                var args = new Dictionary<string, object>
            {
                {"@LevelId", buildingEdit.LevelId},
                {"@CampusId", buildingEdit.CampusId},
                {"@CarAreaId", buildingEdit.CarAreaId},
                {"@BikeAreaId", buildingEdit.BikeAreaId},
                {"@IsActive", buildingEdit.IsActive},
                {"@CarParkings", buildingEdit.CarParkings},
                {"@ReservedCarParkings", buildingEdit.ReservedCarParkings},
                {"@BikeParkings", buildingEdit.BikeParkings},
                {"@ReservedBikeParkings", buildingEdit.ReservedBikeParkings},
                {"@ModifiedBy", buildingEdit.ModifiedBy},
            };

                await ExecuteNonQueryAsync(EditBuildingSpName, args);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<IEnumerable<BuildingLevelEditDto>> GetAllAsync()
        {
            try
            {
                var mapper = new BuildingEditDtoListMapper();


                var result = await ExecuteReaderAsync(GetAllSpName, mapper);
                return result;

            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public async Task<BuildingLevelEditDto> GetBuildingLevelById(BuildingLevelDto buildingEdit)
        {
            try
            {
                var mapper = new BuildingLevelEditDtoMapper();

                var args = new Dictionary<string, object>
            {
                {"@LevelId", buildingEdit.LevelId},
                {"@CampusId", buildingEdit.CampusId},
                {"@CarAreaId", buildingEdit.CarAreaId},
                {"@BikeAreaId", buildingEdit.BikeAreaId}
            };

                var result = await ExecuteReaderAsync(GetBuildingLevelByIdSpName, mapper, args);
                return result;

            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
