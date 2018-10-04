using MATA.BL.Filters;
using MATA.BL.Interfaces;
using MATA.BL.Mappers;
using MATA.Data.Common.Constants;
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
        readonly ISeqNoBL seqNoBL;

        const string CacheKey = "IssueBL";

        public IssueBL(IMapper<Issue, vIssue, IssueDTO> mapper,
            ISeqNoBL seqNoBL)
        {
            this.mapper = mapper;
            this.seqNoBL = seqNoBL;
        }

        [CustomAuthorize(Roles = RoleTypes.Combines.AdminStaff)]
        [CustomCacheResetAttribute(CacheKey = CacheKey)]
        public int Create(IssueDTO issueDTO, string tokenString, IUnitOfWork uow)
        {
            var issue = mapper.MapToEntity(issueDTO);

            var seqNoPrefix = string.Format("{0}{1:yyyyMM}", SeqNoPrefixTypes.Issue, DateTime.UtcNow);

            issue.SeqNo = seqNoBL.Create(seqNoPrefix, uow);

            issue.IssueState = IssueStateTypes.WAITING.ToString();

            uow.IssueRepository.Create(issue);
            uow.SaveChanges(tokenString);

            return issue.ID;
        }

        [CustomAuthorize(Roles = RoleTypes.Combines.AdminStaff)]
        [CustomCacheResetAttribute(CacheKey = CacheKey)]
        public void Update(int id, IssueDTO issueDTO, string tokenString, IUnitOfWork uow)
        {
            var issue = uow.IssueRepository.GetByID(id);

            issue.Remarks = issueDTO.Remarks;

            uow.IssueRepository.Update(issue);
            uow.SaveChanges(tokenString);
        }

        [CustomAuthorize(Roles = RoleTypes.Combines.AdminStaff)]
        [CustomCacheResetAttribute(CacheKey = CacheKey)]
        public void Delete(int id, string tokenString, IUnitOfWork uow)
        {
            var issue = uow.IssueRepository.GetByID(id);

            uow.IssueRepository.Delete(issue);
            uow.SaveChanges(tokenString);
        }

        [CustomCache(CacheKey = CacheKey)]
        public IssueDTO Get(int id, IUnitOfWork uow)
        {
            var issue = uow.IssueRepository.GetViewByID(id);

            return mapper.MapToDTO(issue);
        }

        [CustomCache(CacheKey = CacheKey)]
        public int Count(IUnitOfWork uow)
        {
            return uow.IssueRepository.GetCount();
        }

        [CustomCache(CacheKey = CacheKey)]
        public async Task<IEnumerable<IssueDTO>> Search(string q, int skip, int take, IUnitOfWork uow)
        {
            var items = uow.IssueRepository.Find();

            if (!string.IsNullOrWhiteSpace(q))
            {
                items = items.Where(c => c.Description.Contains(q));
            }

            return await OrderIssues(items, skip, take);
        }

        [CustomCache(CacheKey = CacheKey)]
        public int GetCountryIssuesCount(int countryID, IUnitOfWork uow)
        {
            return uow.IssueRepository.Find().Count(q => q.CountryID == countryID);
        }

        [CustomCache(CacheKey = CacheKey)]
        public async Task<IEnumerable<IssueDTO>> GetCountryIssues(int countryID, int skip, int take, IUnitOfWork uow)
        {
            var items = uow.IssueRepository.Find(q => q.CountryID == countryID);

            return await OrderIssues(items, skip, take);
        }

        [CustomCache(CacheKey = CacheKey)]
        public int GetCityIssuesCount(int cityID, IUnitOfWork uow)
        {
            return uow.IssueRepository.Find().Count(q => q.CityID == cityID);
        }

        [CustomCache(CacheKey = CacheKey)]
        public async Task<IEnumerable<IssueDTO>> GetCityIssues(int cityID, int skip, int take, IUnitOfWork uow)
        {
            var items = uow.IssueRepository.Find(q => q.CityID == cityID);

            return await OrderIssues(items, skip, take);
        }

        [CustomCache(CacheKey = CacheKey)]
        public int GetProjectIssuesCount(int projectID, IUnitOfWork uow)
        {
            return uow.IssueRepository.Find().Count(q => q.ProjectID == projectID);
        }

        [CustomCache(CacheKey = CacheKey)]
        public async Task<IEnumerable<IssueDTO>> GetProjectIssues(int projectID, int skip, int take, IUnitOfWork uow)
        {
            var items = uow.IssueRepository.Find(q => q.ProjectID == projectID);

            return await OrderIssues(items, skip, take);
        }

        [CustomCache(CacheKey = CacheKey)]
        public int GetStoreIssuesCount(int storeID, IUnitOfWork uow)
        {
            return uow.IssueRepository.Find().Count(q => q.StoreID == storeID);
        }

        [CustomCache(CacheKey = CacheKey)]
        public async Task<IEnumerable<IssueDTO>> GetStoreIssues(int storeID, int skip, int take, IUnitOfWork uow)
        {
            var items = uow.IssueRepository.Find(q => q.StoreID == storeID);

            return await OrderIssues(items, skip, take);
        }

        private async Task<IEnumerable<IssueDTO>> OrderIssues(IQueryable<vIssue> items, int skip, int take)
        {
            var itemList = await items.OrderByDescending(q => q.RequestDate).ThenBy(q => q.ID).Skip(skip).Take(take).ToListAsync();

            return itemList.Select(q => mapper.MapToDTO(q));
        }
    }
}
