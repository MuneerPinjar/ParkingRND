using Deloitte.Towers.Parking.Domain.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Domain.Dto.Mobile
{
    public class ParkingDto
    {
        public int VehicleType { get; set; }

        public int AvailablePlacesNow { get; set; }
        public decimal AvailablePercentNow { get; set; }

        public IEnumerable<ParkingForecastDto> Forecast { get; set; }
        public int ParkingId { get; set; }
    }
}
