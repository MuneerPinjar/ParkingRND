using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Domain.Dto.Web.AdminUser
{
    public class AuthorizeDto
    {
        public List<string> Roles { get; set; }

        public bool IsAdmin { get; set; }

    }
}
