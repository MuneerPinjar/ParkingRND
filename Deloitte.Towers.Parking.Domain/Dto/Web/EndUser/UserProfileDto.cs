using Deloitte.Towers.Parking.Domain.Dto.Mobile;
using Deloitte.Towers.Parking.Domain.Model.Enums;
using Deloitte.Towers.Parking.Domain.Validators;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Domain.Dto.Web.EndUser
{
    [Validator(typeof(UserProfileAddValidator))]
    public class UserProfileDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public VehicleType VehicleType { get; set; }
        public bool LocationTracking { get; set; }
        public bool GeoFencingNotification { get; set; }
        public bool ParkingFullNotification { get; set; }
        public DateTime LastLogin { get; set; }
        public bool IsDeleted { get; set; }
        public int Campus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime LastModificationDate { get; set; }
        public bool IsActive { get; set; }
        public string Vehicledata { get; set; }
        public string MondayArrivalTime { get; set; }
        public string TuesdayArrivalTime { get; set; }
        public string WedArrivalTime { get; set; }
        public string ThuArrivalTime { get; set; }
        public string FriArrivalTime { get; set; }
        public string SatArrivalTime { get; set; }
        public string SunArrivalTime { get; set; }
        public string LastModifiedBy { get; set; }

        public List<ArrivalTimeDto> ArrivalTime { get; set; }


        public string LocationTrackingstats
        {
            get { return (LocationTracking == true) ? "Yes" : "No"; }
            set { }
        }
        public string GeoFencingStats
        {
            get { return (GeoFencingNotification == true) ? "Yes" : "No"; }
            set { }
        }
        public string ParkingFullNotificationStats
        {
            get { return (ParkingFullNotification == true) ? "Yes" : "No"; }
            set { }
        }
        public string Status
        {
            get { return (IsActive == true) ? "Active" : "Inactive"; }
            set { }
        }

        public string LastLoginData { get; set; }

    }
}

