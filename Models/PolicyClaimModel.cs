using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaseStudy.Models
{
    public class PolicyClaimModel
    {
        public int RegisteredID { get; set; }
        public string ApplicantName { get; set; }

        public DateTime SubmitionDate { get; set; }
        public DateTime DateOfInjury { get; set; }
        public int InjuryID { get; set; }
        public string InjuryDescription { get; set; }
        public string NomineeName { get; set; }
        public string NomineeRelation { get; set; }
        public double ReimburseAmount { get; set; }
        public string ApprovedOrRejected { get; set; }
        public string ApprovedOrrejectedBy { get; set; }
        public int UserID { get; set; }

        public virtual PolicyCoverage PolicyCoverage { get; set; }
        public virtual PolicyDetail PolicyDetail { get; set; }
        public virtual InjuryType InjuryType { get; set; }
        public virtual UsersRegistrationDetail UsersRegistrationDetail { get; set; }
        public virtual CustomerPolicyDetail CustomerPolicyDetail { get; set; }


    }
}