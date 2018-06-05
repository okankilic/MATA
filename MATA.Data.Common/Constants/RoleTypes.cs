using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATA.Data.Common.Constants
{
    public static class RoleTypes
    {
        public const string Admin = "ADMIN";
        public const string Staff = "STAFF";
        public const string Customer = "CUSTOMER";

        public static class Combines
        {
            public const string Any = Admin + "," + Staff + "," + Customer;
            public const string AdminStaff = Admin + "," + Staff;
        }
    }
}
