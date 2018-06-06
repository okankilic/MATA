using MATA.Data.DTO.Models;
using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Interfaces
{
    public interface IProjectBL: IEntityBL<ProjectDTO>
    {
        IEnumerable<ProjectDTO> GetProjects(int skip, int take, MataDBEntities db);
        IEnumerable<ProjectDTO> GetProjects(int countryID, int skip, int take, MataDBEntities db);
    }
}
