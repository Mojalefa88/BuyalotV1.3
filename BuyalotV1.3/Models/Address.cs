//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BuyalotV1._3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Address
    {
        public int addressID { get; set; }
        public int customerID { get; set; }
        public string address1 { get; set; }
        public string city { get; set; }
        public string postalCode { get; set; }
    
        public virtual Customer Customer { get; set; }
    }
}