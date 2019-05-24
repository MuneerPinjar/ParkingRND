using Deloitte.Towers.Parking.Domain.Contracts.Managers;
using Deloitte.Towers.Parking.Domain.Contracts.Repositories;
using Deloitte.Towers.Parking.Domain.Dto.Web.Building;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Managers
{
    public class BuildingManager : IBuildingManager
    {
        private readonly IBuildingLevelRepository _buildingLevelRepository;

        public BuildingManager(IBuildingLevelRepository buildingLevelRepository)
        {
            _buildingLevelRepository = buildingLevelRepository;
        }

        public async Task EditBuildingAsync(BuildingLevelEditDto buildingEdit)
        {
            try
            {
                await _buildingLevelRepository.EditBuildingLevelAsync(buildingEdit);
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
                var result = await _buildingLevelRepository.GetAllAsync();
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
                var buildinglevel = await _buildingLevelRepository.GetBuildingLevelById(buildingEdit);
                return buildinglevel;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
