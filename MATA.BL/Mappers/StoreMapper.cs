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
                CityID = entity.CityID
            };
        }

        public StoreDTO MapToDTO(vStore view)
        {
            return new StoreDTO
            {
                ID = view.ID,
                Address = view.Address,
                CountryID = view.CountryID,
                CountryName = view.CountryName,
                CityID = view.CityID,
                CityName = view.CityName,
                ProjectID = view.ProjectID,
                ProjectName = view.ProjectName,
                StoreName = view.StoreName,
                CreatedByAccountID = view.CreatedByAccountID,
                CreatedBy = view.CreatedBy,
                CreateTime = view.CreateTime,
                UpdatedByAccountID = view.UpdatedByAccountID,
                UpdatedBy = view.UpdatedBy,
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
                ProjectID = dto.ProjectID,
                StoreName = dto.StoreName
            };
        }
    }
}
