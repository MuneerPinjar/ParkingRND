using Deloitte.Towers.Parking.Domain.Dto.Web.EndUser;
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
   public class UserProfileDtoListMapper : IMapper<PageContainer<UserProfileDto>>
    {
        public async Task<PageContainer<UserProfileDto>> MapAsync(DbDataReader reader)
        {
            if (reader.IsNull())
                return null;
            var arrivaltimemapper = new CollectionMapper<ArrivalTimeDto, ArrivalTimeDtoRowMapper>();
            var userprofilemapper = new CollectionMapper<UserProfileDto, UserProfileDtoRowMapper>();

            var arrivaltimestats = await arrivaltimemapper.MapAsync(reader);

            var userprofilestats = await reader.MapNextResultAsync(userprofilemapper);

            userprofilestats.ForEach(p => p.ArrivalTime = arrivaltimestats
            .Where(l => l.UserEmailId == p.Email)
            .Select(l => new ArrivalTimeDto
            {
                DayOfTheWeek = l.DayOfTheWeek,
                Time = l.Time,
                UserEmailId = l.UserEmailId
            })
            .ToList());

            var collection = userprofilestats;
            var totalCount = await reader.GetNextScalarAsync<int>("TotalCount");
            return collection.ToPageContainer(totalCount);
        }
    }
}
