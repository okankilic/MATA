using MATA.BL.Interfaces;
using MATA.BL.Mappers;
using MATA.Data.DTO.Models;
using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL
{
    public class IssueBL: IEntityBL<IssueDTO>
    {
        readonly IMapper<Issue, vIssue, IssueDTO> mapper;

        public IssueBL(IMapper<Issue, vIssue, IssueDTO> mapper)
        {
            this.mapper = mapper;
        }

        public int Create(IssueDTO issueDTO, string tokenString, MataDBEntities db)
        {
            var issue = mapper.MapToEntity(issueDTO);

            db.Issue.Add(issue);

            db.SaveChanges();

            return issue.ID;
        }

        public void Update(int id, IssueDTO issueDTO, string tokenString, MataDBEntities db)
        {
            var issue = db.Issue.Single(q => q.ID == id);

            db.SaveChanges();
        }

        public void Delete(int id, MataDBEntities db)
        {
            var issue = db.Issue.Single(q => q.ID == id);

            db.Issue.Remove(issue);
            db.SaveChanges();
        }

        public IssueDTO Get(int id, MataDBEntities db)
        {
            var issue = db.vIssue.Single(q => q.ID == id);

            return mapper.MapToDTO(issue);
        }

        public IEnumerable<IssueDTO> GetIssues(int skip, int take, MataDBEntities db)
        {
            return db.vIssue.Skip(skip).Take(take).ToList().Select(q => mapper.MapToDTO(q));
        }

        public IEnumerable<IssueDTO> GetStoreIssues(int storeID, int skip, int take, MataDBEntities db)
        {
            return db.vIssue.Where(q => q.StoreID == storeID).Skip(skip).Take(take).ToList().Select(q => mapper.MapToDTO(q));
        }

        public int GetProjectIssueCount(int projectID, MataDBEntities db)
        {
            return db.vIssue.Count(q => q.ProjectID == projectID);
        }

        public IEnumerable<IssueDTO> GetProjectIssues(int projectID, int skip, int take, MataDBEntities db)
        {
            return db.vIssue.Where(q => q.ProjectID == projectID).OrderBy(q => q.ID).ThenBy(q => q.ProjectID).Skip(skip).Take(take).ToList().Select(q => mapper.MapToDTO(q));
        }

        public int Count(MataDBEntities db)
        {
            return db.Issue.Count();
        }
    }
}
