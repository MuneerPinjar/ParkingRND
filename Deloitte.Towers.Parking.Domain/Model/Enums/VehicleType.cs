using System.Xml.Serialization;

namespace Deloitte.Towers.Parking.Domain.Model.Enums
{
    public enum VehicleType
    {
        [XmlEnum("1")]
        Car = 1,
        [XmlEnum("2")]
        Bike = 2
    }
}
