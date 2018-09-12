using MATA.Data.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.DTO.Models
{
    public class ProjectDTO : AuditDTO, IDeletable
    {
        public int ID { get; set; }

        [Display(Name = "ProjectName", ResourceType = typeof(Resources.Properties.Resources))]
        [Required]
        public string ProjectName { get; set; }

        [Display(Name = "Remarks", ResourceType = typeof(Resources.Properties.Resources))]
        public string Remarks { get; set; }

        public bool IsDeleted { get; set; }
    }
}
