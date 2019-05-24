using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Deloitte.Towers.Parking.Infrastructure.Configuration;

namespace Deloitte.Towers.Parking.Infrastructure.Repositories.Helpers
{
    public static class ConnectionStringHelper
    {
        public static ConnectionStringSettingsCollection ConnectionStringSettingsCollection = ConfigHelper.ConnectionStrings;
        public const string ConnectionStringName = "Database";
        public const string FileDbConnectionStringName = "FileDatabase";

        public static string ConnectionString => GetConnectionString(ConnectionStringName);

        public static string FileDbConnectionString => GetConnectionString(FileDbConnectionStringName);

        public static string GetConnectionString(string connectionStringName)
        {
            var connectionStringSettings = GetConnectionStringSettings(connectionStringName);
            return connectionStringSettings.ConnectionString;
        }

        public static string GetDbProviderName(string connectionStringName)
        {
            var connectionSettings = GetConnectionStringSettings(connectionStringName);
            return connectionSettings.ProviderName;
        }

        private static ConnectionStringSettings GetConnectionStringSettings(string connectionStringName)
        {
            var connectionStringSettings = ConnectionStringSettingsCollection[connectionStringName];
            if (string.IsNullOrEmpty(connectionStringSettings?.ConnectionString))
            {
                throw new ApplicationException("Fatal error: missing connecting string in config file");
            }

            return connectionStringSettings;
        }
    }

}
