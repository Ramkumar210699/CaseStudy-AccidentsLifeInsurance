using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaseStudy.Models;
using CaseStudy.ViewModel;

namespace CaseStudy.Areas.Manager.Controllers
{
    public class CustomerDetailsController : Controller
    {
        // GET: Manager/CustomerDetails
        CaseStudyEntities1 dbObj = new CaseStudyEntities1();
        public ActionResult Index()
        {
            var UserId = Session["UserId"];
            int userid = (int)UserId;
            //CustomerPolicyDetail custdetails = dbObj.CustomerPolicyDetails.Fi();
            var table = new PolicyDetailsAll
            {
                vwcustomerPolicies = dbObj.Vw_customerpolicydetails.Where(m => m.ManagerID == userid).ToList(),

            };
            return View(table);
        }
    }
}


