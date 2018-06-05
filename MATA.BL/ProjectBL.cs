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
    public static class ProjectBL
    {
        public static int Create(ProjectDTO projectDTO, string tokenString, MataDBEntities db)
        {
            var accountID = TokenBL.GetAccountID(tokenString, db);

            projectDTO.CreatedByAccountID = accountID;
            projectDTO.CreateTime = DateTime.UtcNow;
            projectDTO.UpdatedByAccountID = accountID;
            projectDTO.UpdateTime = DateTime.UtcNow;

            var mapper = new ProjectMapper();

            var project = mapper.MapToEntity(projectDTO);

            db.Project.Add(project);
            db.SaveChanges();

            return project.ID;
        }

        public static void Update(int id, ProjectDTO projectDTO, string tokenString, MataDBEntities db)
        {
            var accountID = TokenBL.GetAccountID(tokenString, db);

            var project = db.Project.Single(q => q.ID == id);

            project.ProjectName = projectDTO.ProjectName;
            project.Remarks = projectDTO.Remarks;
            project.UpdatedByAccountID = accountID;
            project.UpdateTime = DateTime.UtcNow;

            db.SaveChanges();
        }

        public static ProjectDTO Get(int id, MataDBEntities dB)
        {
            var mapper = new ProjectMapper();

            var project = dB.vProject.Single(q => q.ID == id);

            return mapper.MapToDTO(project);
        }

        public static void Delete(int id, MataDBEntities db)
        {
            var project = db.Project.Single(q => q.ID == id);

            db.Project.Remove(project);

            db.SaveChanges();
        }

        public static int GetCount(MataDBEntities db)
        {
            return db.Project.Count();
        }

        public static IEnumerable<ProjectDTO> GetProjects(int skip, int take, MataDBEntities db)
        {
            var mapper = new ProjectMapper();

            var projects = db.vProject.OrderBy(q => q.ID).ThenBy(q => q.ProjectName);

            if (skip == 0 && take == 0)
            {
                return projects.ToList().Select(q => mapper.MapToDTO(q));
            }

            return projects.Skip(skip).Take(take).ToList().Select(q => mapper.MapToDTO(q));
        }
    }
}
