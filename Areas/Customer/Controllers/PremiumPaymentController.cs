using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaseStudy.Models;
using System.Web.SessionState;

namespace CaseStudy.Areas.Customer.Controllers
{
    [SessionState(SessionStateBehavior.Default)]
    public class PremiumPaymentController : Controller
    {
        // GET: Customer/PremiumPayment
        CaseStudyEntities1 dbObj = new CaseStudyEntities1();
        int UserId = 0;
        [HttpGet]
        public ActionResult Payment()
        {
            UserId = (int)Session["userId"];
            //UserId = (int)TempData["UserId"];
            //var items = dbObj.CustomerPolicyDetails.ToList();
            var items = dbObj.CustomerPolicyDetails.Where(m => m.UserID == UserId).ToList();
            ViewBag.Name = new SelectList(items, "RegisteredID", "RegisteredID");
            ViewBag.Payment = new SelectList(items, "PremiumAmount", "PremiumAmount");
            List<object> Paytype = new List<object>();
            Paytype.Add("DebitCard");
            Paytype.Add("CreditCard");
            Paytype.Add("NetBanking");
            ViewBag.Pay = new SelectList(Paytype, "PaymentType");
            return View();
        }
        [HttpPost]
        public ActionResult Payment(PremiumPayment Model)
        {
            string i = string.Empty;
            //int i = (int)Maxid.ReceiptNumber;
            PremiumPayment paytable = new PremiumPayment();
        
                if (dbObj != null)
                {
                    var Maxid = dbObj.PremiumPayments.OrderByDescending(c => c.ReceiptNumber).FirstOrDefault();
               // var Maxiid = from c in dbObj.PremiumPayments orderby c.ReceiptNumber select c.ReceiptNumber.ToString();
                //i = Maxid.ReceiptNumber.ToString();
                paytable.RegistredID = Model.RegistredID;
                    paytable.PayAmount = Model.PayAmount;
                    paytable.PayType = Model.PayType;
                    paytable.DateOfPayment = Model.DateOfPayment;
                    if (Maxid == null)
                    {
                        paytable.ReceiptNumber = 000001;
                    }
                    else
                    {
                        paytable.ReceiptNumber = Maxid.ReceiptNumber + 1;
                    }
                    TempData["msg"] = "Your Receipt Number is :" + paytable.ReceiptNumber;
                    dbObj.PremiumPayments.Add(paytable);
                    dbObj.SaveChanges();
                    TempData["UserId"] = (int)Session["userId"];
                    ViewBag.Status = TempData["msg"];
                    return RedirectToAction("Index", "Home", new { area = "Customer" });
                //return Content("<script language='javascript' type='text/javascript'>alert('Already Claimed the Amount Please check');</script>");
                    //return View();
            }
            else
                    return Content("Payment is not successful...Please try again...");

          
        }
    }
}