using MATA.Data.DTO;
using MATA.Data.DTO.Models;
using MATA.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Interfaces
{
    public interface IAccountBL: IEntityBL<AccountDTO>
    {
        bool IsExists(string email, IUnitOfWork uow);
        AccountDTO GetByEmailAndPassword(string email, string password, IUnitOfWork uow);
        AccountDTO GetByToken(string tokenString, IUnitOfWork uow);
        Task<IEnumerable<AccountDTO>> GetAccounts(int skip, int take, IUnitOfWork uow);
    }
}
