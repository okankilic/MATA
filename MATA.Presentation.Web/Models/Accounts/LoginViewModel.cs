using MATA.Data.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MATA.Presentation.Web.Models.Accounts
{
    public class LoginViewModel
    {
        [Display(Name = "Email", ResourceType = typeof(Resources.Properties.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Properties.Resources), ErrorMessageResourceName = "ErrorMessageRequired")]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.Properties.Resources), ErrorMessageResourceName = "ErrorMessageEmailAddress")]
        [MaxLength(100), MinLength(4)]
        public string Email { get; set; }

        [Display(Name = "Password", ResourceType = typeof(Resources.Properties.Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources.Properties.Resources), ErrorMessageResourceName = "ErrorMessageRequired")]
        [MaxLength(8), MinLength(3)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "RememberMe", ResourceType = typeof(Resources.Properties.Resources))]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}