using CaseStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace CaseStudy.Areas.Customer.Controllers
{
    [SessionState(SessionStateBehavior.Default)]
    public class CustomerPolicyDetailController : Controller
    {
        CaseStudyEntities1 dbObj = new CaseStudyEntities1();
        // GET: Customer/CustomerPolicyDetail
        public ActionResult Index()
        {
            int Userid = (int)Session["userId"];
            //int Userid = (int)TempData["UserId"];
            
             Vw_customerpolicydetails custdetails = dbObj.Vw_customerpolicydetails.FirstOrDefault(m => m.UserID == Userid);
            if (custdetails == null)
            {
                return HttpNotFound();
            }
            return View(custdetails);
           // return View();
        }
    }
}