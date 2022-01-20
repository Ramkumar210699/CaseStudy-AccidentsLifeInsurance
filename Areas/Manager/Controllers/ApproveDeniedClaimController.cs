using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CaseStudy.Models;
using CaseStudy.ViewModel;
using System.Web.Routing;

namespace CaseStudy.Areas.Manager.Controllers
{
    public class ApproveDeniedClaimController : Controller
    {
        // GET: Manager/ApproveDeniedClaim
        CaseStudyEntities1 dbObj = new CaseStudyEntities1();
        int userid = 0;
        public ActionResult Index()
        {
            var UserId = Session["UserId"];
            var Status = "Pending";
            userid = (int)UserId;
            //CustomerPolicyDetail custdetails = dbObj.CustomerPolicyDetails.Fi();
            var table = new PolicyDetailsAll
            {
                vwpolicyclaim = dbObj.Vw_PolicyClaim.Where(m => m.ManagerID == userid && m.ApprovedOrRejected== Status).ToList(),

            };
            return View(table);
        }
        [HttpGet]
        public ActionResult Choice1(int Id, string name)
        {
            Session["i"] = Id;
            var UserId = (int)Session["UserId"];
            // UsersRegistrationDetail managername =
            UsersRegistrationDetail managername = dbObj.UsersRegistrationDetails.FirstOrDefault(m => m.UserID == UserId);
                //dbObj.UsersRegistrationDetails.Where(a => a.UserID.Equals(User)).FirstOrDefault();
            var P = new PolicyClaim();
            if (dbObj.PolicyClaims.FirstOrDefault(e => e.UserId == Id) != null)
            {
                if (name.Equals("Approved"))
                {
                    var appointment = dbObj.PolicyClaims.Where(a => a.UserId.Equals(Id)).SingleOrDefault();
                    appointment.ApprovedOrRejected = name;
                    appointment.ApprovedOrrejectedBy = managername.Username;
                    Session["st"] = name;
                    dbObj.SaveChanges();
                }
                else
                {
                    var appointment = dbObj.PolicyClaims.Where(a => a.UserId.Equals(Id)).SingleOrDefault();
                    appointment.ApprovedOrRejected = name;
                    appointment.ApprovedOrrejectedBy = managername.Username;
                    Session["st"] = name;
                    dbObj.SaveChanges();
                }
                TempData["UserId"] = Session["UserId"];

                return RedirectToAction("Index", "Home", new { area = "Manager" });
            }
            return View("Index");
        }
        //[HttpPost]
        //public bool Index(PolicyDetailsAll _customer)
        //{
        //    //List<PolicyClaim> policyClaims = dbObj.PolicyClaims.ToList<PolicyClaim>();
        //    //return Json(new { data = policyClaims }, JsonRequestBehavior.AllowGet);
        //    using (CaseStudyEntities entities = new CaseStudyEntities())
        //    {
        //        PolicyClaim updatedCustomer = (from c in entities.PolicyClaims
        //                                    where c.UserId == userid
        //                                       select c).FirstOrDefault();
        //        UsersRegistrationDetail User = (from c in entities.UsersRegistrationDetails
        //                                       where c.UserID == userid
        //                                       select c).FirstOrDefault();

        //        if (updatedCustomer != null)
        //        {
        //            updatedCustomer.ApprovedOrRejected = "Approved";
        //            updatedCustomer.ApprovedOrrejectedBy = User.Username;
        //            entities.SaveChanges();
        //            return true;
        //        }
        //    }

        //    return false;

        //}
        //    [ActionName("Index")]
        //    [HttpPost]
        //    public ActionResult IndexPost(string button, int? id)
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }

        //        string buttonClicked = button;
        //        if (buttonClicked == "approve")
        //        {

        //            PolicyClaim currentApplication = dbObj.PolicyClaims.Find(id);
        //            currentApplication.ApprovedOrRejected = "APPROVED";
        //            dbObj.SaveChanges();

        //        }
        //        else if (buttonClicked == "reject")
        //        {
        //            PolicyClaim currentApplication = dbObj.PolicyClaims.Find(id);
        //            currentApplication.ApprovedOrRejected = "Denied";
        //            dbObj.SaveChanges();
        //        }
        //        //Save Record and Redirect
        //        return RedirectToAction("Index");

        //    }
    }
}