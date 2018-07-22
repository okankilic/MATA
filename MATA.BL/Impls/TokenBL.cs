using MATA.BL.Interfaces;
using MATA.Data.Entities;
using MATA.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Impls
{
    public class TokenBL: ITokenBL
    {
        public string Create(int accountID, IUnitOfWork uow)
        {
            var token = new Token()
            {
                AccountID = accountID,
                StartTime = DateTime.UtcNow,
                EndTime = DateTime.UtcNow.AddDays(1),
                TokenString = Guid.NewGuid()
            };

            uow.TokenRepository.Create(token);
            uow.SaveChanges(null);

            return token.TokenString.ToString();
        }
    }
}
