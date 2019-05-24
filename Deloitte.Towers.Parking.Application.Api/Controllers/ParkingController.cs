using Deloitte.Towers.Parking.Domain.Contracts.Managers;
using Deloitte.Towers.Parking.Domain.Dto.Mobile;
using Deloitte.Towers.Parking.Domain.Entities;
using Deloitte.Towers.Parking.Domain.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace Deloitte.Towers.Parking.Application.Api.Controllers
{
    [RoutePrefix("parking")]
    [Authorize]
    public class ParkingController : BaseApiController
    {

        private const string DuplicateLevelIds = "Array contains duplicate level ids";
        private readonly IParkingManager _parkingManager;

        public ParkingController(IParkingManager parkingManager)
        {
            _parkingManager = parkingManager;
        }

        [HttpGet]
        [Route("parkingsWithData")]
        [ResponseType(typeof(BaseApiResponse<IEnumerable<ParkingInfoDto>>))]
        public async Task<IHttpActionResult> GetParkingsWithDataAsync()
        {
            var result = await GetAllAsync(() => _parkingManager.GetCampusParkingssWithDataAsync());
            return result;
        }

        [HttpGet]
        [Route("levelStatsAllParkings")]
        [ResponseType(typeof(BaseApiResponse<IEnumerable<LevelDto>>))]
        public async Task<IHttpActionResult> GetLevelStatsAllParkingsAsync([FromUri] VehicleType[] vehicleType = null)
        {
            var result = await GetAllAsync(() => _parkingManager.GetLevelStatsAllParkingsAsync(vehicleType));
            return result;
        }

        [HttpGet]
        [Route("parkingsForecast")]
        [ResponseType(typeof(BaseApiResponse<IEnumerable<ParkingDto>>))]
        public async Task<IHttpActionResult> GetParkingsForecastAsync([FromUri] VehicleType[] vehicleType = null)
        {
            var utcNow = DateTime.Now;

            var result = await GetAllAsync(() => _parkingManager.GetParkingsForecastAsync(utcNow, vehicleType));
            return result;
        }
    }
}
