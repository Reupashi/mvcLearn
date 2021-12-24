using System.Web;
using System.Web.Mvc;

namespace ClassroomsInfo.Web.tests_navigation
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
