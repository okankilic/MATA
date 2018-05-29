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
    public static class IssueBL
    {
        public static int Create(IssueDTO issueDTO, MataDBEntities db)
        {
            var mapper = new IssueMapper();

            var issue = mapper.MapToEntity(issueDTO);

            db.Issue.Add(issue);

            db.SaveChanges();

            return issue.ID;
        }

        public static void Update(int id, IssueDTO issueDTO, MataDBEntities db)
        {
            var issue = db.Issue.Single(q => q.ID == id);

            db.SaveChanges();
        }

        public static void Delete(int id, MataDBEntities db)
        {
            var issue = db.Issue.Single(q => q.ID == id);

            db.Issue.Remove(issue);
            db.SaveChanges();
        }

        public static IEnumerable<IssueDTO> GetIssues(int skip, int take, MataDBEntities db)
        {
            var mapper = new IssueMapper();

            return db.vIssue.Skip(skip).Take(take).ToList().Select(q => mapper.MapToDTO(q));
        }

        public static IEnumerable<IssueDTO> GetStoreIssues(int storeID, int skip, int take, MataDBEntities db)
        {
            var mapper = new IssueMapper();

            return db.vIssue.Where(q => q.StoreID == storeID).Skip(skip).Take(take).ToList().Select(q => mapper.MapToDTO(q));
        }

        public static IEnumerable<IssueDTO> GetProjectIssues(int projectID, int skip, int take, MataDBEntities db)
        {
            var mapper = new IssueMapper();

            return db.vIssue.Where(q => q.ProjectID == projectID).Skip(skip).Take(take).ToList().Select(q => mapper.MapToDTO(q));
        }
    }
}
