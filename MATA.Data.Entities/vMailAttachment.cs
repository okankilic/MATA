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
    
    public partial class vMailAttachment
    {
        public int ID { get; set; }
        public int MailID { get; set; }
        public string AttachmentType { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }
}
