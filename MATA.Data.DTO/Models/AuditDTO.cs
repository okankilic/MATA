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
        [Display(Name = "Oluşturan")]
        public int CreatedByAccountID { get; set; }

        [Display(Name = "Oluşturan")]
        public string CreatedBy { get; set; }

        [Display(Name = "Oluşturulma Zamanı")]
        public DateTime CreateTime { get; set; }

        [Display(Name = "Güncelleyen")]
        public int UpdatedByAccountID { get; set; }

        [Display(Name = "Güncelleyen")]
        public string UpdatedBy { get; set; }

        [Display(Name = "Güncelleme Zamanı")]
        public DateTime UpdateTime { get; set; }
    }
}
