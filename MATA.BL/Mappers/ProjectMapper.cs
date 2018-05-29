using MATA.Data.DTO.Models;
using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Mappers
{
    public class ProjectMapper : IMapper<Project, vProject, ProjectDTO>
    {
        public ProjectDTO MapToDTO(Project entity)
        {
            return new ProjectDTO
            {
                ID = entity.ID,
                ProjectName = entity.ProjectName
            };
        }

        public ProjectDTO MapToDTO(vProject view)
        {
            return new ProjectDTO
            {
                ID = view.ID,
                ProjectName = view.ProjectName
            };
        }

        public Project MapToEntity(ProjectDTO dto)
        {
            return new Project
            {
                ID = dto.ID,
                ProjectName = dto.ProjectName
            };
        }
    }
}
