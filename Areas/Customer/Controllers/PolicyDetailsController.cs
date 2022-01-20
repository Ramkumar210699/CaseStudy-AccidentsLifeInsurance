using CaseStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using CaseStudy.ViewModel;
namespace CaseStudy.Areas.Customer.Controllers
{
    [SessionState(SessionStateBehavior.Default)]
    public class PolicyDetailsController : Controller
    {
        CaseStudyEntities1 dbObj = new CaseStudyEntities1();
        // GET: Customer/PolicyDetails
        public ActionResult Index()
        {

            ////var items = dbObj.PolicyDetails.ToList();
            ////ViewBag.Name = new SelectList(items, "PolicyId", "PolicyName");
            //////Get Student detail as per student ID  
            ////return View();
            ////PolicyDetails policydt = new PolicyDetails();
            //List<PolicyDetail> policydtl = dbObj.PolicyDetails.ToList();
            ////List<PolicyCoverage> policycvg = dbObj.PolicyCoverages.ToList();
            //List<vw_PolicyDetails> policyDetails = dbObj.vw_PolicyDetails.ToList();
            //var MyModel = new PolicyDetails();
            //MyModel.Vw_PolicyDetails = dbObj.vw_PolicyDetails.ToList();
            //MyModel.InjuryTypess = dbObj.InjuryTypes.ToList();
            ////MyModel.PolicyCoverage = (IEnumerable<PolicyCoverage>)dbObj.PolicyCoverages.ToList();
            ////MyModel.InjuryType = (IEnumerable<InjuryType>)dbObj.InjuryTypes.ToList();
            //return View(MyModel);
            var tables = new PolicyDetailsAll
            {
                //vwPolicydetls = from c in dbObj.vw_PolicyDetails select c,
                PolicyDetail=dbObj.PolicyDetails.ToList(),
                PolicyCoverage = dbObj.PolicyCoverages.ToList(),
                InjuryType = dbObj.InjuryTypes.ToList(),
            };
            
           
            return View(tables);
        }
        
    }
}