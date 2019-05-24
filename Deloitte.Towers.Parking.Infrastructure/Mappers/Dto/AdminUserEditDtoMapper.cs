using Deloitte.Towers.Parking.Domain.Dto.Web.AdminUser;
using Deloitte.Towers.Parking.Infrastructure.Extensions;
using Deloitte.Towers.Parking.Infrastructure.Mappers.Common;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Mappers.Dto
{
    public class AdminUserEditDtoMapper : IMapper<AdminUserEditDto>
    {
        public async Task<AdminUserEditDto> MapAsync(DbDataReader reader)
        {
            if (await reader.IsNullOrEmptyAsync())
                return null;

            var dto = new AdminUserEditDto
            {
                Id = reader.GetValue<int>("Id"),
                Email = reader.GetString("Email"),
                IsActive = reader.GetValue<bool>("IsActive"),
                FirstName = reader.GetString("FirstName"),
                LastName = reader.GetString("LastName")
            };

            return dto;
        }
    }
}
