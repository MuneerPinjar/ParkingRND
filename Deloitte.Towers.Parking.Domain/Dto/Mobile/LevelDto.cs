using Deloitte.Towers.Parking.Domain.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Domain.Dto.Mobile
{
    public class LevelDto
    {
        public VehicleType VehicleType { get; set; }
        public int AvailablePlaces { get; set; }
        public decimal AvailablePercent { get; set; }
        public IEnumerable<LevelStatsDto> Stats { get; set; }
        public int ParkingId { get; set; }
    }
}
