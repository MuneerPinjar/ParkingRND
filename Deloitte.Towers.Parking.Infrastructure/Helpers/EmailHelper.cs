using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Helpers
{
    public static class EmailHelper
    {
        private const string IdentityClaimsName = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress";

        public static string GetDeloitteId(this string email)
        {
            string userName = email;

            var indexOfSlash = email.IndexOf(@"\", StringComparison.InvariantCultureIgnoreCase);
            if (indexOfSlash > -1)
            {
                userName = email.Substring(indexOfSlash + 1);
            }

            var indexOfAt = email.IndexOf(@"@", StringComparison.InvariantCultureIgnoreCase);
            if (indexOfAt > -1)
            {
                userName = email.Substring(0, indexOfAt);
            }

            return userName.ToLower();
        }

        public static string GetUserEmail(this IPrincipal principal)
        {
            var identity = principal.Identity as ClaimsIdentity;

            var name = identity?.FindFirst(IdentityClaimsName)?.Value;

            name = CheckEmail(name);

            if (string.IsNullOrWhiteSpace(name))
            {
                name = identity?.FindFirst(ClaimTypes.Name)?.Value;

                name = CheckEmail(name);
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                name = identity?.FindFirst(ClaimTypes.Email)?.Value;

                name = CheckEmail(name);
            }

            return name;
        }

        private static string CheckEmail(string name)
        {
            if (name?.Contains('@') != true) name = null;
            return name;
        }
    }
}
