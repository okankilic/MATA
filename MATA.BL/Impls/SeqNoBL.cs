using MATA.BL.Interfaces;
using MATA.Data.Entities;
using MATA.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Impls
{
    public class SeqNoBL : ISeqNoBL
    {
        public SeqNoBL()
        {

        }

        public string Create(string prefix, IUnitOfWork uow)
        {
            var seqNoList = uow.SeqNoRepository.Find(q => q.Prefix == prefix).ToList();

            var seqNo = new SeqNo() { Prefix = prefix };

            if (seqNoList.Count == 0)
            {
                seqNo.SeqNo1 = 1;
            }
            else
            {
                seqNo.SeqNo1 = seqNoList.Max(q => q.SeqNo) + 1;
            }

            uow.SeqNoRepository.Create(seqNo);
            uow.SaveChanges(null);

            return string.Format("{0}{1}", seqNo.Prefix, seqNo.SeqNo1.ToString("D4"));
        }
    }
}
