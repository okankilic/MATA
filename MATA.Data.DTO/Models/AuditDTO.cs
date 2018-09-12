using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.DTO.Models
{
    public abstract class AuditDTO
    {
        [Display(Name = "CreatedBy", ResourceType = typeof(Resources.Properties.Resources))]
        public int CreatedByAccountID { get; set; }

        [Display(Name = "CreatedBy", ResourceType = typeof(Resources.Properties.Resources))]
        public string CreatedBy { get; set; }

        [Display(Name = "CreateTime", ResourceType = typeof(Resources.Properties.Resources))]
        public DateTime CreateTime { get; set; }
        
        [Display(Name = "UpdatedBy", ResourceType = typeof(Resources.Properties.Resources))]
        public int UpdatedByAccountID { get; set; }

        [Display(Name = "UpdatedBy", ResourceType = typeof(Resources.Properties.Resources))]
        public string UpdatedBy { get; set; }
        
        [Display(Name = "UpdateTime", ResourceType = typeof(Resources.Properties.Resources))]
        public DateTime UpdateTime { get; set; }
    }
}
