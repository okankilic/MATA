using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.DTO.Models
{
    public class StoreAccountDTO
    {
        public int ID { get; set; }

        public int StoreID { get; set; }

        public string StoreName { get; set; }

        public int AccountID { get; set; }

        public string FullName { get; set; }
    }
}
