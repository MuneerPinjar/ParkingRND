using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Domain.Dto.Web.Building
{
    public class BuildingLevelDto
    {
        public int LevelId { get; set; }
        public int CampusId { get; set; }
        public int CarAreaId { get; set; }
        public int BikeAreaId { get; set; }
        public bool IsActive { get; set; }
        public string CampusName { get; set; }
        public string Level { get; set; }
        public int CarParkings { get; set; }
        public int BikeParkings { get; set; }
        public int ReservedCarParkings { get; set; }
        public int ReservedBikeParkings { get; set; }
        public int AvailableCarParkings { get; set; }
        public int AvailableBikeParkings { get; set; }

        public string Status
        {
            get { return (IsActive == true) ? "Disable" : "Enable"; }
            set { }
        }

    }
}
