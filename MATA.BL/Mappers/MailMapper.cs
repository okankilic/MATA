using MATA.BL.Interfaces;
using MATA.Data.DTO.Models;
using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Mappers
{
    public class MailMapper : IMapper<Mail, vMail, MailDTO>
    {
        public MailDTO MapToDTO(vMail view)
        {
            throw new NotImplementedException();
        }

        public Mail MapToEntity(MailDTO dto)
        {
            return new Mail
            {
                Subject = dto.Subject,
                MailBody = dto.MailBody,
                IsBodyHtml = dto.IsBodyHtml
            };
        }
    }
}
