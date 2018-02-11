using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.DTO
{
    public class AccountDTO
    {
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(4)]
        [Display(Name = "E-Mail")]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [MaxLength(8)]
        [MinLength(3)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        public string RoleName { get; set; }

        public int? BrandID { get; set; }
    }
}
