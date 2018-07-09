using MATA.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Interfaces
{
    public interface ISearchable<TDTO>
    {
        Task<IEnumerable<TDTO>> Search(string q, int skip, int take, IUnitOfWork uow);
    }
}
