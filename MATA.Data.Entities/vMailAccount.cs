//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MATA.Data.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class vMailAccount
    {
        public int ID { get; set; }
        public int MailID { get; set; }
        public string ToCcBcc { get; set; }
        public int AccountID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
