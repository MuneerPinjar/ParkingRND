using Deloitte.Towers.Parking.Application.Api.Attributes;
using Deloitte.Towers.Parking.Domain.Contracts.Managers;
using Deloitte.Towers.Parking.Domain.Dto.Web.Building;
using Deloitte.Towers.Parking.Domain.Entities;
using Deloitte.Towers.Parking.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Deloitte.Towers.Parking.Application.Api.Controllers
{

    [RoutePrefix("buildings")]
    [WebAdminAuthorize]
    public class BuildingController : BaseApiController
    {
        private const string BodyShouldNotBeNull = "Body should not be null";
        private readonly IBuildingManager _buildingManager;


        public BuildingController(IBuildingManager buildingManager)
        {
            _buildingManager = buildingManager;
        }

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(BaseApiResponse<BuildingLevelEditDto>))]
        public async Task<IHttpActionResult> GetAllAsync()
        {
            var result = await GetAllAsync(() => _buildingManager.GetAllAsync());
            return result;
        }

        [HttpPut]
        [Route("")]        
        public async Task<IHttpActionResult> EditBuildingLevelAsync([FromBody] BuildingLevelEditDto dto)
        {
            if (dto == null) throw new InvalidParameterValueException(BodyShouldNotBeNull);

            var result = await PutAsync(_buildingManager.EditBuildingAsync,dto);
            return result;
        }


        [HttpGet]
        [Route("")]
        [ResponseType(typeof(BaseApiResponse<BuildingLevelEditDto>))]
        public async Task<IHttpActionResult> GetBuildingLevelById(int levelId,int campusId,int carAreaId,int BikeAreaId)
        {
            BuildingLevelEditDto dto = new BuildingLevelEditDto();
            dto.LevelId = levelId;
            dto.CampusId = campusId;
            dto.CarAreaId = carAreaId;
            dto.BikeAreaId = BikeAreaId;
            var result = await GetSingleByKeyAsync(_buildingManager.GetBuildingLevelById, dto);
            return result;
        }
    }
}
