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
        public AttachmentTypes AttachmentType { get; set; }

        [Required]
        public string EntityName { get; set; }

        [Required]
        public int EntityID { get; set; }
        
        public string FileName { get; set; }

        public string FilePath { get; set; }
    }
}
