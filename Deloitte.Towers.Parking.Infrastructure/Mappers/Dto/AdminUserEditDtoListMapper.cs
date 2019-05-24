using Deloitte.Towers.Parking.Domain.Dto.Web.AdminUser;
using Deloitte.Towers.Parking.Domain.Entities;
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
    public class AdminUserEditDtoListMapper : IMapper<PageContainer<AdminUserEditDto>>
    {
        public async Task<PageContainer<AdminUserEditDto>> MapAsync(DbDataReader reader)
        {
            if (reader.IsNull())
                return null;

            var mapper = new CollectionMapper<AdminUserEditDto, AdminUserEditDtoRowMapper>();
            var collection = await mapper.MapAsync(reader);
            var totalCount = await reader.GetNextScalarAsync<int>("TotalCount");
            return collection.ToPageContainer(totalCount);
        }
    }
}
