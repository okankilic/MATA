using MATA.BL.Interfaces;
using MATA.BL.Mappers;
using MATA.Data.Common.Enums;
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
    public class ProjectBL: IProjectBL
    {
        readonly IMapper<Project, vProject, ProjectDTO> mapper;

        public ProjectBL(IMapper<Project, vProject, ProjectDTO> mapper)
        {
            this.mapper = mapper;
        }

        public int Create(ProjectDTO projectDTO, string tokenString, IUnitOfWork uow)
        {
            var project = mapper.MapToEntity(projectDTO);

            uow.ProjectRepository.Create(project);
            uow.SaveChanges(tokenString);

            return project.ID;
        }

        public void Update(int id, ProjectDTO projectDTO, string tokenString, IUnitOfWork uow)
        {
            var project = uow.ProjectRepository.GetByID(id);
            
            project.ProjectName = projectDTO.ProjectName;
            project.Remarks = projectDTO.Remarks;

            uow.ProjectRepository.Update(project);
            uow.SaveChanges(tokenString);

            //uow.ActionRepository.Create(ActionTypes.UPDATE, typeof(Project).Name, project.ID, tokenString);
            //uow.SaveChanges();
        }

        public ProjectDTO Get(int id, IUnitOfWork uow)
        {
            var project = uow.ProjectRepository.GetViewByID(id);

            return mapper.MapToDTO(project);
        }

        public void Delete(int id, string tokenString, IUnitOfWork uow)
        {
            var project = uow.ProjectRepository.GetByID(id);

            uow.ProjectRepository.Delete(project);
            uow.SaveChanges(tokenString);

            //uow.ActionRepository.Create(ActionTypes.DELETE, typeof(Project).Name, project.ID, tokenString);
            //uow.SaveChanges();
        }

        public async Task<IEnumerable<ProjectDTO>> GetProjects(int skip, int take, IUnitOfWork uow)
        {
            var projectList = new List<vProject>();

            var projects = uow.ProjectRepository.Find().OrderBy(q => q.ProjectName).ThenBy(q => q.ID);

            if (skip == 0 && take == 0)
            {
                projectList = await projects.ToListAsync();
            }
            else
            {
                projectList = await projects.Skip(skip).Take(take).ToListAsync();
            }

            return projectList.Select(q => mapper.MapToDTO(q));
        }

        public int Count(IUnitOfWork uow)
        {
            return uow.ProjectRepository.GetCount();
        }

        public async Task<IEnumerable<ProjectDTO>> Search(string q, int skip, int take, IUnitOfWork uow)
        {
            var items = uow.ProjectRepository.Find();

            if (!string.IsNullOrWhiteSpace(q))
            {
                items = items.Where(c => c.ProjectName.Contains(q));
            }

            var itemList = await items.OrderBy(c => c.ProjectName).ThenBy(c => c.ID).Skip(skip).Take(take).ToListAsync();

            return itemList.Select(c => mapper.MapToDTO(c));
        }
    }
}
