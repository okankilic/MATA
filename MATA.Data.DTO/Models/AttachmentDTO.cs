using MATA.Data.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.DTO.Models
{
    public class AttachmentDTO: AuditDTO
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "AttachmentType", ResourceType = typeof(Resources.Properties.Resources))]
        public AttachmentTypes AttachmentType { get; set; }

        [Required]
        [Display(Name = "EntityName", ResourceType = typeof(Resources.Properties.Resources))]
        public string EntityName { get; set; }

        [Required]
        public int EntityID { get; set; }

        [Display(Name = "FileName", ResourceType = typeof(Resources.Properties.Resources))]
        public string FileName { get; set; }

        [Display(Name = "FilePath", ResourceType = typeof(Resources.Properties.Resources))]
        public string FilePath { get; set; }
    }
}
