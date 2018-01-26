using MATA.BL;
using MATA.Data.Common.Enums;
using MATA.Data.DTO;
using MATA.Presentation.Web.Base;
using MATA.Presentation.Web.Helpers;
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
                AccountName = "Admin",
                UserName = ConfigurationManager.AppSettings["AdminUserName"],
                Password = ConfigurationManager.AppSettings["AdminPassword"],
                RoleName = RoleTypes.ADMIN.ToString()
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
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            AccountDTO account = null;

            try
            {
                account = AccountBL.Get(model.UserName, model.Password, base._DB);

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
    }
}