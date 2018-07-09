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

        [Required]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Display(Name = "Durum")]
        public string IssueState { get; set; }

        [Display(Name = "Notlar"), DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        [Required]
        [Display(Name = "Talep Zamanı")]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd")]
        [DataType(DataType.Date)]
        public DateTime RequestDate { get; set; }

        [Display(Name = "Talep Eden")]
        public string RequestedByFullName { get; set; }

        [Required]
        [Display(Name = "Talep Kaynağı")]
        public IssueSourceTypes SourceType { get; set; }

        [Required]
        [Display(Name = "Şantiye")]
        public int StoreID { get; set; }

        [Display(Name = "Şantiye")]
        public string StoreName { get; set; }

        [Display(Name = "Proje")]
        public int ProjectID { get; set; }

        [Display(Name = "Proje")]
        public string ProjectName { get; set; }

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
