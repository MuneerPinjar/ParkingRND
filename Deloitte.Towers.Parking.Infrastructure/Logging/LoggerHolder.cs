using Deloitte.Towers.Parking.Domain.Contracts.Common;
using Deloitte.Towers.Parking.Infrastructure.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Logging
{
    public static class LoggerHolder
    {
        static LoggerHolder()
        {
            Logger = ContainerHolder.UnityContainer.Resolve<ILogger>();
        }

        public static ILogger Logger { get; }
    }
}
