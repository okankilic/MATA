using MATA.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Interfaces
{
    public interface IVMFactory<TDTO, TIndexVM>
    {
        Task<TIndexVM> CreateNewIndexVMAsync(int page, int pageSize, IUnitOfWork uow);
    }
}
