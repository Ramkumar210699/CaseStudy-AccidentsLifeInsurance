using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaseStudy.Models;
using CaseStudy.ViewModel;
using System.Web.Routing;

namespace CaseStudy.Areas.Manager.Controllers
{
    public class ApprovedlistController : Controller
    {
        CaseStudyEntities1 dbObj = new CaseStudyEntities1();
        int userid = 0;

        // GET: Manager/Approvedlist
        public ActionResult Index()
        {
            var UserId = Session["UserId"];
            userid = (int)UserId;
            var Status = "Pending";
            //CustomerPolicyDetail custdetails = dbObj.CustomerPolicyDetails.Fi();
            var table = new PolicyDetailsAll
            {
                vwpolicyclaim = dbObj.Vw_PolicyClaim.Where(m => m.ManagerID == userid && m.ApprovedOrRejected != Status).ToList(),

            };
            return View(table);
        }
    }
}