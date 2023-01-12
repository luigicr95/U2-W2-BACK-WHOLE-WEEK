using System.Web;
using System.Web.Mvc;

namespace U2_W2_BACK_WHOLE_WEEK
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
