using MATA.Data.Common.Enums;
using MATA.Data.DTO.Models;
using MATA.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Interfaces
{
    public interface IMailBL: IEntityBL<MailDTO>
    {
        Task CreateForgotPasswordMail(string email, IUnitOfWork uow);
    }
}
