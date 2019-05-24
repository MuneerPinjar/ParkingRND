using Deloitte.Towers.Parking.Domain.Dto.Web.AdminUser;
using Deloitte.Towers.Parking.Infrastructure.Extensions;
using Deloitte.Towers.Parking.Infrastructure.Mappers.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Mappers.Dto
{
    public class AdminUserEditDtoRowMapper : IRowMapper<AdminUserEditDto>
    {
        public AdminUserEditDto Map(IDataReader reader)
        {
            if (reader.IsNull())
                return null;

            var dto = new AdminUserEditDto
            {
                Id = reader.GetValue<int>("Id"),
                CreatedBy = reader.GetString("CreatedBy"),
                CreatedDate = reader.GetValue<DateTime>("CreatedDate"),
                LastModificationDate = reader.GetValue<DateTime>("LastModificationDate"),
                ModifiedBy = reader.GetString("ModifiedBy"),
                Email = reader.GetString("EmailId"),
                IsActive = reader.GetValue<bool>("IsActive"),
                FirstName = reader.GetString("FirstName"),
                LastName = reader.GetString("LastName"),
                IsDeleted = reader.GetValue<bool>("IsDeleted"),
            };

            return dto;
        }
    }
}
