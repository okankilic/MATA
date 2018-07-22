using MATA.Data.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.DTO.Models
{
    public class ActionDTO
    {
        public int AccountID { get; set; }

        public string FullName { get; set; }

        public string EntityName { get; set; }

        public int? EntityID { get; set; }

        public ActionTypes ActionType { get; set; }

        public DateTime ActionTime { get; set; }
    }
}
