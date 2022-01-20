using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaseStudy.Models
{
    public class ViewCustomerPolicyDetail
    {
        public int PolicyID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<System.DateTime> RegisterdDate { get; set; }
        public Nullable<int> Duration { get; set; }
        public Nullable<double> PolicyAmount { get; set; }
        public string PolicyTerm { get; set; }
        public Nullable<int> UserNoTerms { get; set; }
        public Nullable<double> PremiumAmount { get; set; }
        public string NomineeName { get; set; }
        public string NomineeRelation { get; set; }
        public Nullable<int> ManagerID { get; set; }
        public int RegisteredID { get; set; }
        public string Username { get; set; }
        public int MaturityYears { get; set; }
        public string Policyname { get; set; }
        public Nullable<double> PolicyCoverageAmount { get; set; }
        public int Srlno { get; set; }
        public string Managername { get; set; }

        public virtual  Vw_customerpolicydetails vw_customerpolicydetails { get; set; }
    }
}