using MATA.Data.DTO;
using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Mappers
{
    public class AccountMapper : IMapper<Account, vAccount, AccountDTO>
    {
        public AccountDTO MapToDTO(Account entity)
        {
            return new AccountDTO()
            {
                ID = entity.ID,
                FullName = entity.FullName,
                Email = entity.Email,
                Password = entity.Password,
                RoleName = entity.RoleName
            };
        }

        public AccountDTO MapToDTO(vAccount view)
        {
            return new AccountDTO()
            {
                ID = view.ID,
                FullName = view.FullName,
                Email = view.Email,
                //Password = view.Password,
                RoleName = view.RoleName
            };
        }

        public Account MapToEntity(AccountDTO dto)
        {
            return new Account()
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Password = dto.Password,
                RoleName = dto.RoleName
            };
        }
    }
}
