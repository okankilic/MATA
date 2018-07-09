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
        public ProjectDTO MapToDTO(vProject view)
        {
            return new ProjectDTO
            {
                ID = view.ID,
                ProjectName = view.ProjectName,
                Remarks = view.Remarks,
                CreatedBy = view.CreatedBy,
                CreatedByAccountID = view.CreatedByAccountID,
                CreateTime = view.CreateTime,
                //IsDeleted = view.
                UpdatedBy = view.UpdatedBy,
                UpdatedByAccountID = view.UpdatedByAccountID,
                UpdateTime = view.UpdateTime
            };
        }

        public Project MapToEntity(ProjectDTO dto)
        {
            return new Project
            {
                ID = dto.ID,
                ProjectName = dto.ProjectName,
                Remarks = dto.Remarks
            };
        }
    }
}
