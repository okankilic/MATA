using MATA.BL.Interfaces;
using MATA.Data.DTO.Interfaces;
using MATA.Data.DTO.Models;
using MATA.Data.Repositories.Interfaces;
using MATA.Presentation.Web.Interfaces;
using MATA.Presentation.Web.Models.Issues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MATA.Presentation.Web.Impls
{
    public class IssuesVMFactory : IVMFactory<IssueDTO, IssuesIndexVM>
    {
        readonly IIssueBL issueBL;
        readonly IStoreBL storeBL;
        readonly IDTOFactory<IssueDTO> dtoFactory;

        public IssuesVMFactory(IDTOFactory<IssueDTO> dtoFactory,
            IBLFactory blFactory)
        {
            this.issueBL = blFactory.CreateProxy<IIssueBL>();
            this.storeBL = blFactory.CreateProxy<IStoreBL>();
            this.dtoFactory = dtoFactory;
        }

        public async Task<IssuesIndexVM> CreateNewIndexVMAsync(int page, int pageSize, IUnitOfWork uow)
        {
            return new IssuesIndexVM
            {
                PageSize = pageSize,
                TotalCount = issueBL.Count(uow),
                Issues = await issueBL.Search(null, (page - 1) * pageSize, pageSize, uow)
            };
        }
    }
}