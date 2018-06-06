using MATA.BL.Interfaces;
using MATA.BL.Mappers;
using MATA.Data.DTO.Models;
using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL
{
    public class ProjectBL: IProjectBL
    {
        readonly IMapper<Project, vProject, ProjectDTO> mapper;

        public ProjectBL(IMapper<Project, vProject, ProjectDTO> mapper)
        {
            this.mapper = mapper;
        }

        public int Create(ProjectDTO projectDTO, string tokenString, MataDBEntities db)
        {
            var accountID = TokenBL.GetAccountID(tokenString, db);

            projectDTO.CreatedByAccountID = accountID;
            projectDTO.CreateTime = DateTime.UtcNow;
            projectDTO.UpdatedByAccountID = accountID;
            projectDTO.UpdateTime = DateTime.UtcNow;

            var project = mapper.MapToEntity(projectDTO);

            db.Project.Add(project);
            db.SaveChanges();

            return project.ID;
        }

        public void Update(int id, ProjectDTO projectDTO, string tokenString, MataDBEntities db)
        {
            var accountID = TokenBL.GetAccountID(tokenString, db);

            var project = db.Project.Single(q => q.ID == id);

            project.CountryID = projectDTO.CountryID;
            project.ProjectName = projectDTO.ProjectName;
            project.Remarks = projectDTO.Remarks;
            project.UpdatedByAccountID = accountID;
            project.UpdateTime = DateTime.UtcNow;

            db.SaveChanges();
        }

        public ProjectDTO Get(int id, MataDBEntities dB)
        {
            var project = dB.vProject.Single(q => q.ID == id);

            return mapper.MapToDTO(project);
        }

        public void Delete(int id, MataDBEntities db)
        {
            var project = db.Project.Single(q => q.ID == id);

            db.Project.Remove(project);

            db.SaveChanges();
        }

        public int Count(MataDBEntities db)
        {
            return db.Project.Count();
        }

        public IEnumerable<ProjectDTO> GetProjects(int skip, int take, MataDBEntities db)
        {
            var projects = db.vProject.OrderBy(q => q.CountryName).ThenBy(q => q.ProjectName).ThenBy(q => q.ID);

            if (skip == 0 && take == 0)
            {
                return projects.ToList().Select(q => mapper.MapToDTO(q));
            }

            return projects.Skip(skip).Take(take).ToList().Select(q => mapper.MapToDTO(q));
        }

        public IEnumerable<ProjectDTO> GetProjects(int countryID, int skip, int take, MataDBEntities db)
        {
            var projects = db.vProject.Where(q => q.CountryID == countryID).OrderBy(q => q.CountryName).ThenBy(q => q.ProjectName).ThenBy(q => q.ID);

            if (skip == 0 && take == 0)
            {
                return projects.ToList().Select(q => mapper.MapToDTO(q));
            }

            return projects.Skip(skip).Take(take).ToList().Select(q => mapper.MapToDTO(q));
        }
    }
}
