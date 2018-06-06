using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Presentation.Web.Interfaces
{
    public interface IVMFactory<TIndexVM>
    {
        TIndexVM CreateIndexVM(int page, int pageSize, MataDBEntities db);
    }
}
