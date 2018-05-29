using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MATA.Presentation.Web.Models.Accounts
{
    public class AccountForgotPasswordViewModel
    {
        [Display(Name = "E-Mail"), Required, MaxLength(100), MinLength(4), EmailAddress]
        public string Email { get; set; }
    }
}