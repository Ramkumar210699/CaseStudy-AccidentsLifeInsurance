﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CaseStudyEntities1 : DbContext
    {
        public CaseStudyEntities1()
            : base("name=CaseStudyEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CustomerPolicyDetail> CustomerPolicyDetails { get; set; }
        public virtual DbSet<InjuryType> InjuryTypes { get; set; }
        public virtual DbSet<PolicyClaim> PolicyClaims { get; set; }
        public virtual DbSet<PolicyCoverage> PolicyCoverages { get; set; }
        public virtual DbSet<PolicyDetail> PolicyDetails { get; set; }
        public virtual DbSet<PremiumPayment> PremiumPayments { get; set; }
        public virtual DbSet<UsersRegistrationDetail> UsersRegistrationDetails { get; set; }
        public virtual DbSet<UserType1> UserType1 { get; set; }
        public virtual DbSet<Vw_customerpolicydetails> Vw_customerpolicydetails { get; set; }
        public virtual DbSet<vw_Policy> vw_Policy { get; set; }
        public virtual DbSet<Vw_PolicyClaim> Vw_PolicyClaim { get; set; }
        public virtual DbSet<vw_PolicyDetails> vw_PolicyDetails { get; set; }
    }
}
