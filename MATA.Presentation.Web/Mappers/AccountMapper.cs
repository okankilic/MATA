using MATA.Data.DTO;
using MATA.Presentation.Web.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MATA.Presentation.Web.Mappers
{
    public class AccountMapper
    {
        public AccountEditViewModel MapToViewModel(AccountDTO dto)
        {
            return new AccountEditViewModel()
            {
                ID = dto.ID,
                FullName = dto.FullName,
                Email = dto.Email,
                RoleName = dto.RoleName
            };
        }

        public AccountDTO MapToDTO(AccountEditViewModel vm)
        {
            return new AccountDTO()
            {
                ID = vm.ID,
                FullName = vm.FullName,
                Email = vm.Email,
                Password = vm.Password,
                RoleName = vm.RoleName
            };
        }
    }
}