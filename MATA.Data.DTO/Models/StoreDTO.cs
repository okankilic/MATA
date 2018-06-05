using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.DTO.Models
{
    public class StoreDTO
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Şantiye Adı")]
        public string StoreName { get; set; }

        [Required]
        public int ProjectID { get; set; }

        public string ProjectName { get; set; }

        public string Address { get; set; }

        [Required]
        public int CityID { get; set; }

        public int CreatedByAccountID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateTime { get; set; }
        public int UpdatedByAccountID { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
