using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL
{
    public static class TokenBL
    {
        public static string Create(int accountID, MataDBEntities db)
        {
            var token = new Token()
            {
                AccountID = accountID,
                StartTime = DateTime.UtcNow,
                EndTime = DateTime.UtcNow.AddDays(1),
                TokenString = Guid.NewGuid()
            };

            db.Token.Add(token);
            db.SaveChanges();

            return token.TokenString.ToString();
        }

        public static string TryGet(int accountID, MataDBEntities db)
        {
            var token = db.Token.SingleOrDefault(q => q.AccountID == accountID && q.StartTime <= DateTime.UtcNow && q.EndTime >= DateTime.UtcNow);

            if (token != null)
                return token.TokenString.ToString();

            return null;
        }

        internal static int Get(string tokenString, MataDBEntities db)
        {
            var guid = Guid.Parse(tokenString);

            var token = db.Token.Single(q => q.TokenString == guid && q.StartTime <= DateTime.UtcNow && q.EndTime >= DateTime.UtcNow);

            return token.AccountID;
        }

        internal static void Delete(int accountID, MataDBEntities db)
        {
            db.Token.RemoveRange(db.Token.Where(q => q.AccountID == accountID));
            db.SaveChanges();
        }
    }
}
