using MATA.BL.Filters;
using MATA.BL.Interfaces;
using MATA.BL.Mappers;
using MATA.Data.Common.Constants;
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
        private const string CacheKey = "AccountBL";

        private readonly IMapper<Account, vAccount, AccountDTO> mapper;

        public AccountBL(IMapper<Account, vAccount, AccountDTO> mapper)
        {
            this.mapper = mapper;
        }

        [CustomAuthorize(Roles = RoleTypes.Admin)]
        [CustomCacheResetAttribute(CacheKey = CacheKey)]
        public int Create(AccountDTO accountDTO, string tokenString, IUnitOfWork uow)
        {
            var account = mapper.MapToEntity(accountDTO);

            account.IsActive = true;
            account.UID = Guid.NewGuid();

            uow.AccountRepository.Create(account);
            uow.SaveChanges(tokenString);

            return account.ID;
        }

        [CustomCacheResetAttribute(CacheKey = CacheKey)]
        [CustomAuthorize(Roles = RoleTypes.Combines.Any)]
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

        [CustomAuthorize(Roles = RoleTypes.Admin)]
        [CustomCacheResetAttribute(CacheKey = CacheKey)]
        public void Delete(int id, string tokenString, IUnitOfWork uow)
        {
            var account = uow.AccountRepository.GetByID(id);

            account.IsActive = false;

            uow.AccountRepository.Update(account);
            uow.SaveChanges(tokenString);
        }

        [CustomCache(CacheKey = CacheKey)]
        public AccountDTO Get(int id, IUnitOfWork uow)
        {
            var account = uow.AccountRepository.GetViewByID(id);

            return mapper.MapToDTO(account);
        }

        [CustomCache(CacheKey = CacheKey)]
        public int Count(IUnitOfWork uow)
        {
            return uow.AccountRepository.GetCount();
        }

        [CustomCache(CacheKey = CacheKey)]
        public AccountDTO GetByToken(string tokenString, IUnitOfWork uow)
        {
            var tokenGuid = Guid.Parse(tokenString);
            var token = uow.TokenRepository.Find(q => q.TokenString == tokenGuid).Single();

            return Get(token.AccountID, uow);
        }

        [CustomCache(CacheKey = CacheKey)]
        public bool IsExists(string email, IUnitOfWork uow)
        {
            return uow.AccountRepository.Find(q => q.Email == email).Any();
        }

        [CustomCache(CacheKey = CacheKey)]
        public AccountDTO GetByEmailAndPassword(string email, string password, IUnitOfWork uow)
        {
            var account = uow.AccountRepository.Find().Single(q => q.Email == email && q.Password == password);

            return mapper.MapToDTO(account);
        }

        [CustomCache(CacheKey = CacheKey)]
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

        [CustomCache(CacheKey = CacheKey)]
        public int GetStoreAccountsCount(int storeID, IUnitOfWork uow)
        {
            return uow.StoreAccountRepository.GetCount(q => q.StoreID == storeID);
        }

        [CustomCache(CacheKey = CacheKey)]
        public async Task<IEnumerable<AccountDTO>> GetStoreAccounts(int storeID, int skip, int take, IUnitOfWork uow)
        {
            var accountIDs = uow.StoreAccountRepository.Find(q => q.StoreID == storeID).Select(q => q.AccountID);

            var items = from aID in accountIDs
                        join a in uow.AccountRepository.Find() on aID equals a.ID
                        select a;

            var itemList = await items.OrderBy(q => q.FullName).ThenBy(q => q.ID).ToListAsync();

            return itemList.Select(q => mapper.MapToDTO(q));
        }
    }
}
