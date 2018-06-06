using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Interfaces
{
    public interface IEntityBL<TDTO>
    {
        int Create(TDTO dto, string tokenString, MataDBEntities db);

        void Update(int id, TDTO dto, string tokenString, MataDBEntities db);

        void Delete(int id, MataDBEntities db);

        TDTO Get(int id, MataDBEntities db);

        int Count(MataDBEntities db);
    }
}
