using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deloitte.Towers.Parking.Domain.Contracts.Common;
using Microsoft.Practices.ServiceLocation;
using Unity;

namespace Deloitte.Towers.Parking.Infrastructure.IoC
{
    public class UnityIoCContainer : IIoCContainer
    {
        private readonly Unity.IUnityContainer _unityContainer;

        public UnityIoCContainer(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }

        public object Resolve(Type t, string name)
        {
            return _unityContainer.Resolve(t);
        }

        public IEnumerable<object> ResolveAll(Type t)
        {
            return _unityContainer.ResolveAll(t);
        }

        public T Resolve<T>()
        {
            return _unityContainer.Resolve<T>();
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return _unityContainer.ResolveAll<T>();
        }
    }
}
