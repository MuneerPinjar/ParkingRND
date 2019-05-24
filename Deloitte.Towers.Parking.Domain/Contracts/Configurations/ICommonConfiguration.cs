using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Domain.Contracts.Configurations
{
    public interface ICommonConfiguration
    {
        string PhotoApiUrl { get; }
        string TrafficImageApiUrl { get; }
        double CacheAbsoluteExpirationSecond { get; }
    }
}
