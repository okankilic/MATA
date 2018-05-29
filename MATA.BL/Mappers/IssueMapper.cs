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
                ID = entity.ID
            };
        }

        public IssueDTO MapToDTO(vIssue view)
        {
            return new IssueDTO
            {
                ID = view.ID
            };
        }

        public Issue MapToEntity(IssueDTO dto)
        {
            return new Issue
            {
                ID = dto.ID
            };
        }
    }
}
