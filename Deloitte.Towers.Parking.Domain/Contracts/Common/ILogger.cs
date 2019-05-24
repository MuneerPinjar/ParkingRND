using Deloitte.Towers.Parking.Domain.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Domain.Contracts.Common
{
    public interface ILogger
    {
        bool HandleException(LoggingBoundaries boundary, Exception ex);

        bool HandleException(string boundary, Exception ex);

        void LogAudit(LoggingBoundaries boundary, string format, params object[] paramList);

        void LogError(LoggingBoundaries boundary, string format, params object[] paramList);

        void LogInformation(LoggingBoundaries boundary, string format, params object[] paramList);

        void LogTrace(LoggingBoundaries boundary, string format, params object[] paramList);

        void LogWarning(LoggingBoundaries boundary, string format, params object[] paramList);
    }
}
