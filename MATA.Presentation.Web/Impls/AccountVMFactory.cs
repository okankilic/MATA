using MATA.BL.Interfaces;
using MATA.Data.DTO.Interfaces;
using MATA.Data.DTO.Models;
using MATA.Data.Repositories.Interfaces;
using MATA.Presentation.Web.Interfaces;
using MATA.Presentation.Web.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Impls
{
    public class AccountVMFactory : IVMFactory<AccountDTO, AccountsIndexVM>
    {
        readonly IAccountBL accountBL;
        readonly IDTOFactory<AccountDTO> dtoFactory;

        public AccountVMFactory(IAccountBL accountBL,
            IDTOFactory<AccountDTO> dtoFactory)
        {
            this.accountBL = accountBL;
            this.dtoFactory = dtoFactory;
        }

        public async Task<AccountsIndexVM> CreateNewIndexVMAsync(int page, int pageSize, IUnitOfWork uow)
        {
            return new AccountsIndexVM
            {
                PageSize = pageSize,
                TotalCount = accountBL.Count(uow),
                Accounts = await accountBL.GetAccounts((page - 1) * pageSize, pageSize, uow)
            };
        }
    }
}