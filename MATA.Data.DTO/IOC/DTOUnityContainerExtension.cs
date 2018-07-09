using MATA.Data.DTO.Impls;
using MATA.Data.DTO.Interfaces;
using MATA.Data.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Extension;

namespace MATA.Data.DTO.Ioc
{
    public class DTOUnityContainerExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType(typeof(IDTOFactory<AccountDTO>), typeof(AccountDTOFactory));
            Container.RegisterType(typeof(IDTOFactory<CountryDTO>), typeof(CountryDTOFactory));
            Container.RegisterType(typeof(IDTOFactory<CityDTO>), typeof(CityDTOFactory));
            Container.RegisterType(typeof(IDTOFactory<ProjectDTO>), typeof(ProjectDTOFactory));
            Container.RegisterType(typeof(IDTOFactory<StoreDTO>), typeof(StoreDTOFactory));
            Container.RegisterType(typeof(IDTOFactory<IssueDTO>), typeof(IssueDTOFactory));
        }
    }
}
