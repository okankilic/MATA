using MATA.Data.Entities;
using MATA.Data.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MATA.Data.Repositories.Interfaces;

namespace MATA.BL.Interfaces
{
    public interface IProjectBL: IEntityBL<ProjectDTO>
    {
        Task<IEnumerable<ProjectDTO>> GetProjects(int skip, int take, IUnitOfWork uow);
    }
}
