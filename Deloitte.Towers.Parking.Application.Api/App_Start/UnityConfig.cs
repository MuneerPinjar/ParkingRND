using System.Web.Http;
using Unity;
using Deloitte.Towers.Parking.Domain.Contracts.Common;
using Deloitte.Towers.Parking.Domain.Contracts.Managers;
using Deloitte.Towers.Parking.Domain.Contracts.Repositories;
using Deloitte.Towers.Parking.Infrastructure.Logging;
using Deloitte.Towers.Parking.Infrastructure.Managers;
using Deloitte.Towers.Parking.Infrastructure.Repositories;
using System;
using Deloitte.Towers.Parking.Infrastructure.IoC;

namespace Deloitte.Towers.Parking.Application.Api
{
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterComponents(container);

            ContainerHolder.UnityContainer = new UnityIoCContainer(container);

            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        public static void RegisterComponents(UnityContainer container)
        {

            #region MANAGERS

            container.RegisterType<IAdminUserManager, AdminUserManager>();
            container.RegisterType<IParkingManager, ParkingManager>();
            container.RegisterType<IUserProfileManager, UserProfileManager>();
            container.RegisterType<IBuildingManager, BuildingManager>();
            container.RegisterType<IVccIntergrationManager, VccIntergrationManager>();

            #endregion

            #region Repositories
            container.RegisterType<IAdminUserRepository, AdminUserRepository>();
            container.RegisterType<IParkingRepository, ParkingRepository>();
            container.RegisterType<IUserProfileRepository, UserProfileRepository>();
            container.RegisterType<IVccIntegrationRepository, VccIntegrationRepository>();
            container.RegisterType<IBuildingLevelRepository, BuildingLevelRepository>();

            #endregion

            #region Logger

            container.RegisterType<ILogger, Logger>();
            #endregion
        }
    }
}