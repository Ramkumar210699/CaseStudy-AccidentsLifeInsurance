using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CaseStudy.Models;

namespace CaseStudy.ViewModel
{
    public class PolicyDetailsAll
    {
        public IEnumerable<PolicyDetail> PolicyDetail { get; set; }
        public IEnumerable<PolicyCoverage> PolicyCoverage { get; set; }
        public IEnumerable<InjuryType> InjuryType { get; set; }
        public IEnumerable<vw_Policy> vwPolicy { get; set; }
        public IEnumerable<vw_PolicyDetails> vwPolicydetls { get; set; }
        public IEnumerable<PremiumPayment> premiumPayments { get; set; }
        public IEnumerable<CustomerPolicyDetail> customerPolicies { get; set; }
        public IEnumerable<Vw_customerpolicydetails> vwcustomerPolicies { get; set; }
        public virtual PolicyClaim Policyclaim { get; set; }
        public IEnumerable<Vw_PolicyClaim> vwpolicyclaim { get; set; }
        //public IEnumerable<vw_> vwpolicyclaim { get; set; }
        public string Approvedby { get; set; }
        public string status { get; set; }
    }
}