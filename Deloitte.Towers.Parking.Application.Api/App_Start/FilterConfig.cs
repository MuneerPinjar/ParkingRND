using System.Web;
using System.Web.Mvc;

namespace Deloitte.Towers.Parking.Application.Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ErrorHandler.AiHandleErrorAttribute());
        }
    }
}
