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

        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Properties.Resources))]
        [Display(Name = "StoreName", ResourceType = typeof(Resources.Properties.Resources))]
        public string StoreName { get; set; }

        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Properties.Resources))]
        [Display(Name = "Project", ResourceType = typeof(Resources.Properties.Resources))]
        public int ProjectID { get; set; }

        [Display(Name = "Project", ResourceType = typeof(Resources.Properties.Resources))]
        public string ProjectName { get; set; }

        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Properties.Resources))]
        [Display(Name = "Address", ResourceType = typeof(Resources.Properties.Resources))]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Display(Name = "Country", ResourceType = typeof(Resources.Properties.Resources))]
        public int CountryID { get; set; }

        [Display(Name = "Country", ResourceType = typeof(Resources.Properties.Resources))]
        public string CountryName { get; set; }

        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Properties.Resources))]
        [Display(Name = "City", ResourceType = typeof(Resources.Properties.Resources))]
        public int CityID { get; set; }

        [Display(Name = "City", ResourceType = typeof(Resources.Properties.Resources))]
        public string CityName { get; set; }

        [Display(Name = "Accounts", ResourceType = typeof(Resources.Properties.Resources))]
        public IEnumerable<AccountDTO> Accounts { get; set; }

        [Display(Name = "Accounts", ResourceType = typeof(Resources.Properties.Resources))]
        public IList<int> AccountIDList { get; set; }
    }
}
