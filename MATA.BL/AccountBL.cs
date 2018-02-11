using MATA.BL.Mappers;
using MATA.Data.DTO;
using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL
{
    public static class AccountBL
    {
        public static int Create(AccountDTO accountDTO, MataDBEntities db)
        {
            var mapper = new AccountMapper();

            var account = mapper.MapToEntity(accountDTO);

            db.Account.Add(account);
            db.SaveChanges();

            return account.ID;
        }

        public static void Update(int id, AccountDTO accountDTO, MataDBEntities db)
        {
            throw new NotImplementedException();
        }

        public static void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public static AccountDTO Get(int id, MataDBEntities db)
        {
            var account = db.Account.Single(q => q.ID == id);

            var mapper = new AccountMapper();

            return mapper.MapToDTO(account);
        }

        public static bool IsAccountExists(AccountDTO adminAccount, MataDBEntities db)
        {
            return db.Account.Any(q => q.Email == adminAccount.Email && q.Password == adminAccount.Password);
        }

        public static AccountDTO Get(string email, string password, MataDBEntities db)
        {
            var account = db.Account.Single(q => q.Email == email && q.Password == password);

            var mapper = new AccountMapper();

            return mapper.MapToDTO(account);
        }

        public static AccountDTO Get(string tokenString, MataDBEntities db)
        {
            var accountID = TokenBL.Get(tokenString, db);

            return Get(accountID, db);
        }
    }
}
