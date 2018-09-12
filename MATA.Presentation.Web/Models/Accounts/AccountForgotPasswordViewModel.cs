using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MATA.Presentation.Web.Models.Accounts
{
    public class AccountForgotPasswordViewModel
    {
        [Required, MaxLength(100), MinLength(4), EmailAddress]
        [Display(Name = "Email", ResourceType = typeof(Resources.Properties.Resources))]
        public string Email { get; set; }
    }
}