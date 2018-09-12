using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.DTO.Models
{
    public class CityDTO
    {
        public int ID { get; set; }

        [Display(Name = "CityName", ResourceType = typeof(Resources.Properties.Resources))]
        public string CityName { get; set; }

        [Display(Name = "Country", ResourceType = typeof(Resources.Properties.Resources))]
        public int CountryID { get; set; }

        [Display(Name = "Country", ResourceType = typeof(Resources.Properties.Resources))]
        public string CountryName { get; set; }
    }
}
