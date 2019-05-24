using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Deloitte.Towers.Parking.Domain.Contracts.Managers;
using Deloitte.Towers.Parking.Domain.Dto.VccData;


namespace Deloitte.Towers.Parking.Application.Api.Controllers
{
    [RoutePrefix("vccintegration")]
    [Authorize]
    public class VccIntegrationController : ApiController
    {
        private readonly IVccIntergrationManager _VccIntergrationManager;


        public VccIntegrationController(IVccIntergrationManager vccIntergrationManager)
        {
            _VccIntergrationManager = vccIntergrationManager;

        }
           

        [HttpPost]
        public void Post(VCCRootData dto)
        {
            _VccIntergrationManager.SaveVccData(dto);
        }
    }
}
