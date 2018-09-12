using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.DTO.Models
{
    public class CountryDTO
    {
        public int ID { get; set; }

        [Display(Name = "CountryName", ResourceType = typeof(Resources.Properties.Resources))]
        public string CountryName { get; set; }
    }
}
