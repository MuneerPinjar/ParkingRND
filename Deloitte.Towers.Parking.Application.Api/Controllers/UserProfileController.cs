using Deloitte.Towers.Parking.Application.Api.Attributes;
using Deloitte.Towers.Parking.Domain.Contracts.Managers;
using Deloitte.Towers.Parking.Domain.Dto.Web.EndUser;
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
    [RoutePrefix("user")]
    [WebAdminAuthorize]
    public class UserProfileController : BaseApiController
    {
        private const string BodyShouldNotBeNull = "Body should not be null";

        private readonly IUserProfileManager _userProfileManager;

        public UserProfileController(IUserProfileManager userProfileManager)
        {
            _userProfileManager = userProfileManager;
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(BaseApiResponse<int>))]
        public async Task<IHttpActionResult> AddUserProfileAsync([FromBody] UserProfileDto dto)
        {
            try
            {
                if (dto == null) throw new InvalidParameterValueException(BodyShouldNotBeNull);

                var result = await PostAsync(_userProfileManager.AddUserProfileAsync, dto);
                return result;
            }
            catch
            {
                return InternalServerError();
            }

        }

        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> UpdateUserProfileAsync([FromBody] UserProfileDto dto)
        {
            if (dto == null) throw new InvalidParameterValueException(BodyShouldNotBeNull);

            var result = await PutAsync(_userProfileManager.UpdateUserProfileAsync, dto);
            return result;
        }

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(BaseApiResponse<IEnumerable<UserProfileDto>>))]
        public async Task<IHttpActionResult> GetAllAsync(int pageNumber=1, int rowsPerPage=10,string search="")
        {
           
          var result =  await GetAllByFilterWithPagingAsync(
                   (howFilter,howSkip, howTake) =>
                       _userProfileManager.GetAllAsync(howSkip, howTake, howFilter),search, pageNumber,
                   rowsPerPage);
            return result;
        }


    }
}
