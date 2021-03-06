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
    
    public partial class BackLog
    {
        public int ID { get; set; }
        public int BrandID { get; set; }
        public int CountyID { get; set; }
        public int CityID { get; set; }
        public string Description { get; set; }
        public string SenderName { get; set; }
        public string ContactType { get; set; }
        public string ResponsibleName { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public string CurrencyCode { get; set; }
        public bool IsPaid { get; set; }
        public Nullable<decimal> InvoiceAmount { get; set; }
        public Nullable<long> InvoiceNumber { get; set; }
        public Nullable<System.DateTime> InvoiceTime { get; set; }
        public string Remarks { get; set; }
        public System.DateTime CreateTime { get; set; }
        public Nullable<System.DateTime> ProgressTime { get; set; }
        public Nullable<System.DateTime> CompleteTime { get; set; }
        public System.DateTime UpdateTime { get; set; }
    
        public virtual Brand Brand { get; set; }
        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
    }
}
