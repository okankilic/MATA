using MATA.BL.Interfaces;
using MATA.BL.Mappers;
using MATA.Data.Common.Enums;
using MATA.Data.DTO;
using MATA.Data.DTO.Interfaces;
using MATA.Data.DTO.Models;
using MATA.Data.Entities;
using MATA.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Impls
{
    public class MailBL: IMailBL
    {
        readonly IMapper<Mail, vMail, MailDTO> mapper;
        readonly IDTOFactory<MailDTO> dTOFactory;

        public MailBL(IDTOFactory<MailDTO> dTOFactory,
            IMapper<Mail, vMail, MailDTO> mapper)
        {
            this.dTOFactory = dTOFactory;
            this.mapper = mapper;
        }

        //public static IEnumerable<Mail> GetList(int maxTryCount, int count, MataDBEntities db)
        //{
        //    return db.Mail.Where(q => q.State != MailStateTypes.ERROR.ToString() && q.TryCount < maxTryCount).OrderBy(q => q.TryCount).ThenBy(q => q.ID).Take(count).ToList();
        //}

        //public static void UpdateState(int id, MailStateTypes state, int tryCount, MataDBEntities db)
        //{
        //    var mail = db.Mail.Single(q => q.ID == id);

        //    mail.TryCount = tryCount;
        //    mail.State = state.ToString();

        //    db.SaveChanges();
        //}

        //public static void Create(MailDTO mail)
        //{

        //}

        public int Create(MailDTO dto, string tokenString, IUnitOfWork uow)
        {
            var mail = mapper.MapToEntity(dto);

            mail.State = MailStateTypes.WAITING.ToString();

            uow.MailRepository.Create(mail);

            uow.SaveChanges(tokenString);

            return mail.ID;
        }

        public void Update(int id, MailDTO dto, string tokenString, IUnitOfWork uow)
        {
            var mail = uow.MailRepository.GetByID(id);

            mail.State = dto.State;
            mail.TryCount = dto.TryCount;
            mail.LastTryTime = dto.LastTryTime;

            uow.MailRepository.Update(mail);

            uow.SaveChanges(tokenString);
        }

        public void Delete(int id, string tokenString, IUnitOfWork uow)
        {
            throw new NotImplementedException();
        }

        public MailDTO Get(int id, IUnitOfWork uow)
        {
            throw new NotImplementedException();
        }

        public int Count(IUnitOfWork uow)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MailDTO>> Search(string q, int skip, int take, IUnitOfWork uow)
        {
            throw new NotImplementedException();
        }




        public async Task CreateForgotPasswordMail(string email, IUnitOfWork uow)
        {
            var account = await uow.AccountRepository.GetByEmail(email);

            var mail = dTOFactory.CreateNew();

            mail.TOList.Add(email);

            mail.Subject = "Şifre Hatırlatma";
            mail.IsBodyHtml = true;
            mail.MailBody = $"Merhaba {account.FullName}, şifreniz {account.Password} dir.";

            Create(mail, null, uow);
        }

        //public async Task CreateAccountCreatedMail(string email, IUnitOfWork)
        //{

        //}

        //public async Task CreateAccountUpdatedMail(string email, IUnitOfWork)
        //{

        //}
    }
}
