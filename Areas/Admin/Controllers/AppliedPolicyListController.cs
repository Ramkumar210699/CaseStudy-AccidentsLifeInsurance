using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaseStudy.Models;
using CaseStudy.ViewModel;

namespace CaseStudy.Areas.Admin.Controllers
{
    public class AppliedPolicyListController : Controller
    {
        // GET: Admin/AppliedPolicyList
        CaseStudyEntities1 dbObj = new CaseStudyEntities1();
        public ActionResult Index()
        {
            //CustomerPolicyDetail custdetails = dbObj.CustomerPolicyDetails.Fi();
            var table = new PolicyDetailsAll
            {
                vwcustomerPolicies = dbObj.Vw_customerpolicydetails.ToList(),

            };
            return View(table);
        }
    }
}