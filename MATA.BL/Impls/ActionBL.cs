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
    public class ActionBL : IActionBL
    {
        readonly IMapper<Data.Entities.Action, vAction, ActionDTO> mapper;

        public ActionBL(IMapper<Data.Entities.Action, vAction, ActionDTO> mapper)
        {
            this.mapper = mapper;
        }

        public int Count(IUnitOfWork uow)
        {
            throw new NotImplementedException();
        }

        public int Create(ActionDTO dto, string tokenString, IUnitOfWork uow)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id, string tokenString, IUnitOfWork uow)
        {
            throw new NotImplementedException();
        }

        public ActionDTO Get(int id, IUnitOfWork uow)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, ActionDTO dto, string tokenString, IUnitOfWork uow)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ActionDTO>> Search(string q, int skip, int take, IUnitOfWork uow)
        {
            var items = uow.ActionRepository.Find();

            if (!string.IsNullOrWhiteSpace(q))
            {
                items = items.Where(c => c.FullName.Contains(q));
            }

            var itemList = await items.OrderBy(c => c.FullName).ThenBy(c => c.ID).Skip(skip).Take(take).ToListAsync();

            return itemList.Select(c => mapper.MapToDTO(c));
        }
    }
}
