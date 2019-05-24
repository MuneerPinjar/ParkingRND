using Deloitte.Towers.Parking.Domain.Dto.Web.Building;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Domain.Contracts.Managers
{
    public interface IBuildingManager
    {
        Task<IEnumerable<BuildingLevelEditDto>> GetAllAsync();
        Task EditBuildingAsync(BuildingLevelEditDto buildingEdit);
        Task<BuildingLevelEditDto> GetBuildingLevelById(BuildingLevelDto buildingEdit);
    }
}
