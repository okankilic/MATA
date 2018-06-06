using MATA.BL.Interfaces;
using MATA.BL.Mappers;
using MATA.Data.DTO.Models;
using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL
{
    public class StoreBL: IStoreBL
    {
        readonly IMapper<Store, vStore, StoreDTO> mapper;

        public StoreBL(IMapper<Store, vStore, StoreDTO> mapper)
        {
            this.mapper = mapper;
        }

        public int Create(StoreDTO storeDTO, string tokenString, MataDBEntities db)
        {
            var accountID = TokenBL.GetAccountID(tokenString, db);

            storeDTO.CreatedByAccountID = accountID;
            storeDTO.CreateTime = DateTime.UtcNow;
            storeDTO.UpdatedByAccountID = accountID;
            storeDTO.UpdateTime = DateTime.UtcNow;

            var store = mapper.MapToEntity(storeDTO);

            db.Store.Add(store);
            db.SaveChanges();

            return store.ID;
        }

        public void Update(int id, StoreDTO storeDTO, string tokenString, MataDBEntities db)
        {
            var accountID = TokenBL.GetAccountID(tokenString, db);

            var store = db.Store.Single(q => q.ID == id);

            storeDTO.UpdatedByAccountID = accountID;
            storeDTO.UpdateTime = DateTime.UtcNow;

            db.SaveChanges();
        }

        public void Delete(int id, MataDBEntities db)
        {
            var store = db.Store.Single(q => q.ID == id);

            db.Store.Remove(store);
            db.SaveChanges();
        }

        public StoreDTO Get(int id, MataDBEntities db)
        {
            var store = db.vStore.Single(q => q.ID == id);

            return mapper.MapToDTO(store);
        }

        public int Count(MataDBEntities db)
        {
            return db.Store.Count();
        }

        public IEnumerable<StoreDTO> GetStores(int skip, int take, MataDBEntities db)
        {
            return db.Store.OrderBy(q => q.ID).ThenBy(q => q.StoreName).Skip(skip).Take(take).ToList().Select(q => mapper.MapToDTO(q));
        }

        public int GetProjectStoreCount(int projectID, MataDBEntities db)
        {
            return db.Store.Count(q => q.ProjectID == projectID);
        }

        public IEnumerable<StoreDTO> GetProjectStores(int projectID, int skip, int take, MataDBEntities db)
        {
            return db.vStore.Where(q => q.ProjectID == projectID).OrderBy(q => q.ID).ThenBy(q => q.ProjectName).Skip(skip).Take(take).ToList().Select(q => mapper.MapToDTO(q));
        }
    }
}
