using MATA.BL.Interfaces;
using MATA.Data.Common.Constants;
using MATA.Data.Common.Enums;
using MATA.Data.DTO.Interfaces;
using MATA.Data.DTO.Models;
using MATA.Data.Repositories.Interfaces;
using MATA.Infrastructure.Utils.Exceptions;
using MATA.Presentation.Web.Base;
using MATA.Presentation.Web.Filters;
using MATA.Presentation.Web.Helpers;
using MATA.Presentation.Web.Interfaces;
using MATA.Presentation.Web.Models.Accounts;
using NLog;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MATA.Presentation.Web.Controllers
{
    public class AccountsController : CustomEntityControllerBase<AccountDTO, AccountsIndexVM>
    {
        readonly ITokenBL tokenBL;
        readonly IMailBL mailBL;

        public AccountsController(IUnitOfWorkFactory uowFactory, 
            ILogger logger,
            IVMFactory<AccountDTO, AccountsIndexVM> vmFactory,
            IDTOFactory<AccountDTO> dtoFactory,
            IAccountBL accountBL,
            ITokenBL tokenBL,
            IMailBL mailBL) : base(uowFactory, logger, dtoFactory, vmFactory, accountBL)
        {
            this.tokenBL = tokenBL;
            this.mailBL = mailBL;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            using (var uow = uowFactory.CreateNew())
            {
                var adminAccount = new AccountDTO()
                {
                    FullName = ConfigurationManager.AppSettings["AdminFullName"],
                    Email = ConfigurationManager.AppSettings["AdminEmail"],
                    Password = ConfigurationManager.AppSettings["AdminPassword"],
                    RoleName = RoleTypes.Admin
                };

                var isAdminAccountExists = (entityBL as IAccountBL).IsExists(adminAccount.Email, uow);
                if (isAdminAccountExists == false)
                {
                    entityBL.Create(adminAccount, null, uow);
                    uow.Commit();
                }
            }

            var model = new LoginViewModel()
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            AccountDTO account = null;

            try
            {
                using (var uow = uowFactory.CreateNew())
                {
                    account = (entityBL as IAccountBL).GetByEmailAndPassword(model.Email, model.Password, uow);

                    var tokenString = tokenBL.GetOrCreate(account.ID, uow);

                    var ticket = AuthenticationHelper.CreateTicket(tokenString, account, model.RememberMe);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));

                    Response.Cookies.Add(authCookie);

                    uow.Commit();
                }
            }
            catch
            {

            }

            if (account != null)
            {
                if (!string.IsNullOrWhiteSpace(model.ReturnUrl))
                    return Redirect(model.ReturnUrl);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Kullanıcı bulunamadı. Lütfen kullanıcı adı ve şifrenizi kontrol edip tekrar deneyiniz.");

            return View(model);
        }

        [HttpGet]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }

        [AuthorizeUser(Roles = RoleTypes.Admin)]
        public override Task<ActionResult> Index(int page = 1)
        {
            return base.Index(page);
        }

        [AuthorizeUser(Roles = RoleTypes.Admin)]
        public override ActionResult _Create()
        {
            return base._Create();
        }

        [AuthorizeUser(Roles = RoleTypes.Admin)]
        public override ActionResult Create(AccountDTO dto)
        {
            return base.Create(dto);
        }

        [AuthorizeUser(Roles = RoleTypes.Admin)]
        public override ActionResult _Edit(int id)
        {
            return base._Edit(id);
        }

        [AuthorizeUser(Roles = RoleTypes.Admin)]
        public override ActionResult Edit(int id, AccountDTO dto)
        {
            return base.Edit(id, dto);
        }

        [AuthorizeUser(Roles = RoleTypes.Admin)]
        public override ActionResult Delete(int id)
        {
            return base.Delete(id);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult _ForgotPassword()
        {
            var model = new AccountForgotPasswordViewModel();

            return PartialView(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult _ForgotPassword(AccountForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(model);
            }

            using (var uow = uowFactory.CreateNew())
            {
                mailBL.QueueMail(model.Email, MailTypes.FORGOT_PASSWORD, uow);
                uow.Commit();
            }

            return new ContentResult()
            {
                Content = "OK"
            };
        }
    }
}