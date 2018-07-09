using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.Repositories.Impls
{
    public class IssueRepository : GenericRepository<Issue, vIssue>
    {
        public IssueRepository(MataDBEntities dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<vIssue>> GetIssues(int skip, int take)
        {
            var issueList = new List<vIssue>();

            var issues = dbSetView.OrderBy(q => q.ID).ThenBy(q => q.StoreName);

            if (skip == 0 && take == 0)
            {
                issueList = await issues.ToListAsync();
            }
            else
            {
                issueList = await issues.Skip(skip).Take(take).ToListAsync();
            }

            return issueList;
        }
    }
}
