using CaseStudy.Models;
using CaseStudy.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNetCore;
using System.Security.Claims;
using System.Web.SessionState;

namespace CaseStudy.Areas.Customer.Controllers
{
    [SessionState(SessionStateBehavior.Default)]
    public class ClaimPolicyController : Controller
    {
        CaseStudyEntities1 dbObj = new CaseStudyEntities1();
        // GET: Customer/ClaimPolicy

        int UserId = 0;
        public ActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public ActionResult Claim()
        {

            UserId = (int)Session["userId"];
            //string name  = TempData["UserId"].ToString();

            var items = dbObj.CustomerPolicyDetails.Where(m => m.UserID == UserId).ToList();
            ViewBag.Name = new SelectList(items, "RegisteredID", "RegisteredID");
            ViewBag.NomineeName = new SelectList(items, "NomineeName", "NomineeName");
            ViewBag.NomineeRelation = new SelectList(items, "NomineeRelation", "NomineeRelation");
            ViewBag.UserId = new SelectList(items, "UserID", "UserID");
            var Username = dbObj.UsersRegistrationDetails.Where(m => m.UserID == UserId).ToList();
            ViewBag.UserName = new SelectList(Username, "UserID", "UserName");
            List<InjuryType> Injuries = dbObj.InjuryTypes.ToList();
            var data = Injuries.ToList();

            ViewBag.data = new SelectList(data, "InjuryID", "InjuryDescription");

            return View();
        }
        [HttpGet]
        public ActionResult Reimburse(string InjuryId)
        {
            UserId = (int)Session["userId"];
            var customerpolicy = dbObj.Vw_customerpolicydetails.FirstOrDefault(m => m.UserID == UserId);
            PolicyCoverage PolicyData = dbObj.PolicyCoverages.FirstOrDefault(m => m.PolicyAmount == customerpolicy.PolicyAmount);
            var covgamount = PolicyData.PolicyCoverageAmount;
            int injureid = Convert.ToInt32(InjuryId);
            var Reimbursepercent = dbObj.InjuryTypes.FirstOrDefault(m => m.InjuryID == injureid);
            double percent = ((double)Reimbursepercent.ReimbursePercent * (double)covgamount) / 100;



            List<object> TermDetails = new List<object>();
            TermDetails.Add(percent);
            return Json(TermDetails, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Claim(PolicyClaimModel Model)
        {
            PolicyClaim Claimpolicy = new PolicyClaim();
            UserId = (int)Session["userId"];
            UsersRegistrationDetail User = dbObj.UsersRegistrationDetails.FirstOrDefault(m => m.UserID == UserId);
            PolicyClaim CheckClaim = dbObj.PolicyClaims.FirstOrDefault(m => m.UserId == UserId);
            // PolicyDetailCoverageModel Model = new PolicyDetailCoverageModel();
            if (CheckClaim == null)
            {
                if (ModelState.IsValid)
                {
                    if (dbObj != null)
                    {
                        //dbObj.CustomerPolicyDetails.Add(userdetails);
                        Claimpolicy.UserId = (int)Session["userId"];
                        Claimpolicy.SubmitionDate = Model.SubmitionDate;
                        Claimpolicy.RegisteredID = Model.RegisteredID;
                        Claimpolicy.InjuryID = Model.InjuryID;
                        Claimpolicy.NomineeName = Model.NomineeName;
                        Claimpolicy.NomineeRelation = Model.NomineeRelation;
                        Claimpolicy.ReimburseAmount = Model.ReimburseAmount;
                        Claimpolicy.ApplicantName = User.Username;
                        Claimpolicy.DateOfInjury = Model.DateOfInjury;
                        Claimpolicy.ApprovedOrRejected = "Pending";
                        Claimpolicy.ApprovedOrrejectedBy = "Pending";
                        dbObj.PolicyClaims.Add(Claimpolicy);
                        dbObj.SaveChanges();
                        //return View(Model);
                        //Session["userId"] = UserId;
                        TempData["UserId"] = Claimpolicy.UserId;
                        return RedirectToAction("Index", "Home", new { area = "Customer" });
                    }
                    else
                        return Content("Registration is not successful...Please try again...");
                }
                else
                    return View(Model);
            }
            else
            {
                // TempData["msg"] = "Already Claimed the Amount Please check";
                //Session["userId"] = UserId;
                //TempData["UserId"] = UserId;
                //return RedirectToAction("Index", "Home", new { area = "Customer" });
                TempData["msg"] = "Already Claimed the Amount Please check";
                TempData["UserId"] = Claimpolicy.UserId;
                return RedirectToAction("Index", "Home", new { area = "Customer" });
                //return Content("<script language='javascript' type='text/javascript'>alert('Already Claimed the Amount Please check');</script>");

            }

        }
    }
}