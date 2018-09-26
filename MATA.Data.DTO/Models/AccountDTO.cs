using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.DTO.Models
{
    public class AccountDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Properties.Resources))]
        [MaxLength(50)]
        [MinLength(4)]
        [DataType(DataType.Text)]
        [Display(Name = "FullName", ResourceType = typeof(Resources.Properties.Resources))]
        public string FullName { get; set; }

        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Properties.Resources))]
        [MaxLength(100)]
        [MinLength(4)]
        [Display(Name = "Email", ResourceType = typeof(Resources.Properties.Resources))]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.Properties.Resources))]
        public string Email { get; set; }

        [MinLength(10)]
        [MaxLength(10)]
        [Phone]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "PhoneNumber", ResourceType = typeof(Resources.Properties.Resources))]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Properties.Resources))]
        [MaxLength(8)]
        [MinLength(3)]
        [Display(Name = "ExPassword", ResourceType = typeof(Resources.Properties.Resources))]
        public string ExPassword { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Properties.Resources))]
        [MaxLength(8)]
        [MinLength(3)]
        [Display(Name = "Password", ResourceType = typeof(Resources.Properties.Resources))]
        public string Password { get; set; }

        [Required(ErrorMessageResourceName = "ErrorMessageRequired", ErrorMessageResourceType = typeof(Resources.Properties.Resources))]
        [MaxLength(8), MinLength(3), DataType(DataType.Password), Compare("Password")]
        [Display(Name = "RePassword", ResourceType = typeof(Resources.Properties.Resources))]
        public string RePassword { get; set; }

        [Display(Name = "RoleName", ResourceType = typeof(Resources.Properties.Resources))]
        public string RoleName { get; set; }

        [Display(Name = "IsActive", ResourceType = typeof(Resources.Properties.Resources))]
        public bool IsActive { get; set; }
    }
}
