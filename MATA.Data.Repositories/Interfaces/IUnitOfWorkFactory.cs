using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.Repositories.Interfaces
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork CreateNew();
    }
}
