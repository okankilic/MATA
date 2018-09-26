using MATA.Presentation.Web.Filters;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthenticateUserAttribute());
            filters.Add(new AuthorizeUserAttribute());
            filters.Add(new CustomLogAttribute());
        }
    }
}
