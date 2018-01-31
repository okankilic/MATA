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
                Email = entity.Email,
                Password = entity.Password,
                BrandID = entity.BrandID,
                RoleName = entity.RoleName
            };
        }

        public Account MapToEntity(AccountDTO dto)
        {
            return new Account()
            {
                Email = dto.Email,
                Password = dto.Password,
                RoleName = dto.RoleName,
                BrandID = dto.BrandID
            };
        }
    }
}
