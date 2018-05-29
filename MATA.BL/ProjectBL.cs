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
        public static int Create(ProjectDTO projectDTO, MataDBEntities db)
        {
            var mapper = new ProjectMapper();

            var project = mapper.MapToEntity(projectDTO);

            db.Project.Add(project);
            db.SaveChanges();

            return project.ID;
        }

        public static void Update(int id, ProjectDTO projectDTO, MataDBEntities db)
        {
            var project = db.Project.Single(q => q.ID == id);

            project.ProjectName = projectDTO.ProjectName;

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

        public static IEnumerable<ProjectDTO> GetProjects(int skip, int take, MataDBEntities db)
        {
            var mapper = new ProjectMapper();

            return db.vProject.Skip(skip).Take(take).ToList().Select(q => mapper.MapToDTO(q));
        }
    }
}
