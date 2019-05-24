using Deloitte.Towers.Parking.Domain.Contracts.Managers;
using Deloitte.Towers.Parking.Infrastructure.Helpers;
using Deloitte.Towers.Parking.Infrastructure.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.IdentityModel.Selectors;
using Deloitte.Towers.Parking.Infrastructure.Managers;
using Deloitte.Towers.Parking.Domain.Contracts.Common;
using System.IdentityModel.Selectors;

namespace Deloitte.Towers.Parking.Application.Api.Attributes
{
    public class WebAdminAuthorizeAttribute : AuthorizeAttribute
    {
        private const string IdentityClaimsName = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress";
        private readonly IAdminUserManager _adminUserManager;

        public WebAdminAuthorizeAttribute() : this(ContainerHolder.UnityContainer.Resolve<IAdminUserManager>())
        {
        }

        public WebAdminAuthorizeAttribute(IAdminUserManager adminUserManager)
        {
            _adminUserManager = adminUserManager;
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
           if (!base.IsAuthorized(actionContext)) return false;

            var userIdentity = HttpContext.Current.User.Identity;

            if (!userIdentity.IsAuthenticated) return false;

            var name = HttpContext.Current.User.GetUserEmail()?.ToLower();

            if (name == null) throw new IdentityValidationException("Name is not defined");

            var task = Task.Run(async () => await _adminUserManager.GetAdminUserByEmailAsync(name));
            task.Wait();
       
            var adminUser = task.Result;

            return adminUser != null && !adminUser.IsDeleted;

        }
    }
}