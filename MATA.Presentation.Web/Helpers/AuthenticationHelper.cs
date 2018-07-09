using MATA.Data.DTO;
using MATA.Data.DTO.Models;
using MATA.Presentation.Web.Models.Accounts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MATA.Presentation.Web.Helpers
{
    public static class AuthenticationHelper
    {
        public static FormsAuthenticationTicket GetTicket(HttpContextBase httpContext)
        {
            var authCookie = httpContext.Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie == null)
                throw new UnauthorizedAccessException();

            return FormsAuthentication.Decrypt(authCookie.Value);
        }

        public static FormsAuthenticationTicket CreateTicket(string tokenString, AccountDTO account, bool isPersistent)
        {
            var userDataObject = new CustomFormsAuthenticationUserData(tokenString, account.RoleName);

            var userData = JsonConvert.SerializeObject(userDataObject);

            return new FormsAuthenticationTicket(1, account.Email, DateTime.UtcNow, DateTime.UtcNow.Add(FormsAuthentication.Timeout), isPersistent, userData, FormsAuthentication.FormsCookiePath);
        }

        public static CustomFormsAuthenticationUserData GetUserData(HttpContextBase httpContext)
        {
            var ticketUserData = GetTicket(httpContext).UserData;

            return JsonConvert.DeserializeObject<CustomFormsAuthenticationUserData>(ticketUserData);
        }

        public static string GetRole(HttpContextBase httpContext)
        {
            var userData = GetUserData(httpContext);

            return userData.RoleName;
        }

        public static string GetTokenString(HttpContextBase httpContext)
        {
            var userData = GetUserData(httpContext);

            return userData.TokenString;
        }
    }
}