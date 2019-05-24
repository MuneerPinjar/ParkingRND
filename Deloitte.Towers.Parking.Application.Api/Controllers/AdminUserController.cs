using Deloitte.Towers.Parking.Application.Api.Attributes;
using Deloitte.Towers.Parking.Domain.Contracts.Managers;
using Deloitte.Towers.Parking.Domain.Dto.Web.AdminUser;
using Deloitte.Towers.Parking.Domain.Entities;
using Deloitte.Towers.Parking.Infrastructure.Exceptions;
using Deloitte.Towers.Parking.Infrastructure.Helpers;
using Deloitte.Towers.Parking.Infrastructure.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace Deloitte.Towers.Parking.Application.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-My-Header")]
    [RoutePrefix("adminUsers")]
    [WebAdminAuthorize]
    public class AdminUserController : BaseApiController
    {
        private const string BodyShouldNotBeNull = "Body should not be null";
        private const string KeywordMinLength = "The searchString parameter should have more than 2 symbols";
        private IAdminUserManager _adminUserManager;

        public AdminUserController(IAdminUserManager adminUserManager)
        {
            _adminUserManager = adminUserManager;
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(BaseApiResponse<int>))]
        public async Task<IHttpActionResult> AddAdminUserAsync([FromBody] AdminUserAddDto dto)
        {
            try
            {
                if (dto == null) throw new InvalidParameterValueException(BodyShouldNotBeNull);
                if(dto.CreatedBy == null)
                {
                    dto.CreatedBy = HttpContext.Current.User.GetUserEmail()?.ToLower();
                }
                
                var result = await PostAsync(_adminUserManager.AddAdminUserAsync, dto);
                return result;
            }
            catch (Exception e) 
            {
                throw e;               
            }

        }

        [HttpGet]
        [Route("")]

        [ResponseType(typeof(BaseApiResponse<IEnumerable<AdminUserEditDto>>))]
        public async Task<IHttpActionResult> GetAllAsync(int pageNumber = 1, int rowsPerPage = 10, string search = "")
        {
            try
            {

                var result = await GetAllByFilterWithPagingAsync(
                (howFilter, howSkip, howTake) => _adminUserManager.GetAllAsync(howSkip, howTake, howFilter), search, pageNumber, rowsPerPage);
                return result;
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        [HttpGet]
        [Route("")]
        [ResponseType(typeof(BaseApiResponse<AdminUserEditDto>))]
        public async Task<IHttpActionResult> GetAdminUserByEmaildAsync(string email)
        {
            try
            {
                var result = await GetSingleByKeyAsync(_adminUserManager.GetAdminUserByEmailAsync, email);
                return result;
            }
            catch (Exception e)
            {

                throw e;
            }
          
        }

        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> DeleteAdminUserAsync([FromBody] AdminDeleteDto dto)
        {
            try
            {
                if (dto == null) throw new InvalidParameterValueException(BodyShouldNotBeNull);

                if(dto.ModifiedBy== null)
                {
                    dto.ModifiedBy = HttpContext.Current.User.GetUserEmail()?.ToLower();
                }
                
                var result = await PutAsync(_adminUserManager.DeleteAdminUserAsync, dto);
                return result;
            }
            catch (Exception e)
            {

                throw e;
            }
         
        }

    }
}
