using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Domain.Dto.Mobile
{
    public class ParkingForecastDto
    {
        public int AvailablePlaces { get; set; }
        public decimal AvailablePercent { get; set; }
        public DateTime Time { get; set; }
    }
}
