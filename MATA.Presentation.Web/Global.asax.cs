using MATA.BL.Ioc;
using MATA.Data.Repositories.Ioc;
using MATA.Presentation.Web.Ioc;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using Unity.AspNet.Mvc;

namespace MATA.Presentation.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            var container = new UnityContainer();

            container.AddNewExtension<DataRepositoriesUnityContainerExtension>();
            container.AddNewExtension<BLUnityContainerExtension>();
            container.AddNewExtension<PresentationWebUnityContainerExtension>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error()
        {
            var ex = Server.GetLastError();

            Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
        }
    }
}
