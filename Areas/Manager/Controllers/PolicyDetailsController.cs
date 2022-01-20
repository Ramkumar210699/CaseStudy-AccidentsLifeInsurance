using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaseStudy.Models;
using CaseStudy.ViewModel;

namespace CaseStudy.Areas.Manager.Controllers
{
    public class PolicyDetailsController : Controller
    {
        // GET: Manager/PolicyDetails

        CaseStudyEntities1 dbObj = new CaseStudyEntities1();
        public ActionResult Index()
        {
            var tables = new PolicyDetailsAll
            {
                //vwPolicydetls = from c in dbObj.vw_PolicyDetails select c,
                PolicyDetail = dbObj.PolicyDetails.ToList(),
                PolicyCoverage = dbObj.PolicyCoverages.ToList(),
                InjuryType = dbObj.InjuryTypes.ToList(),
            };


            return View(tables);
        }
    }
}