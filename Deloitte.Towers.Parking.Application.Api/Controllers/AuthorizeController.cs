using Deloitte.Towers.Parking.Domain.Contracts.Managers;
using Deloitte.Towers.Parking.Domain.Dto.Web.AdminUser;
using Deloitte.Towers.Parking.Domain.Entities;
using Deloitte.Towers.Parking.Infrastructure.Helpers;
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
    [RoutePrefix("userauthorize")]
    [Authorize]
    public class AuthorizeController : ApiController
    {
        private IAdminUserManager _adminUserManager;

        public AuthorizeController(IAdminUserManager adminUserManager)
        {
            _adminUserManager = adminUserManager;
        }


        [HttpGet]
        [Route("")]
        public async Task<AuthorizeDto> Get()
        {
            var userIdentity = HttpContext.Current.User.Identity;            

            var name = HttpContext.Current.User.GetUserEmail()?.ToLower();         

            var task = Task.Run(async () => await _adminUserManager.GetAdminUserByEmailAsync(name));
            task.Wait();

            var adminUser = task.Result;
            AuthorizeDto dto = new AuthorizeDto();
            List<string> roles = new List<string>();
            if (adminUser!=null && !adminUser.IsDeleted)
            {
                roles.Add("AdminUser");
                roles.Add("MobileUser");
                dto.Roles = roles;
                dto.IsAdmin = true;
            }
            else
            {
                roles.Add("MobileUser");
                dto.Roles = roles;
                dto.IsAdmin = false;
            }
            return dto;           
        }
    }
}
