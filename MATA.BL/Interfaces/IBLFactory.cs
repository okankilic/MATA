using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Interfaces
{
    public interface IBLFactory
    {
        //T Create<T>();

        T CreateProxy<T>();
    }
}
