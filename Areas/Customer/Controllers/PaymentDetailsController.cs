using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaseStudy.Models;
using CaseStudy.ViewModel;
using System.Web.SessionState;
namespace CaseStudy.Areas.Customer.Controllers
{
    [SessionState(SessionStateBehavior.Default)]
    public class PaymentDetailsController : Controller
    {
        // GET: Customer/PaymentDetails
        CaseStudyEntities1 dbObj = new CaseStudyEntities1();
        public ActionResult Index()
        {
            int Userid = (int)Session["UserId"];
            //int Userid = (int)TempData["UserId"];
            CustomerPolicyDetail custdetails = dbObj.CustomerPolicyDetails.FirstOrDefault(m => m.UserID == Userid);
            var table = new PolicyDetailsAll
            {
                premiumPayments = dbObj.PremiumPayments.Where(c=>c.RegistredID== custdetails.RegisteredID).ToList(),
        
            };
            return View(table);
        }
    }
}