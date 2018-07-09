using MATA.Data.DTO.Models;
using MATA.Data.Entities;
using MATA.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Interfaces
{
    public interface IIssueBL : IEntityBL<IssueDTO>
    {
        Task<IEnumerable<IssueDTO>> GetIssues(int skip, int take, IUnitOfWork uow);
        int GetStoreIssueCount(int storeID, IUnitOfWork uow);
        IEnumerable<IssueDTO> GetStoreIssues(int storeID, int skip, int take, IUnitOfWork uow);
        int GetProjectIssueCount(int projectID, IUnitOfWork uow);
        IEnumerable<IssueDTO> GetProjectIssues(int projectID, int skip, int take, IUnitOfWork uow);
    }
}
