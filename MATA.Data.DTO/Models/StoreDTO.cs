using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.DTO.Models
{
    public class StoreDTO: AuditDTO
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Şantiye Adı")]
        public string StoreName { get; set; }

        [Required]
        [Display(Name = "Proje")]
        public int ProjectID { get; set; }

        [Display(Name = "Proje")]
        public string ProjectName { get; set; }

        [Required]
        [Display(Name = "Adres"), DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Display(Name = "Ülke")]
        public int CountryID { get; set; }

        [Display(Name = "Ülke")]
        public string CountryName { get; set; }

        [Required]
        [Display(Name = "Şehir")]
        public int CityID { get; set; }

        [Display(Name = "Şehir")]
        public string CityName { get; set; }
    }
}
