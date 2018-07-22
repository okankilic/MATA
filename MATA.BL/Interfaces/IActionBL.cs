using MATA.Data.DTO.Models;
using MATA.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Interfaces
{
    public interface IActionBL: IEntityBL<ActionDTO>, ISearchable<ActionDTO>
    {
        int GetAccountActionsCount(int accountID, IUnitOfWork uow);

        Task<IEnumerable<ActionDTO>> GetAccountActions(int accountID, int skip, int take, IUnitOfWork uow);
    }
}
