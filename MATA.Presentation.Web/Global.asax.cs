using MATA.BL;
using MATA.BL.Interfaces;
using MATA.BL.IOC;
using MATA.BL.Mappers;
using MATA.Data.DTO.Impls;
using MATA.Data.DTO.Interfaces;
using MATA.Data.DTO.Models;
using MATA.Presentation.Web.Impls;
using MATA.Presentation.Web.Interfaces;
using MATA.Presentation.Web.Models.Cities;
using MATA.Presentation.Web.Models.Countries;
using MATA.Presentation.Web.Models.Projects;
using MATA.Presentation.Web.Models.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            
            container.AddNewExtension<BLUnityContainerExtension>();

            container.RegisterType<IVMFactory<CountriesIndexVM>, CountryVMFactory>();
            container.RegisterType<IVMFactory<CitiesIndexVM>, CitiesVMFactory>();
            container.RegisterType<IVMFactory<ProjectsIndexVM>, ProjectsVMFactory>();
            container.RegisterType<IVMFactory<StoresIndexVM>, StoresVMFactory>();

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
