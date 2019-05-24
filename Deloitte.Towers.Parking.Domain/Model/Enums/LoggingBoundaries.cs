using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Domain.Model.Enums
{
    public enum LoggingBoundaries
    {
        Database,
        DataLayer,
        DomainLayer,
        Host,
        ServiceBoundary,
        UI,
        UICritical
    }
}
