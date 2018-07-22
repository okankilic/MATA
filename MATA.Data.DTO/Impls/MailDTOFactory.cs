using MATA.Data.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.DTO.Impls
{
    public class MailDTOFactory : DTOFactory<MailDTO>
    {
        public override MailDTO CreateNew()
        {
            return new MailDTO();
        }
    }
}
