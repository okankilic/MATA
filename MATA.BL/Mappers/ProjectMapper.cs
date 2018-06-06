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
                CountryID = entity.CountryID,
                //CountryName = entity.CountryName,
                ProjectName = entity.ProjectName,
                Remarks = entity.Remarks,
                CreatedByAccountID = entity.CreatedByAccountID,
                //CreatedBy = entity.CreatedBy,
                CreateTime = entity.CreateTime,
                UpdatedByAccountID = entity.UpdatedByAccountID,
                //UpdatedBy = entity.UpdatedBy,
                UpdateTime = entity.UpdateTime
            };
        }

        public ProjectDTO MapToDTO(vProject view)
        {
            return new ProjectDTO
            {
                ID = view.ID,
                CountryID = view.CountryID,
                CountryName = view.CountryName,
                ProjectName = view.ProjectName,
                Remarks = view.Remarks,
                CreatedByAccountID = view.CreatedByAccountID,
                CreatedBy = view.CreatedBy,
                CreateTime = view.CreateTime,
                UpdatedByAccountID = view.UpdatedByAccountID,
                UpdatedBy = view.UpdatedBy,
                UpdateTime = view.UpdateTime
            };
        }

        public Project MapToEntity(ProjectDTO dto)
        {
            return new Project
            {
                ID = dto.ID,
                CountryID = dto.CountryID,
                ProjectName = dto.ProjectName,
                Remarks = dto.Remarks,
                CreatedByAccountID = dto.CreatedByAccountID,
                CreateTime = dto.CreateTime,
                UpdatedByAccountID = dto.UpdatedByAccountID,
                UpdateTime = dto.UpdateTime
            };
        }
    }
}
