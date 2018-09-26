using MATA.BL.Filters;
using MATA.BL.Interfaces;
using MATA.BL.Mappers;
using MATA.Data.Common.Constants;
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
        private const string CacheKey = "ProjectBL";

        readonly IMapper<Project, vProject, ProjectDTO> mapper;

        public ProjectBL(IMapper<Project, vProject, ProjectDTO> mapper)
        {
            this.mapper = mapper;
        }

        [CustomAuthorize(Roles = RoleTypes.Combines.AdminStaff)]
        [CustomCacheResetAttribute(CacheKey = CacheKey)]
        public int Create(ProjectDTO projectDTO, string tokenString, IUnitOfWork uow)
        {
            var project = mapper.MapToEntity(projectDTO);

            uow.ProjectRepository.Create(project);
            uow.SaveChanges(tokenString);

            return project.ID;
        }

        [CustomAuthorize(Roles = RoleTypes.Combines.AdminStaff)]
        [CustomCacheResetAttribute(CacheKey = CacheKey)]
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

        [CustomCache(CacheKey = CacheKey)]
        public ProjectDTO Get(int id, IUnitOfWork uow)
        {
            var project = uow.ProjectRepository.GetViewByID(id);

            return mapper.MapToDTO(project);
        }

        [CustomAuthorize(Roles = RoleTypes.Combines.AdminStaff)]
        [CustomCacheResetAttribute(CacheKey = CacheKey)]
        public void Delete(int id, string tokenString, IUnitOfWork uow)
        {
            var project = uow.ProjectRepository.GetByID(id);

            uow.ProjectRepository.Delete(project);
            uow.SaveChanges(tokenString);

            //uow.ActionRepository.Create(ActionTypes.DELETE, typeof(Project).Name, project.ID, tokenString);
            //uow.SaveChanges();
        }

        [CustomCache(CacheKey = CacheKey)]
        public int Count(IUnitOfWork uow)
        {
            return uow.ProjectRepository.GetCount();
        }

        [CustomCache(CacheKey = CacheKey)]
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

        [CustomCache(CacheKey = CacheKey)]
        public int GetCountryProjectsCount(int countryID, IUnitOfWork uow)
        {
            var projectIDs = uow.StoreRepository.Find(q => q.CountryID == countryID).Select(q => q.ProjectID).Distinct();

            var projects = (from projectID in projectIDs
                             join project in uow.ProjectRepository.Find() on projectID equals project.ID
                             select project);

            return projects.Count();
        }

        public async Task<IEnumerable<ProjectDTO>> GetCountryProjects(int countryID, int skip, int take, IUnitOfWork uow)
        {
            var projectIDs = uow.StoreRepository.Find(q => q.CountryID == countryID).Select(q => q.ProjectID).Distinct();

            var projectList = await (from projectID in projectIDs
                            join project in uow.ProjectRepository.Find() on projectID equals project.ID
                            orderby project.ProjectName
                            select project).Skip(skip).Take(take).ToListAsync();

            return projectList.Select(q => mapper.MapToDTO(q));
        }

        public int GetCityProjectsCount(int cityID, IUnitOfWork uow)
        {
            var projectIDs = uow.StoreRepository.Find(q => q.CityID == cityID).Select(q => q.ProjectID).Distinct();

            var projects = (from projectID in projectIDs
                            join project in uow.ProjectRepository.Find() on projectID equals project.ID
                            select project);

            return projects.Count();
        }

        public async Task<IEnumerable<ProjectDTO>> GetCityProjects(int cityID, int skip, int take, IUnitOfWork uow)
        {
            var projectIDs = uow.StoreRepository.Find(q => q.CityID == cityID).Select(q => q.ProjectID).Distinct();

            var projectList = await (from projectID in projectIDs
                                     join project in uow.ProjectRepository.Find() on projectID equals project.ID
                                     orderby project.ProjectName
                                     select project).Skip(skip).Take(take).ToListAsync();

            return projectList.Select(q => mapper.MapToDTO(q));
        }
    }
}
