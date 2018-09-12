using MATA.BL.Impls;
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
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace MATA.Presentation.Web.Controllers
{
    public class AccountsController : CustomEntityControllerBase<AccountDTO, AccountsIndexVM>
    {
        readonly IAccountBL accountBL;
        readonly ITokenBL tokenBL;
        readonly IMailBL mailBL;

        public AccountsController(IUnitOfWorkFactory uowFactory, 
            ILogger logger,
            IVMFactory<AccountDTO, AccountsIndexVM> vmFactory,
            IDTOFactory<AccountDTO> dtoFactory,
            IBLFactory blFactory) : base(uowFactory, logger, dtoFactory, vmFactory, blFactory)
        {
            accountBL = blFactory.CreateProxy<IAccountBL>();
            tokenBL = blFactory.CreateProxy<ITokenBL>();
            mailBL = blFactory.CreateProxy<IMailBL>();
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

                var isAdminAccountExists = accountBL.IsExists(adminAccount.Email, uow);
                if (isAdminAccountExists == false)
                {
                    accountBL.Create(adminAccount, null, uow);
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
                    account = accountBL.GetByEmailAndPassword(model.Email, model.Password, uow);

                    var tokenString = tokenBL.Create(account.ID, uow);

                    var ticket = AuthenticationHelper.CreateTicket(tokenString, account, model.RememberMe);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));

                    Response.Cookies.Add(authCookie);

                    uow.Commit();
                }
            }
            catch(Exception e)
            {
                logger.Error(e, "An error occured in AccountsController:Login");
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
        public override async Task<ActionResult> _Create(AccountDTO dto = null)
        {
            return await base._Create();
        }

        [AuthorizeUser(Roles = RoleTypes.Admin)]
        public override ActionResult Create(AccountDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_Create", dto);
            }

            using (var uow = uowFactory.CreateNew())
            {
                accountBL.Create(dto, TokenString, uow);
                uow.Commit();
            }

            return new ContentResult
            {
                Content = "OK"
            };

            //return base.Create(dto);
        }

        [AuthorizeUser(Roles = RoleTypes.Admin)]
        public override async Task<ActionResult> _Edit(int id)
        {
            return await base._Edit(id);
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
        public async Task<ActionResult> ForgotPassword(AccountForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(model);
            }

            using (var uow = uowFactory.CreateNew())
            {
                await mailBL.CreateForgotPasswordMail(model.Email, uow);
                uow.Commit();
            }

            return new ContentResult()
            {
                Content = "OK"
            };
        }

        public async Task<ActionResult> _StoreAccounts(int storeID, int page = 1)
        {
            AccountsIndexVM vm;

            using (var uow = uowFactory.CreateNew())
            {
                vm = new AccountsIndexVM
                {
                    PageSize = DefaultPageSize,
                    TotalCount = accountBL.GetStoreAccountsCount(storeID, uow),
                    Accounts = await accountBL.GetStoreAccounts(storeID, (page - 1) * DefaultPageSize, DefaultPageSize, uow)
                };
            }

            return PartialView(vm);
        }

        //[AuthorizeUser(Roles = RoleTypes.Combines.AdminStaff)]
        //public ActionResult _CreateStoreAccount(int storeID)
        //{
        //    var vm = dtoFactory.CreateNew();

        //    vm.s

        //    return PartialView();
        //}
    }
}