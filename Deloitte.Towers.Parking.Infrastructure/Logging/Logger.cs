using Deloitte.Towers.Parking.Domain.Contracts.Common;
using Deloitte.Towers.Parking.Domain.Model.Enums;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Infrastructure.Logging
{
    public class Logger : ILogger
    {
        private static readonly ILog Log = LogManager.GetLogger("LOGGER");

        private static readonly string _ui = "UI Layer";
        private static readonly string _uiCritical = "UI Layer (Critical)";
        private static readonly string _serviceBoundary = "Service Boundary";
        private static readonly string _domainLayer = "Domain Layer";
        private static readonly string _dataLayer = "Data Layer";
        private static readonly string _database = "Database";
        private static readonly string _host = "Host";

        public bool HandleException(LoggingBoundaries boundary, Exception ex)
        {
            Log.Error(Convert(boundary), ex);
            return true;
        }

        public bool HandleException(string boundary, Exception ex)
        {
            Log.Error(boundary, ex);
            return true;
        }

        public void LogWarning(LoggingBoundaries boundary, string format, params object[] paramList)
        {
            Log.WarnFormat(paramList.Length == 0 ? format : string.Format(format, paramList), Convert(boundary), "Warning");
        }

        public void LogTrace(LoggingBoundaries boundary, string format, params object[] paramList)
        {
            Log.DebugFormat(paramList.Length == 0 ? format : string.Format(format, paramList), Convert(boundary), "Trace");
        }

        public void LogInformation(LoggingBoundaries boundary, string format, params object[] paramList)
        {
            Log.InfoFormat(paramList.Length == 0 ? format : string.Format(format, paramList), Convert(boundary), "Information");
        }

        public void LogError(LoggingBoundaries boundary, string format, params object[] paramList)
        {
            Log.ErrorFormat(paramList.Length == 0 ? format : string.Format(format, paramList), Convert(boundary), "Error");
        }

        public void LogAudit(LoggingBoundaries boundary, string format, params object[] paramList)
        {
            Log.DebugFormat(paramList.Length == 0 ? format : string.Format(format, paramList), Convert(boundary), "Audit");
        }

        private static string Convert(LoggingBoundaries lp)
        {
            switch (lp)
            {
                case LoggingBoundaries.UI:
                    return _ui;
                case LoggingBoundaries.UICritical:
                    return _uiCritical;
                case LoggingBoundaries.ServiceBoundary:
                    return _serviceBoundary;
                case LoggingBoundaries.DomainLayer:
                    return _domainLayer;
                case LoggingBoundaries.DataLayer:
                    return _dataLayer;
                case LoggingBoundaries.Database:
                    return _database;
                case LoggingBoundaries.Host:
                    return _host;
                default:
                    return "Unknown";
            }
        }
    }
}
