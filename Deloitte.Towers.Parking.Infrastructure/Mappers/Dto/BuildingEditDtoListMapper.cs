using Deloitte.Towers.Parking.Domain.Dto.Web.Building;
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
    public class BuildingEditDtoListMapper : IMapper<List<BuildingLevelEditDto>>
    {
        public async Task<List<BuildingLevelEditDto>> MapAsync(DbDataReader reader)
        {
            if (reader.IsNull())
                return null;

            var levelListMapper = new CollectionMapper<BuildingLevelEditDto, BuildingEditDtoRowMapper>();

            var levels = await levelListMapper.MapAsync(reader);

            return levels;
        }
    }
}
