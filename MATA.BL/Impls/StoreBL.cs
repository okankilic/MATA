using MATA.BL.Interfaces;
using MATA.BL.Mappers;
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
        readonly IMapper<Store, vStore, StoreDTO> mapper;

        public StoreBL(IMapper<Store, vStore, StoreDTO> mapper)
        {
            this.mapper = mapper;
        }

        public async Task<IEnumerable<StoreDTO>> GetStores(int skip, int take, IUnitOfWork uow)
        {
            var storeList = await uow.StoreRepository.GetStores(skip, take);

            return storeList.Select(q => mapper.MapToDTO(q));
        }

        public int GetProjectStoreCount(int projectID, IUnitOfWork uow)
        {
            return uow.StoreRepository.Find(q => q.ProjectID == projectID).Count();
        }

        public IEnumerable<StoreDTO> GetProjectStores(int projectID, int skip, int take, IUnitOfWork uow)
        {
            return uow.StoreRepository.GetProjectStores(projectID, skip, take).Select(q => mapper.MapToDTO(q));
        }

        public int Create(StoreDTO dto, string tokenString, IUnitOfWork uow)
        {
            var store = mapper.MapToEntity(dto);

            uow.StoreRepository.Create(store);
            uow.SaveChanges(tokenString);

            return store.ID;
        }

        public void Update(int id, StoreDTO dto, string tokenString, IUnitOfWork uow)
        {
            var store = uow.StoreRepository.GetByID(id);

            //store.ProjectID = dto.ProjectID;
            //store.CityID = dto.CityID;
            store.StoreName = dto.StoreName;
            store.Address = dto.Address;

            uow.StoreRepository.Update(store);
            uow.SaveChanges(tokenString);
        }

        public void Delete(int id, string tokenString, IUnitOfWork uow)
        {
            var store = uow.StoreRepository.GetByID(id);

            uow.StoreRepository.Delete(store);
            uow.SaveChanges(tokenString);
        }

        public StoreDTO Get(int id, IUnitOfWork uow)
        {
            var store = uow.StoreRepository.GetViewByID(id);

            return mapper.MapToDTO(store);
        }

        public int Count(IUnitOfWork uow)
        {
            return uow.StoreRepository.GetCount();
        }

        public async Task<IEnumerable<StoreDTO>> Search(string q, int skip, int take, IUnitOfWork uow)
        {
            var items = uow.StoreRepository.Find();

            if (!string.IsNullOrWhiteSpace(q))
            {
                items = items.Where(c => c.StoreName.Contains(q));
            }

            var itemList = await items.OrderBy(c => c.StoreName).ThenBy(c => c.ID).Skip(skip).Take(take).ToListAsync();

            return itemList.Select(c => mapper.MapToDTO(c));
        }
    }
}
