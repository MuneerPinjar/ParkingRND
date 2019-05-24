using Deloitte.Towers.Parking.Domain.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Domain.Dto.Mobile
{
    public class ParkingStatsDto : ParkingForecastDto
    {
        public int VehicleType { get; set; }
        public int ParkingId { get; set; }
    }
}
