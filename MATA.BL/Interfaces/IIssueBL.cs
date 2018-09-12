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

        int GetCountryIssuesCount(int countryID, IUnitOfWork uow);

        Task<IEnumerable<IssueDTO>> GetCountryIssues(int countryID, int skip, int take, IUnitOfWork uow);

        int GetCityIssuesCount(int cityID, IUnitOfWork uow);

        Task<IEnumerable<IssueDTO>> GetCityIssues(int cityID, int skip, int take, IUnitOfWork uow);

        int GetProjectIssuesCount(int projectID, IUnitOfWork uow);

        Task<IEnumerable<IssueDTO>> GetProjectIssues(int projectID, int skip, int take, IUnitOfWork uow);

        int GetStoreIssuesCount(int storeID, IUnitOfWork uow);

        Task<IEnumerable<IssueDTO>> GetStoreIssues(int storeID, int skip, int take, IUnitOfWork uow);
    }
}
