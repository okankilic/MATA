using MATA.Data.DTO.Models;
using MATA.Presentation.Web.Impls;
using MATA.Presentation.Web.Interfaces;
using MATA.Presentation.Web.Models.Accounts;
using MATA.Presentation.Web.Models.Cities;
using MATA.Presentation.Web.Models.Countries;
using MATA.Presentation.Web.Models.Issues;
using MATA.Presentation.Web.Models.Projects;
using MATA.Presentation.Web.Models.Stores;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;
using Unity.Extension;

namespace MATA.Presentation.Web.Ioc
{
    public class PresentationWebUnityContainerExtension: UnityContainerExtension
    {
        protected override void Initialize()
        {
            var logger = LogManager.GetLogger("");

            Container.RegisterInstance<ILogger>(logger);

            Container.RegisterType(typeof(IVMFactory<AccountDTO, AccountsIndexVM>), typeof(AccountVMFactory));
            Container.RegisterType(typeof(IVMFactory<CountryDTO, CountriesIndexVM>), typeof(CountryVMFactory));
            Container.RegisterType(typeof(IVMFactory<CityDTO, CitiesIndexVM>), typeof(CitiesVMFactory));
            Container.RegisterType(typeof(IVMFactory<ProjectDTO, ProjectsIndexVM>), typeof(ProjectsVMFactory));
            Container.RegisterType(typeof(IVMFactory<StoreDTO, StoresIndexVM>), typeof(StoresVMFactory));
            Container.RegisterType(typeof(IVMFactory<IssueDTO, IssuesIndexVM>), typeof(IssuesVMFactory));
        }
    }
}