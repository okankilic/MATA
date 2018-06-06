using MATA.BL.Interfaces;
using MATA.BL.Mappers;
using MATA.Data.DTO.IOC;
using MATA.Data.DTO.Models;
using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Extension;

namespace MATA.BL.IOC
{
    public class BLUnityContainerExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.AddNewExtension<DTOUnityContainerExtension>();
            
            Container.RegisterType(typeof(IMapper<Country, vCountry, CountryDTO>), typeof(CountryMapper));
            Container.RegisterType<IEntityBL<CountryDTO>, ICountryBL>();
            Container.RegisterType<ICountryBL, CountryBL>();

            Container.RegisterType(typeof(IMapper<City, vCity, CityDTO>), typeof(CityMapper));
            Container.RegisterType<IEntityBL<CityDTO>, ICityBL>();
            Container.RegisterType<ICityBL, CityBL>();
            
            Container.RegisterType(typeof(IMapper<Project, vProject, ProjectDTO>), typeof(ProjectMapper));
            Container.RegisterType<IEntityBL<ProjectDTO>, IProjectBL>();
            Container.RegisterType<IProjectBL, ProjectBL>();

            Container.RegisterType(typeof(IMapper<Store, vStore, StoreDTO>), typeof(StoreMapper));
            Container.RegisterType<IEntityBL<StoreDTO>, IStoreBL>();
            Container.RegisterType<IStoreBL, StoreBL>();
        }
    }
}
