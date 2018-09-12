using MATA.Data.Repositories.Interfaces;
using MATA.Infrastructure.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MATA.BL.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CustomAuthorizeAttribute: Attribute
    {
        public string Roles { get; set; }

        public static void Handle(IMethodCallMessage methodCall, string roles)
        {
            if (methodCall.InArgCount < 2)
            {
                throw new Exception("Invalid parameter count for CustomAuthorizeAttribute");
            }

            var tokenString = methodCall.InArgs[methodCall.InArgCount - 2].ToString();
            var tokenGuid = Guid.Parse(tokenString);
            var uow = methodCall.InArgs[methodCall.InArgCount - 1] as IUnitOfWork;

            var accountID = uow.TokenRepository.Find(q => q.TokenString == tokenGuid).Single().AccountID;
            var account = uow.AccountRepository.GetByID(accountID);

            if (roles.Contains(account.RoleName) == false)
            {
                throw new AuthorizationException();
            }
        }
    }
}
