using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.DTO
{
    public class BackLogDTO
    {
        public int ID { get; set; }

        public int BrandID { get; set; }

        [Display(Name = "Mağaza")]
        public string BrandName { get; set; }

        [Display(Name = "Ülke")]
        public int CountyID { get; set; }

        public string CountryName { get; set; }

        [Display(Name = "Şehir")]
        public int CityID { get; set; }

        public string CityName { get; set; }

        [Display(Name = "İş Açıklaması")]
        public string Description { get; set; }

        [Display(Name = "Notlar")]
        public string Remarks { get; set; }
    }
}
