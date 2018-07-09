using MATA.BL.Interfaces;
using MATA.BL.Mappers;
using MATA.Data.Common.Enums;
using MATA.Data.DTO.Models;
using MATA.Data.Entities;
using MATA.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Impls
{
    public class IssueBL: IIssueBL
    {
        readonly IMapper<Issue, vIssue, IssueDTO> mapper;

        public IssueBL(IMapper<Issue, vIssue, IssueDTO> mapper)
        {
            this.mapper = mapper;
        }

        public int Create(IssueDTO issueDTO, string tokenString, IUnitOfWork uow)
        {
            var issue = mapper.MapToEntity(issueDTO);

            issue.IssueState = IssueStateTypes.WAITING.ToString();

            uow.IssueRepository.Create(issue);
            uow.SaveChanges(tokenString);

            return issue.ID;
        }

        public void Update(int id, IssueDTO issueDTO, string tokenString, IUnitOfWork uow)
        {
            var issue = uow.IssueRepository.GetByID(id);

            issue.Remarks = issueDTO.Remarks;

            uow.IssueRepository.Update(issue);
            uow.SaveChanges(tokenString);
        }

        public void Delete(int id, string tokenString, IUnitOfWork uow)
        {
            var issue = uow.IssueRepository.GetByID(id);

            uow.IssueRepository.Delete(issue);
            uow.SaveChanges(tokenString);
        }

        public IssueDTO Get(int id, IUnitOfWork uow)
        {
            var issue = uow.IssueRepository.GetViewByID(id);

            return mapper.MapToDTO(issue);
        }

        public int Count(IUnitOfWork uow)
        {
            return uow.IssueRepository.GetCount();
        }

        public async Task<IEnumerable<IssueDTO>> GetIssues(int skip, int take, IUnitOfWork uow)
        {
            var issueList = await uow.IssueRepository.GetIssues(skip, take);

            return issueList.Select(q => mapper.MapToDTO(q));
        }

        public int GetStoreIssueCount(int storeID, IUnitOfWork uow)
        {
            return uow.IssueRepository.Find().Count(q => q.StoreID == storeID);
        }

        public IEnumerable<IssueDTO> GetStoreIssues(int storeID, int skip, int take, IUnitOfWork uow)
        {
            return uow.IssueRepository.Find(q => q.StoreID == storeID).Skip(skip).Take(take).ToList().Select(q => mapper.MapToDTO(q));
        }

        public int GetProjectIssueCount(int projectID, IUnitOfWork uow)
        {
            return uow.IssueRepository.Find().Count(q => q.ProjectID == projectID);
        }

        public IEnumerable<IssueDTO> GetProjectIssues(int projectID, int skip, int take, IUnitOfWork uow)
        {
            return uow.IssueRepository.Find(q => q.ProjectID == projectID).OrderBy(q => q.ID).ThenBy(q => q.ProjectID).Skip(skip).Take(take).ToList().Select(q => mapper.MapToDTO(q));
        }

        public async Task<IEnumerable<IssueDTO>> Search(string q, int skip, int take, IUnitOfWork uow)
        {
            var items = uow.IssueRepository.Find();

            if (!string.IsNullOrWhiteSpace(q))
            {
                items = items.Where(c => c.Description.Contains(q));
            }

            var itemList = await items.OrderBy(c => c.Description).ThenBy(c => c.ID).Skip(skip).Take(take).ToListAsync();

            return itemList.Select(c => mapper.MapToDTO(c));
        }
    }
}
