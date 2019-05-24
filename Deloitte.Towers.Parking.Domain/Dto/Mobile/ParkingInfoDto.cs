using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Domain.Dto.Mobile
{
    public class ParkingInfoDto
    {
        public int CampusId { get; set; }
        public int ParkingId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TotalCarSpaces { get; set; }
        public int TotalBikeSpaces { get; set; }
        public int TotalReservedCarSpaces { get; set; }
        public int TotalReservedBikeSpaces { get; set; }
        public int TotalAvailableCarSpaces => TotalCarSpaces - TotalReservedCarSpaces;
        public int TotalAvailableBikeSpaces => TotalBikeSpaces - TotalReservedBikeSpaces;
    }
}
