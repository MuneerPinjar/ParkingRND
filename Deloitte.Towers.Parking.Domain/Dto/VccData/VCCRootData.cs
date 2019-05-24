using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Domain.Dto.VccData
{
    public class VCCRootData
    {
        public DateTime AsOf { get; set; }
        public List<ParkingCampus> Carparks { get; set; }
    }

    public class ParkingCampus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MenuPosition { get; set; }
        public TotalsDetailed TotalsDetailed { get; set; }
        public List<Area> Areas { get; set; }
    }

    public class TotalsDetailed
    {
        public OccupencyDetails All { set; get; }
    }

    public class OccupencyDetails
    {
        public int Usable { get; set; }
        public int Vacant { get; set; }
        public int Occupied { get; set; }
        public int Unknown { get; set; }
    }

    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TotalsDetailed TotalsDetailed { get; set; }
        public DateTime LastValidCountTime { get; set; }
    }
}
