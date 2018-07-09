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

        [Display(Name = "Ülke Adı")]
        public string CountryName { get; set; }
    }
}
