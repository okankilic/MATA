using MATA.Data.Common.Enums;
using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.Repositories.Impls
{
    public class ActionRepository : GenericRepository<Entities.Action, vAction>
    {
        public ActionRepository(MataDBEntities dbContext) : base(dbContext)
        {
        }

        public void Create(int accountID, ActionTypes actionType, string entityName, int entityID)
        {
            var action = new Entities.Action
            {
                AccountID = accountID,
                ActionType = actionType.ToString(),
                EntityName = entityName,
                EntityID = entityID,
                ActionTime = DateTime.UtcNow
            };

            base.Create(action);
        }
    }
}
