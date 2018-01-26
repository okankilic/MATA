using MATA.Data.DTO;
using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Mappers
{
    public class AccountMapper : IMapper<Account, AccountDTO>
    {
        public AccountDTO MapToDTO(Account entity)
        {
            return new AccountDTO()
            {
                ID = entity.ID,
                UserName = entity.UserName,
                Password = entity.Password,
                AccountName = entity.AccountName,
                BrandID = entity.BrandID,
                RoleName = entity.RoleName
            };
        }

        public Account MapToEntity(AccountDTO dto)
        {
            return new Account()
            {
                UserName = dto.UserName,
                Password = dto.Password,
                AccountName = dto.AccountName,
                RoleName = dto.RoleName,
                BrandID = dto.BrandID
            };
        }
    }
}
