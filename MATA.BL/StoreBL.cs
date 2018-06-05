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
    public static class StoreBL
    {
        public static int Create(StoreDTO storeDTO, string tokenString, MataDBEntities db)
        {
            var accountID = TokenBL.GetAccountID(tokenString, db);

            storeDTO.CreatedByAccountID = accountID;
            storeDTO.CreateTime = DateTime.UtcNow;
            storeDTO.UpdatedByAccountID = accountID;
            storeDTO.UpdateTime = DateTime.UtcNow;

            var mapper = new StoreMapper();

            var store = mapper.MapToEntity(storeDTO);

            db.Store.Add(store);
            db.SaveChanges();

            return store.ID;
        }

        public static void Update(int id, StoreDTO storeDTO, MataDBEntities db)
        {
            var store = db.Store.Single(q => q.ID == id);

            db.SaveChanges();
        }

        public static void Delete(int id, MataDBEntities db)
        {
            var store = db.Store.Single(q => q.ID == id);

            db.Store.Remove(store);
            db.SaveChanges();
        }

        public static int GetStoreCount(MataDBEntities db)
        {
            return db.Store.Count();
        }

        public static IEnumerable<StoreDTO> GetStores(int skip, int take, MataDBEntities db)
        {
            var mapper = new StoreMapper();

            return db.Store.OrderBy(q => q.ID).ThenBy(q => q.StoreName).Skip(skip).Take(take).ToList().Select(q => mapper.MapToDTO(q));
        }

        public static int GetProjectStoreCount(int projectID, MataDBEntities db)
        {
            return db.Store.Count(q => q.ProjectID == projectID);
        }

        public static IEnumerable<StoreDTO> GetProjectStores(int projectID, int skip, int take, MataDBEntities db)
        {
            var mapper = new StoreMapper();

            return db.vStore.Where(q => q.ProjectID == projectID).OrderBy(q => q.ID).ThenBy(q => q.ProjectName).Skip(skip).Take(take).ToList().Select(q => mapper.MapToDTO(q));
        }
    }
}
