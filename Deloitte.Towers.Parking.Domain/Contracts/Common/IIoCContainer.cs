using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Domain.Contracts.Common
{
    public interface IIoCContainer
    {
        object Resolve(Type t, string name);

        IEnumerable<object> ResolveAll(Type t);

        T Resolve<T>();

        IEnumerable<T> ResolveAll<T>();
    }
}
