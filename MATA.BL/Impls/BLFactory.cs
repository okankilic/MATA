using MATA.BL.Interfaces;
using MATA.BL.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace MATA.BL.Impls
{
    public class BLFactory: IBLFactory
    {
        readonly IUnityContainer container;

        public BLFactory(IUnityContainer container)
        {
            this.container = container;
        }

        public T Create<T>()
        {
            return container.Resolve<T>();
        }

        public T CreateProxy<T>()
        {
            var bl = Create<T>();

            return BLProxy<T>.Create(bl);
        }
    }
}
