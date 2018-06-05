using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.DTO.Models
{
    public class IssueDTO
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public string IssueState { get; set; }
        public string Remarks { get; set; }
        public DateTime RequestDate { get; set; }
        public string RequestedByFullName { get; set; }
        public string SourceType { get; set; }
        public int StoreID { get; set; }
        public string StoreName { get; set; }
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public int CreatedByAccountID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreateTime { get; set; }
        public int UpdatedByAccountID { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
