using MATA.BL.Interfaces;
using MATA.BL.Mappers;
using MATA.Data.DTO;
using MATA.Data.DTO.Models;
using MATA.Data.Entities;
using MATA.Data.Repositories.Interfaces;
using MATA.Infrastructure.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Impls
{
    public class AccountBL: IAccountBL
    {
        private readonly IMapper<Account, vAccount, AccountDTO> mapper;

        public AccountBL(IMapper<Account, vAccount, AccountDTO> mapper)
        {
            this.mapper = mapper;
        }

        public int Create(AccountDTO accountDTO, string tokenString, IUnitOfWork uow)
        {
            var account = mapper.MapToEntity(accountDTO);

            account.IsActive = true;
            account.UID = Guid.NewGuid();

            uow.AccountRepository.Create(account);
            uow.SaveChanges(tokenString);

            return account.ID;
        }

        public void Update(int id, AccountDTO accountDTO, string tokenString, IUnitOfWork uow)
        {
            var account = uow.AccountRepository.GetByID(id);

            if(accountDTO.ExPassword != account.Password)
            {
                throw new BusinessException("Eski şifrenizi kontrol ederek tekrar deneyiniz.");
            }

            account.FullName = accountDTO.FullName;
            account.Email = accountDTO.Email;
            account.Password = accountDTO.Password;
            account.RoleName = accountDTO.RoleName;

            uow.AccountRepository.Update(account);

            uow.SaveChanges(tokenString);
        }

        public void Delete(int id, string tokenString, IUnitOfWork uow)
        {
            var account = uow.AccountRepository.GetByID(id);

            account.IsActive = false;

            uow.AccountRepository.Update(account);
            uow.SaveChanges(tokenString);
        }

        public AccountDTO Get(int id, IUnitOfWork uow)
        {
            var account = uow.AccountRepository.GetViewByID(id);

            return mapper.MapToDTO(account);
        }

        public int Count(IUnitOfWork uow)
        {
            return uow.AccountRepository.GetCount();
        }

        public async Task<IEnumerable<AccountDTO>> GetAccounts(int skip, int take, IUnitOfWork uow)
        {
            var accountList = await uow.AccountRepository.GetAccounts(skip, take);

            return accountList.Select(q => mapper.MapToDTO(q));
        }

        public AccountDTO GetByToken(string tokenString, IUnitOfWork uow)
        {
            var tokenGuid = Guid.Parse(tokenString);
            var token = uow.TokenRepository.Find(q => q.TokenString == tokenGuid).Single();

            return Get(token.AccountID, uow);
        }

        public bool IsExists(string email, IUnitOfWork uow)
        {
            return uow.AccountRepository.Find(q => q.Email == email).Any();
        }

        public AccountDTO GetByEmailAndPassword(string email, string password, IUnitOfWork uow)
        {
            var account = uow.AccountRepository.Find().Single(q => q.Email == email && q.Password == password);

            return mapper.MapToDTO(account);
        }

        public async Task<IEnumerable<AccountDTO>> Search(string q, int skip, int take, IUnitOfWork uow)
        {
            var items = uow.AccountRepository.Find();

            if (!string.IsNullOrWhiteSpace(q))
            {
                items = items.Where(c => c.FullName.Contains(q));
            }

            var itemList = await items.OrderBy(c => c.FullName).ThenBy(c => c.ID).Skip(skip).Take(take).ToListAsync();

            return itemList.Select(c => mapper.MapToDTO(c));
        }
    }
}
