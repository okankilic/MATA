using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MATA.Presentation.Web.Models.Accounts
{
    public class CustomFormsAuthenticationUserData
    {
        public string TokenString { get; private set; }

        public string RoleName { get; private set; }

        public CustomFormsAuthenticationUserData(string tokenString, string roleName)
        {
            this.TokenString = tokenString;
            this.RoleName = roleName;
        }
    }
}