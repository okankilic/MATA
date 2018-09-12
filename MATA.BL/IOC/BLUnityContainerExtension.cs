using MATA.BL.Impls;
using MATA.BL.Interfaces;
using MATA.BL.Mappers;
using MATA.Data.DTO.Ioc;
using MATA.Data.DTO.Models;
using MATA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Extension;

namespace MATA.BL.Ioc
{
    public class BLUnityContainerExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.AddNewExtension<DTOUnityContainerExtension>();

            Container.RegisterType<ICacheBL, CacheBL>();

            Container.RegisterType<IMapper<Account, vAccount, AccountDTO>, AccountMapper>();
            Container.RegisterType<IEntityBL<AccountDTO>, IAccountBL>();
            Container.RegisterType<IAccountBL, AccountBL>();
            
            //Container.RegisterType<IEntityBL<TokenDTO>, ITokenBL>();
            Container.RegisterType<ITokenBL, TokenBL>();

            Container.RegisterType<IMapper<Country, vCountry, CountryDTO>, CountryMapper>();
            Container.RegisterType<IEntityBL<CountryDTO>, ICountryBL>();
            Container.RegisterType<ICountryBL, CountryBL>();

            Container.RegisterType<IMapper<City, vCity, CityDTO>, CityMapper>();
            Container.RegisterType<IEntityBL<CityDTO>, ICityBL>();
            Container.RegisterType<ICityBL, CityBL>();
            
            Container.RegisterType<IMapper<Project, vProject, ProjectDTO>, ProjectMapper>();
            Container.RegisterType<IEntityBL<ProjectDTO>, IProjectBL>();
            Container.RegisterType<IProjectBL, ProjectBL>();

            Container.RegisterType<IMapper<Store, vStore, StoreDTO>, StoreMapper>();
            Container.RegisterType<IEntityBL<StoreDTO>, IStoreBL>();
            Container.RegisterType<IStoreBL, StoreBL>();

            Container.RegisterType<IMapper<Issue, vIssue, IssueDTO>, IssueMapper>();
            Container.RegisterType<IEntityBL<IssueDTO>, IIssueBL>();
            Container.RegisterType<IIssueBL, IssueBL>();

            Container.RegisterType<IMapper<Data.Entities.Action, vAction, ActionDTO>, ActionMapper>();
            Container.RegisterType<IEntityBL<ActionDTO>, IActionBL>();
            Container.RegisterType<IActionBL, ActionBL>();

            Container.RegisterType<IMapper<Mail, vMail, MailDTO>, MailMapper>();
            Container.RegisterType<IEntityBL<MailDTO>, IMailBL>();
            Container.RegisterType<IMailBL, MailBL>();

            Container.RegisterType<IMapper<Attachment, vAttachment, AttachmentDTO>, AttachmentMapper>();
            Container.RegisterType<IEntityBL<AttachmentDTO>, IAttachmentBL>();
            Container.RegisterType<IAttachmentBL, AttachmentBL>();

            Container.RegisterType<IBLFactory, BLFactory>();
        }
    }
}
