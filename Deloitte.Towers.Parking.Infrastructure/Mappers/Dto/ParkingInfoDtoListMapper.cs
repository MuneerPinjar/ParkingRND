using Deloitte.Towers.Parking.Domain.Dto.Mobile;
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
    public class ParkingInfoDtoListMapper : IMapper<List<ParkingInfoDto>>
    {
        public async Task<List<ParkingInfoDto>> MapAsync(DbDataReader reader)
        {
            if (reader.IsNull())
                return null;

            var mapper = new CollectionMapper<ParkingInfoDto, ParkingInfoDtoRowMapper>();
            var collection = await mapper.MapAsync(reader);
            return collection;
        }
    }
}
