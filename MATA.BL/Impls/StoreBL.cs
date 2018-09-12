using MATA.BL.Filters;
using MATA.BL.Interfaces;
using MATA.BL.Mappers;
using MATA.Data.Common.Constants;
using MATA.Data.DTO.Models;
using MATA.Data.Entities;
using MATA.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Impls
{
    public class StoreBL: IStoreBL
    {
        private const string CacheKey = "StoreBL";

        readonly IMapper<Store, vStore, StoreDTO> mapper;

        public StoreBL(IMapper<Store, vStore, StoreDTO> mapper)
        {
            this.mapper = mapper;
        }

        [CustomCache(CacheKey = CacheKey)]
        public async Task<IEnumerable<StoreDTO>> GetStores(int skip, int take, IUnitOfWork uow)
        {
            var storeList = await uow.StoreRepository.GetStores(skip, take);

            return storeList.Select(q => mapper.MapToDTO(q));
        }

        [CustomAuthorize(Roles = RoleTypes.Combines.AdminStaff)]
        [CustomCacheResetAttribute(CacheKey = CacheKey)]
        public int Create(StoreDTO dto, string tokenString, IUnitOfWork uow)
        {
            var store = mapper.MapToEntity(dto);

            uow.StoreRepository.Create(store);
            uow.SaveChanges(tokenString);

            foreach (var accountID in dto.AccountIDList)
            {
                uow.StoreAccountRepository.Create(new StoreAccount
                {
                    StoreID = store.ID,
                    AccountID = accountID
                });
            }

            uow.SaveChanges(tokenString);

            return store.ID;
        }

        [CustomAuthorize(Roles = RoleTypes.Combines.AdminStaff)]
        [CustomCacheResetAttribute(CacheKey = CacheKey)]
        public void Update(int id, StoreDTO dto, string tokenString, IUnitOfWork uow)
        {
            var store = uow.StoreRepository.GetByID(id);
            
            store.StoreName = dto.StoreName;
            store.Address = dto.Address;

            uow.StoreRepository.Update(store);
            uow.SaveChanges(tokenString);

            var exAccountList = uow.StoreAccountRepository.GetStoreAccountList(id);
            var exAccountIDList = exAccountList.Select(q => q.AccountID);

            foreach (var accountID in dto.AccountIDList.Except(exAccountIDList))
            {
                uow.StoreAccountRepository.Create(new StoreAccount
                {
                    StoreID = store.ID,
                    AccountID = accountID
                });
            }

            foreach (var accountID in exAccountIDList.Except(dto.AccountIDList))
            {
                var storeAccount = exAccountList.Single(q => q.AccountID == accountID);
                uow.StoreAccountRepository.Delete(storeAccount);
            }

            uow.SaveChanges(tokenString);
        }

        [CustomAuthorize(Roles = RoleTypes.Combines.AdminStaff)]
        [CustomCacheResetAttribute(CacheKey = CacheKey)]
        public void Delete(int id, string tokenString, IUnitOfWork uow)
        {
            var store = uow.StoreRepository.GetByID(id);

            uow.StoreRepository.Delete(store);

            var storeAccountList = uow.StoreAccountRepository.GetStoreAccountList(id);
            foreach (var storeAccount in storeAccountList)
            {
                uow.StoreAccountRepository.Delete(storeAccount);
            }

            uow.SaveChanges(tokenString);
        }

        [CustomCache(CacheKey = CacheKey)]
        public StoreDTO Get(int id, IUnitOfWork uow)
        {
            var store = uow.StoreRepository.GetViewByID(id);

            var dto = mapper.MapToDTO(store);

            dto.AccountIDList = uow.StoreAccountRepository.GetStoreAccountIDList(id);

            return dto;
        }

        [CustomCache(CacheKey = CacheKey)]
        public int Count(IUnitOfWork uow)
        {
            return uow.StoreRepository.GetCount();
        }

        [CustomCache(CacheKey = CacheKey)]
        public async Task<IEnumerable<StoreDTO>> Search(string q, int skip, int take, IUnitOfWork uow)
        {
            var items = uow.StoreRepository.Find();

            if (!string.IsNullOrWhiteSpace(q))
            {
                items = items.Where(c => c.StoreName.Contains(q));
            }

            return await OrderStores(items, skip, take);
        }

        [CustomCache(CacheKey = CacheKey)]
        public int GetCountryStoresCount(int countryID, IUnitOfWork uow)
        {
            return uow.StoreRepository.Find(q => q.CountryID == countryID).Count();
        }

        [CustomCache(CacheKey = CacheKey)]
        public async Task<IEnumerable<StoreDTO>> GetCountryStores(int countryID, int skip, int take, IUnitOfWork uow)
        {
            var items = uow.StoreRepository.Find(q => q.CountryID == countryID);

            return await OrderStores(items, skip, take);
        }

        [CustomCache(CacheKey = CacheKey)]
        public int GetCityStoresCount(int cityID, IUnitOfWork uow)
        {
            return uow.StoreRepository.Find(q => q.CityID == cityID).Count();
        }

        [CustomCache(CacheKey = CacheKey)]
        public async Task<IEnumerable<StoreDTO>> GetCityStores(int cityID, int skip, int take, IUnitOfWork uow)
        {
            var items = uow.StoreRepository.Find(q => q.CityID == cityID);

            return await OrderStores(items, skip, take);
        }

        [CustomCache(CacheKey = CacheKey)]
        public int GetProjectStoreCount(int projectID, IUnitOfWork uow)
        {
            return uow.StoreRepository.Find(q => q.ProjectID == projectID).Count();
        }

        [CustomCache(CacheKey = CacheKey)]
        public async Task<IEnumerable<StoreDTO>> GetProjectStores(int projectID, int skip, int take, IUnitOfWork uow)
        {
            var items = uow.StoreRepository.Find(q => q.ProjectID == projectID);

            return await OrderStores(items, skip, take);
        }

        private async Task<IEnumerable<StoreDTO>> OrderStores(IQueryable<vStore> items, int skip, int take)
        {
            var itemList = await items.OrderBy(q => q.StoreName).ThenBy(q => q.ID).Skip(skip).Take(take).ToListAsync();

            return itemList.Select(q => mapper.MapToDTO(q));
        }
    }
}
