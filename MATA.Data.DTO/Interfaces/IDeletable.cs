using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.DTO.Interfaces
{
    public interface IDeletable
    {
        bool IsDeleted { get; set; }
    }
}
