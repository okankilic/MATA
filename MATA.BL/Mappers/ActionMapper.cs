using MATA.BL.Interfaces;
using MATA.Data.Common.Enums;
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
            return new ActionDTO
            {
                AccountID = entity.AccountID,
                ActionTime = entity.ActionTime,
                ActionType = (ActionTypes)Enum.Parse(typeof(ActionTypes), entity.ActionType),
                EntityID = entity.EntityID,
                EntityName = entity.EntityName,
                //FullName = entity.FullName
            };
        }

        public ActionDTO MapToDTO(vAction view)
        {
            return new ActionDTO
            {
                AccountID = view.AccountID,
                ActionTime = view.ActionTime,
                ActionType = (ActionTypes)Enum.Parse(typeof(ActionTypes), view.ActionType),
                EntityID = view.EntityID,
                EntityName = view.EntityName,
                FullName = view.FullName
            };
        }

        public Data.Entities.Action MapToEntity(ActionDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
