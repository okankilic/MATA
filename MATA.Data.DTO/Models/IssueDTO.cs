using MATA.Data.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.DTO.Models
{
    public class IssueDTO: AuditDTO
    {
        public int ID { get; set; }

        [Display(Name = "SeqNo", ResourceType = typeof(Resources.Properties.Resources))]
        public string SeqNo { get; set; }

        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Properties.Resources))]
        [Display(Name = "Description", ResourceType = typeof(Resources.Properties.Resources))]
        public string Description { get; set; }
        
        [Display(Name = "IssueState", ResourceType = typeof(Resources.Properties.Resources))]
        public string IssueState { get; set; }

        [Display(Name = "Remarks", ResourceType = typeof(Resources.Properties.Resources))]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Properties.Resources))]
        [Display(Name = "RequestDate", ResourceType = typeof(Resources.Properties.Resources))]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime RequestDate { get; set; }

        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Properties.Resources))]
        [Display(Name = "RequestedByFullName", ResourceType = typeof(Resources.Properties.Resources))]
        public string RequestedByFullName { get; set; }

        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Properties.Resources))]
        [Display(Name = "SourceType", ResourceType = typeof(Resources.Properties.Resources))]
        public IssueSourceTypes SourceType { get; set; }

        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Properties.Resources))]
        [Display(Name = "Store", ResourceType = typeof(Resources.Properties.Resources))]
        public int StoreID { get; set; }

        [Display(Name = "Store", ResourceType = typeof(Resources.Properties.Resources))]
        public string StoreName { get; set; }

        [Display(Name = "Project", ResourceType = typeof(Resources.Properties.Resources))]
        public int ProjectID { get; set; }

        [Display(Name = "Project", ResourceType = typeof(Resources.Properties.Resources))]
        public string ProjectName { get; set; }

        [Display(Name = "Country", ResourceType = typeof(Resources.Properties.Resources))]
        public int CountryID { get; set; }

        [Display(Name = "Country", ResourceType = typeof(Resources.Properties.Resources))]
        public string CountryName { get; set; }

        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Properties.Resources))]
        [Display(Name = "City", ResourceType = typeof(Resources.Properties.Resources))]
        public int CityID { get; set; }

        [Display(Name = "City", ResourceType = typeof(Resources.Properties.Resources))]
        public string CityName { get; set; }
    }
}
