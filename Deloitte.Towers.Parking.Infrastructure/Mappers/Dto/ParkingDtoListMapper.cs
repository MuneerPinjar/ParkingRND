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
    public class ParkingDtoListMapper : IMapper<List<ParkingDto>>
    {
        public async Task<List<ParkingDto>> MapAsync(DbDataReader reader)
        {
            if (reader.IsNull())
                return null;

            var parkingStatsMapper = new CollectionMapper<ParkingStatsDto, ParkingStatsDtoRowMapper>();
            var currentStatsMapper = new CollectionMapper<ParkingDto, ParkingDtoRowMapper>();

            var parkingStats = await parkingStatsMapper.MapAsync(reader);
            var currentStats = await reader.MapNextResultAsync(currentStatsMapper);

            currentStats.ForEach(c => c.Forecast = parkingStats
                .Where(p => p.VehicleType == c.VehicleType && p.ParkingId == c.ParkingId)
                .Select(p => new ParkingForecastDto
                {
                    AvailablePlaces = p.AvailablePlaces,
                    AvailablePercent = p.AvailablePercent,
                    Time = p.Time
                })
                .ToList());

            return currentStats;
        }
    }
}
