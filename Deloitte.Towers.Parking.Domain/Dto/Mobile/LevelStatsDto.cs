using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Domain.Dto.Mobile
{
    public class LevelStatsDto
    {
        public int LevelStatsId { get; set; }
        public string LevelName { get; set; }
        public int LevelId { get; set; }
        public int AvailablePlaces { get; set; }
        public int OccupiedPlaces { get; set; }
        public int Rank { get; set; }
        public decimal LevelAvailablePercent { get; set; }
    }
}
