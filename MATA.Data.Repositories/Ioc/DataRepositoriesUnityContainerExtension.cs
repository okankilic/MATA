using MATA.Data.Repositories.Impls;
using MATA.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Extension;

namespace MATA.Data.Repositories.Ioc
{
    public class DataRepositoriesUnityContainerExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IUnitOfWork, UnitOfWork>();
            Container.RegisterType<IUnitOfWorkFactory, UnitOfWorkFactory>();
        }
    }
}
