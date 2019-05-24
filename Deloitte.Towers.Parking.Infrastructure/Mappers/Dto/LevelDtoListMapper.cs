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
    public class LevelDtoListMapper : IMapper<List<LevelDto>>
    {
        public async Task<List<LevelDto>> MapAsync(DbDataReader reader)
        {
            if (reader.IsNull())
                return null;

            var levelStatsMapper = new CollectionMapper<LevelStatsVehicleDto, LevelStatsVehicleDtoRowMapper>();
            var parkingStatsMapper = new CollectionMapper<LevelDto, LevelDtoRowMapper>();

            var levelStats = await levelStatsMapper.MapAsync(reader);
            var parkingStats = await reader.MapNextResultAsync(parkingStatsMapper);

            parkingStats.ForEach(p => p.Stats = levelStats
                .Where(l => l.VehicleType == p.VehicleType && l.ParkingId == p.ParkingId)
                .Select(l => new LevelStatsDto
                {
                    LevelStatsId = l.LevelStatsId,
                    LevelName = l.LevelName,
                    LevelId = l.LevelId,
                    AvailablePlaces = l.AvailablePlaces,
                    OccupiedPlaces = l.OccupiedPlaces,
                    Rank = l.Rank,
                    LevelAvailablePercent = l.LevelAvailablePercent
                })
                .ToList());

            return parkingStats;
        }
    }
}
