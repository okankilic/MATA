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
    public interface IProjectBL : IEntityBL<ProjectDTO>
    {
        int GetCountryProjectsCount(int countryID, IUnitOfWork uow);

        Task<IEnumerable<ProjectDTO>> GetCountryProjects(int countryID, int skip, int take, IUnitOfWork uow);

        int GetCityProjectsCount(int cityID, IUnitOfWork uow);

        Task<IEnumerable<ProjectDTO>> GetCityProjects(int cityID, int skip, int take, IUnitOfWork uow);
    }
}
