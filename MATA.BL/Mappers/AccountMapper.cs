using MATA.Data.DTO;
using MATA.Data.DTO.Models;
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
                PhoneNumber = entity.PhoneNumber,
                Password = entity.Password,
                RoleName = entity.RoleName,
                IsActive = entity.IsActive
            };
        }

        public AccountDTO MapToDTO(vAccount view)
        {
            return new AccountDTO()
            {
                ID = view.ID,
                FullName = view.FullName,
                Email = view.Email,
                PhoneNumber = view.PhoneNumber,
                //Password = view.Password,
                RoleName = view.RoleName,
                IsActive = view.IsActive
            };
        }

        public Account MapToEntity(AccountDTO dto)
        {
            return new Account()
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Password = dto.Password,
                RoleName = dto.RoleName,
                IsActive = dto.IsActive
            };
        }
    }
}
