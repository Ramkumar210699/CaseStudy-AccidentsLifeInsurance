using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaseStudy.Models
{
    public class PolicyDetails
    {
        public int PolicyID { get; set; }
        public Nullable<int> PolicyDuration { get; set; }
        public Nullable<double> PolicyAmount { get; set; }
        public Nullable<int> ManagerID { get; set; }
        public int MaturityYears { get; set; }
        public string Policyname { get; set; }
        public Nullable<double> PolicyCoverageAmount { get; set; }
        public string Managername { get; set; }
        public string InjuryName { get; set; }
        public string InjuryDescription { get; set; }
        public int ReimbursePercent { get; set; }

        public List<vw_PolicyDetails> Vw_PolicyDetails { get; set; }
        //public virtual InjuryType InjuryType { get; set; }
        //public PolicyDetails _policydetails { get; set; }
        //public IEnumerable<InjuryType> InjuryType { get; set; }
        //public IEnumerable<PolicyDetails> Policydetails { get; set; }
        //public IEnumerable<PolicyCoverage> PolicyCoverage { get; set; }
        public virtual List<InjuryType> InjuryTypess { get; set; }
       // public virtual PolicyDetails  Policydetailsss { get; set; }
        public virtual List< PolicyCoverage> PolicyCoveragess { get; set; }
    }
}