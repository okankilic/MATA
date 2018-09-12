using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.DTO.Models
{
    public class StoreAccountDTO
    {
        public int ID { get; set; }

        [Display(Name = "Store", ResourceType = typeof(Resources.Properties.Resources))]
        public int StoreID { get; set; }

        [Display(Name = "Store", ResourceType = typeof(Resources.Properties.Resources))]
        public string StoreName { get; set; }

        [Display(Name = "Account", ResourceType = typeof(Resources.Properties.Resources))]
        public int AccountID { get; set; }

        [Display(Name = "FullName", ResourceType = typeof(Resources.Properties.Resources))]
        public string FullName { get; set; }
    }
}
