using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MATA.Presentation.Web.Models.Accounts
{
    public class AccountEditViewModel
    {
        public int ID { get; set; }

        [Display(Name = "Ad Soyad"), Required, MaxLength(50), MinLength(4), DataType(DataType.Text)]
        public string FullName { get; set; }

        [Display(Name = "E-Mail"), Required, MaxLength(100), MinLength(4), EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Eski Şifre"), Required, MaxLength(8), MinLength(3), DataType(DataType.Password)]
        public string ExPassword { get; set; }

        [Display(Name = "Şifre"), Required, MaxLength(8), MinLength(3), DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Şifre (Yeniden)"), Required, MaxLength(8), MinLength(3), DataType(DataType.Password), Compare("Password")]
        public string RePassword { get; set; }

        [Display(Name = "Rol"), Required]
        public string RoleName { get; set; }
    }
}