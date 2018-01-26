using MATA.BL.Mappers;
using MATA.Data.DTO;
using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL
{
    public static class BackLogBL
    {
        public static int Create(BackLogDTO backLogDTO, MataDBEntities db)
        {
            var mapper = new BackLogMapper();

            var backLog = mapper.MapToEntity(backLogDTO);

            db.BackLog.Add(backLog);

            db.SaveChanges();

            return backLog.ID;
        }

        public static void Update(int id, BackLogDTO backLogDTO, MataDBEntities db)
        {
            throw new NotImplementedException();
        }

        public static void Delete(int id, MataDBEntities db)
        {
            throw new NotImplementedException();
        }
    }
}
