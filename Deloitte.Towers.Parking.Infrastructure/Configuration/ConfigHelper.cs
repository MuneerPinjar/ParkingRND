using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
using System.IO;

namespace Deloitte.Towers.Parking.Infrastructure.Configuration
{
    public static class ConfigHelper
    {
        private static System.Configuration.Configuration _externalConfiguration;

        public static ConnectionStringSettingsCollection ConnectionStrings => _externalConfiguration != null
            ? _externalConfiguration.ConnectionStrings.ConnectionStrings
            : ConfigurationManager.ConnectionStrings;

        public static void SetExternalConfiguration(Assembly assembly)
        {
            var path = Path.GetFullPath(Path.Combine(new Uri(Path.GetDirectoryName(assembly.CodeBase)).LocalPath, @"..\"));
            var configFilename = Path.Combine(path, $"{assembly.GetName().Name}.dll.config");
            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = configFilename };

            _externalConfiguration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
        }

        public static void RemoveExternalConfiguration()
        {
            _externalConfiguration = null;
        }

        public static string AppSettings(string key)
        {
            return _externalConfiguration != null
                ? _externalConfiguration.AppSettings.Settings[key]?.Value
                : ConfigurationManager.AppSettings[key];
        }
    }
}
