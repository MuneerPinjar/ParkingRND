using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Domain.Dto.Mobile
{
    public class LevelParkingsDto
    {
        public DateTime AsOf { get; set; }
        public int ParkId { get; set; }
        public string ParkName { get; set; }
        public int TotalAvailable { get; set; }
        public int LevelAvailable { get; set; }
        public int LevelOccupied { get; set; }
        public float TotalPerByBuilding { get; set; }
        public int LevelId { get; set; }
        public int VechileTypeId { get; set; }
    }
}
