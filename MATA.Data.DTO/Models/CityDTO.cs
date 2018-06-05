using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.DTO.Models
{
    public class CityDTO
    {
        public int ID { get; set; }

        public string CityName { get; set; }

        public int CountryID { get; set; }

        public string CountryName { get; set; }
    }
}
