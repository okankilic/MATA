using MATA.Data.Common.Enums;
using MATA.Data.DTO.Models;
using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Mappers
{
    public class IssueMapper : IMapper<Issue, vIssue, IssueDTO>
    {
        public IssueDTO MapToDTO(Issue entity)
        {
            return new IssueDTO
            {
                ID = entity.ID,
                //CityID = entity.CityID,
                //CityName = entity.CityName,
                //CountryID = entity.CountryID,
                //CountryName = entity.CountryName,
                //CreatedBy = entity.CreatedBy,
                CreatedByAccountID = entity.CreatedByAccountID,
                CreateTime = entity.CreateTime,
                Description = entity.Description,
                IssueState = entity.IssueState,
                //ProjectID = entity.ProjectID,
                //ProjectName = entity.ProjectName,
                Remarks = entity.Remarks,
                RequestDate = entity.RequestDate,
                RequestedByFullName = entity.RequestedByFullName,
                SourceType = (IssueSourceTypes)Enum.Parse(typeof(IssueSourceTypes), entity.SourceType, false),
                StoreID = entity.StoreID,
                //StoreName = entity.StoreName,
                //UpdatedBy = entity.UpdatedBy,
                UpdatedByAccountID = entity.UpdatedByAccountID,
                UpdateTime = entity.UpdateTime
            };
        }

        public IssueDTO MapToDTO(vIssue view)
        {
            return new IssueDTO
            {
                ID = view.ID,
                CityID = view.CityID,
                CityName = view.CityName,
                CountryID = view.CountryID,
                CountryName = view.CountryName,
                CreatedBy = view.CreatedBy,
                CreatedByAccountID = view.CreatedByAccountID,
                CreateTime = view.CreateTime,
                Description = view.Description,
                IssueState = view.IssueState,
                ProjectID = view.ProjectID,
                ProjectName = view.ProjectName,
                Remarks = view.Remarks,
                RequestDate = view.RequestDate,
                RequestedByFullName = view.RequestedByFullName,
                SourceType = (IssueSourceTypes)Enum.Parse(typeof(IssueSourceTypes), view.SourceType, false),
                StoreID = view.StoreID,
                StoreName = view.StoreName,
                UpdatedBy = view.UpdatedBy,
                UpdatedByAccountID = view.UpdatedByAccountID,
                UpdateTime = view.UpdateTime
            };
        }

        public Issue MapToEntity(IssueDTO dto)
        {
            return new Issue
            {
                Description = dto.Description,
                StoreID = dto.StoreID,
                RequestedByFullName = dto.RequestedByFullName,
                RequestDate = dto.RequestDate,
                SourceType = dto.SourceType.ToString(),
                Remarks = dto.Remarks
            };
        }
    }
}
