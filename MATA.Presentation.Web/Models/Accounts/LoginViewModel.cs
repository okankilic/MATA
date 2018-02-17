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
        [Display(Name = "E-Mail"), Required, MaxLength(100), MinLength(4), EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Şifre"), Required, MaxLength(8), MinLength(3), DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}