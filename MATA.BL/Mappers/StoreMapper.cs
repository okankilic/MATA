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
                ID = entity.ID
            };
        }

        public StoreDTO MapToDTO(vStore view)
        {
            return new StoreDTO
            {
                ID = view.ID
            };
        }

        public Store MapToEntity(StoreDTO dto)
        {
            return new Store
            {
                ID = dto.ID
            };
        }
    }
}
