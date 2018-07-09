using MATA.Data.DTO.Models;
using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Mappers
{
    public class ActionMapper : IMapper<Data.Entities.Action, vAction, ActionDTO>
    {
        public ActionDTO MapToDTO(Data.Entities.Action entity)
        {
            throw new NotImplementedException();
        }

        public ActionDTO MapToDTO(vAction view)
        {
            throw new NotImplementedException();
        }

        public Data.Entities.Action MapToEntity(ActionDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
