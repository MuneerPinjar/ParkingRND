using Deloitte.Towers.Parking.Domain.Dto.Web.Building;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Domain.Contracts.Repositories
{
    public interface IBuildingLevelRepository
    {
        Task<IEnumerable<BuildingLevelEditDto>> GetAllAsync();
        Task EditBuildingLevelAsync(BuildingLevelEditDto buildingEdit);
        
        Task<BuildingLevelEditDto> GetBuildingLevelById(BuildingLevelDto buildingEdit);

    }
}
