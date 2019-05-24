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
    public class AdminUserDtoMapper : IMapper<AdminUserDto>
    {
        public async Task<AdminUserDto> MapAsync(DbDataReader reader)
        {
            if (await reader.IsNullOrEmptyAsync())
                return null;

            var dto = new AdminUserDto
            {
                Email = reader.GetString("EmailId"),
                IsActive = reader.GetValue<bool>("IsActive"),
                FirstName = reader.GetString("FirstName"),
                LastName = reader.GetString("LastName"),
                CreatedBy = reader.GetString("CreatedBy"),
                ModifiedBy = reader.GetString("ModifiedBy"),
                CreatedDate = reader.GetValue<DateTime>("CreatedDate"),
                LastModificationDate = reader.GetValue<DateTime>("LastModificationDate"),
                IsDeleted = reader.GetValue<bool>("IsDeleted")

            };

            return dto;
        }
    }
}
