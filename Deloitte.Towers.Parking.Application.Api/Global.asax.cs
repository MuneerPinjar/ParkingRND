
using Deloitte.Towers.Parking.Domain.Model.Enums;
using Deloitte.Towers.Parking.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Deloitte.Towers.Parking.Application.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();        
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }



        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            LoggerHolder.Logger.HandleException(LoggingBoundaries.ServiceBoundary, exception);
            throw new Exception(exception.Message, exception);
        }
    }
}
