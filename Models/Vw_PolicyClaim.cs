//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CaseStudy.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vw_PolicyClaim
    {
        public Nullable<int> RegisteredID { get; set; }
        public string ApplicantName { get; set; }
        public Nullable<System.DateTime> SubmitionDate { get; set; }
        public Nullable<System.DateTime> DateOfInjury { get; set; }
        public Nullable<int> InjuryID { get; set; }
        public string NomineeName { get; set; }
        public Nullable<double> PolicyAmount { get; set; }
        public Nullable<double> PremiumAmount { get; set; }
        public Nullable<double> ReimburseAmount { get; set; }
        public int UserId { get; set; }
        public Nullable<int> ManagerID { get; set; }
        public string InjuryDescription { get; set; }
        public int ReimbursePercent { get; set; }
        public string ApprovedOrRejected { get; set; }
    }
}