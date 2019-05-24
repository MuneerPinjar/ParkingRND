using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deloitte.Towers.Parking.Domain.Contracts.Common;

namespace Deloitte.Towers.Parking.Infrastructure.IoC
{
    public static class ContainerHolder
    {
        public static IIoCContainer UnityContainer { get; set; }
    }
}
