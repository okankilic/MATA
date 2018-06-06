using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.DTO.Models
{
    public class ProjectDTO
    {
        public int ID { get; set; }

        [Display(Name = "Ülke")]
        [Required]
        public int CountryID { get; set; }

        [Display(Name = "Ülke")]
        public string CountryName { get; set; }

        [Display(Name = "Proje")]
        [Required]
        public string ProjectName { get; set; }

        [Display(Name = "Açıklamalar")]
        public string Remarks { get; set; }

        public int CreatedByAccountID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateTime { get; set; }
        public int UpdatedByAccountID { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
