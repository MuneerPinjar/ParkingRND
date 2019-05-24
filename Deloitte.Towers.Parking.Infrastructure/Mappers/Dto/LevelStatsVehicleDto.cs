using Deloitte.Towers.Parking.Domain.Dto.Mobile;
using Deloitte.Towers.Parking.Domain.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Mappers.Dto
{
    public class LevelStatsVehicleDto : LevelStatsDto
    {
        public VehicleType VehicleType { get; set; }
        public int ParkingId { get; set; }
    }
}
