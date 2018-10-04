using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Interfaces
{
    public interface IMapper<TEntity, TView, TDTO>
    {
        TEntity MapToEntity(TDTO dto);

        TDTO MapToDTO(TView view);
    }
}
