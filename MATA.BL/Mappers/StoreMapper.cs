using MATA.Data.DTO.Models;
using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Mappers
{
    public class StoreMapper : IMapper<Store, vStore, StoreDTO>
    {
        public StoreDTO MapToDTO(Store entity)
        {
            return new StoreDTO
            {
                ID = entity.ID,
                Address = entity.Address,
                CityID = entity.CityID,
                //CreatedBy = entity.CreatedBy,
                CreatedByAccountID = entity.CreatedByAccountID,
                CreateTime = entity.CreateTime,
                ProjectID = entity.ProjectID,
                //ProjectName = entity.ProjectName,
                StoreName = entity.StoreName,
                //UpdatedBy = entity.UpdatedBy,
                UpdatedByAccountID = entity.UpdatedByAccountID,
                UpdateTime = entity.UpdateTime
            };
        }

        public StoreDTO MapToDTO(vStore view)
        {
            return new StoreDTO
            {
                ID = view.ID,
                Address = view.Address,
                CityID = view.CityID,
                CreatedBy = view.CreatedBy,
                CreatedByAccountID = view.CreatedByAccountID,
                CreateTime = view.CreateTime,
                ProjectID = view.ProjectID,
                ProjectName = view.ProjectName,
                StoreName = view.StoreName,
                UpdatedBy = view.UpdatedBy,
                UpdatedByAccountID = view.UpdatedByAccountID,
                UpdateTime = view.UpdateTime
            };
        }

        public Store MapToEntity(StoreDTO dto)
        {
            return new Store
            {
                ID = dto.ID,
                Address = dto.Address,
                CityID = dto.CityID,
                CreatedByAccountID = dto.CreatedByAccountID,
                CreateTime = dto.CreateTime,
                ProjectID = dto.ProjectID,
                StoreName = dto.StoreName,
                UpdatedByAccountID = dto.UpdatedByAccountID,
                UpdateTime = dto.UpdateTime
            };
        }
    }
}
