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

        [Required, MaxLength(50), MinLength(4), DataType(DataType.Text), Display(Name = "Ad Soyad")]
        public string FullName { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(4)]
        [Display(Name = "E-Mail")]
        [EmailAddress]
        public string Email { get; set; }

        [MinLength(10)]
        [MaxLength(10)]
        [Phone]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [MaxLength(8)]
        [MinLength(3)]
        [Display(Name = "Eski Şifre")]
        public string ExPassword { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [MaxLength(8)]
        [MinLength(3)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Display(Name = "Şifre (Yeniden)"), Required, MaxLength(8), MinLength(3), DataType(DataType.Password), Compare("Password")]
        public string RePassword { get; set; }

        [Display(Name = "Rol")]
        public string RoleName { get; set; }

        public bool IsActive { get; set; }
    }
}
