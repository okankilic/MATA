using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MATA.Presentation.Web.Models.Accounts
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Properties.Resources), ErrorMessageResourceName = "ErrorMessageRequired")]
        [EmailAddress(ErrorMessageResourceType = typeof(Resources.Properties.Resources), ErrorMessageResourceName = "ErrorMessageEmailAddress")]
        [MaxLength(100), MinLength(4)]
        [Display(Name = "Email", ResourceType = typeof(Resources.Properties.Resources))]
        public string Email { get; set; }
    }
}