using MATA.BL;
using MATA.Data.Common.Constants;
using MATA.Data.DTO;
using MATA.Infrastructure.Utils.Exceptions;
using MATA.Presentation.Web.Base;
using MATA.Presentation.Web.Filters;
using MATA.Presentation.Web.Helpers;
using MATA.Presentation.Web.Mappers;
using MATA.Presentation.Web.Models.Accounts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MATA.Presentation.Web.Controllers
{
    public class AccountsController : CustomControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            var adminAccount = new AccountDTO()
            {
                FullName = ConfigurationManager.AppSettings["AdminFullName"],
                Email = ConfigurationManager.AppSettings["AdminEmail"],
                Password = ConfigurationManager.AppSettings["AdminPassword"],
                RoleName = RoleTypes.Admin
            };

            var isAdminAccountExists = AccountBL.IsAccountExists(adminAccount, this._DB);
            if (isAdminAccountExists == false)
                AccountBL.Create(adminAccount, this._DB);

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
                account = AccountBL.Get(model.Email, model.Password, base._DB);

                var tokenString = TokenBL.TryGet(account.ID, base._DB);
                if (string.IsNullOrWhiteSpace(tokenString))
                    tokenString = TokenBL.Create(account.ID, base._DB);

                var ticket = AuthenticationHelper.CreateTicket(tokenString, account, model.RememberMe);

                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));

                Response.Cookies.Add(authCookie);
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
        [HttpGet]
        public ActionResult Index()
        {
            var accounts = AccountBL.GetList(base._DB);

            return View(accounts);
        }

        [AuthorizeUser(Roles = RoleTypes.Admin)]
        [HttpGet]
        public ActionResult _Create()
        {
            var model = new AccountCreateViewModel();

            return PartialView(model);
        }

        [AuthorizeUser(Roles = RoleTypes.Admin)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult _Create(AccountCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return PartialView(model);

            var accountDTO = new AccountDTO()
            {
                FullName = model.FullName,
                Email = model.Email,
                Password = model.Password,
                RoleName = model.RoleName
            };

            var accountID = AccountBL.Create(accountDTO, base._DB);

            return new ContentResult()
            {
                Content = "OK"
            };
        }

        [AuthorizeUser(Roles = RoleTypes.Admin)]
        [HttpGet]
        public ActionResult _Edit(int id)
        {
            var accountDTO = AccountBL.Get(id, base._DB);

            var mapper = new AccountMapper();

            var model = mapper.MapToViewModel(accountDTO);

            return PartialView(model);
        }

        [AuthorizeUser(Roles = RoleTypes.Admin)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult _Edit(AccountEditViewModel model)
        {
            if (!ModelState.IsValid)
                return PartialView(model);

            var account = AccountBL.Get(model.ID, base._DB);

            if (account.Password != model.ExPassword)
                throw new BusinessException("Eski şifrenizi kontrol ederek tekrar deneyiniz.");

            var mapper = new AccountMapper();

            var accountDTO = mapper.MapToDTO(model);

            AccountBL.Update(accountDTO.ID, accountDTO, base._DB);

            return new ContentResult()
            {
                Content = "OK"
            };
        }

        [AuthorizeUser(Roles = RoleTypes.Admin)]
        [HttpGet]
        public ActionResult _Delete(int id)
        {
            AccountBL.Delete(id, base._DB);

            return new ContentResult()
            {
                Content = "OK"
            };
        }
    }
}