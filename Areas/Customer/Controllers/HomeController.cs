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
    public class HomeController : Controller
    {
        CaseStudyEntities1 dbObj = new CaseStudyEntities1();
        int a; 
        // GET: Customer/Home
        public ActionResult Index()
        {
            var data = TempData["UserId"];
           // ViewBag.UserId = TempData["UserId"];
           Session["userId"] = data;
            return View();
        }
        [HttpGet]
      
        public ActionResult Application()
        {
            CustomerPolicyDetail users = new CustomerPolicyDetail();
            List<PolicyDetail> list = new List<PolicyDetail>();
            var items = dbObj.PolicyDetails.ToList();
            ViewBag.Name = new SelectList(items, "PolicyId", "PolicyName");
            
            List<object> tempLIst = new List<object>();
            tempLIst.Add("HalfYearly");
            tempLIst.Add("Quarterly");
            tempLIst.Add("Yeary");

            ViewBag.Term = new SelectList(tempLIst, "policyTerm");
            List<object> Relation = new List<object>();
            Relation.Add("Father");
            Relation.Add("Mother");
            Relation.Add("Wife");
            Relation.Add("Husband");
            ViewBag.Rel = new SelectList(Relation, "relation");


            if (users != null)

                return View();
            else
                return Content("OOPS....<br/>There are some network issues...please connect after sometime");
        }
        [HttpPost]
        public ActionResult GetMaturity(int PolicyId)
        {
            Session["PolicyId"] = PolicyId;
            int UserId = (int)Session["userId"];
            CaseStudyEntities1 dbObj = new CaseStudyEntities1();
            var customerpolicy = dbObj.Vw_customerpolicydetails.FirstOrDefault(m => m.UserID == UserId);
            if (customerpolicy == null)
            {
                List<PolicyCoverage> selectlist = dbObj.PolicyCoverages.Where(x => x.PolicyID == PolicyId).ToList();
                ViewBag.PolicyCovAmount = new SelectList(selectlist, "PolicyAmount", "PolicyAmount");

                return PartialView("GetMaturity");
            }
            else 
            {
               // return Content("OOPS....<br/>There are some network issues...please connect after sometime");
                TempData["msg"] = "Already taken the policy Please Check the Policy Taken Details section...";
                TempData["UserId"] = UserId;
                return RedirectToAction("Index", "Home", new { area = "Customer" });
                //return Content("<script language='javascript' type='text/javascript'>alert('Already taken the policy Please Check the Policy Taken Details section...');</script>");
            }
           
          
           
        }
        [HttpGet]
        public ActionResult Duration(int PolicyAmount)
        {
            Session["PolicyAmount"] = PolicyAmount;
            CaseStudyEntities1 dbObj = new CaseStudyEntities1();
            // int Policyamount = Convert.ToInt32(PolicyAmount);
            //List<PolicyCoverage> selectlist = dbObj.PolicyCoverages.Where(x => x.PolicyAmount == PolicyAmount).ToList();
            //ViewBag.Duration = new SelectList(selectlist, "PolicyDuration", "PolicyDuration");
            PolicyCoverage PolicyData = dbObj.PolicyCoverages.FirstOrDefault(m => m.PolicyAmount == PolicyAmount);
            List<int> Policydata = new List<int>();
            Policydata.Add((int)PolicyData.PolicyDuration);
            Policydata.Add((int)PolicyData.PolicyCoverageAmount);
            Session["Duration"] = PolicyData.PolicyDuration;
            //return View();
            return Json(Policydata, JsonRequestBehavior.AllowGet);

        }
        public ActionResult UserTerms(string PolicyTerm)
        {
            string Term = PolicyTerm;
            int Duration = (int)Session["Duration"];
            int PolicyAmount = (int)Session["PolicyAmount"];
            int UserTerms = 0;
            int PremiumAmount = 0;
            var PolicyId = (int)Session["PolicyId"];
            var UserId = dbObj.PolicyDetails.FirstOrDefault(m => m.PolicyID == PolicyId);
            a = (int)UserId.UserID;
            Session["ManagerId"] = a;
            //var Managerdata = from c in dbObj.UsersRegistrationDetails where c.UserID == a select c.Username;
            var Managername = dbObj.UsersRegistrationDetails.FirstOrDefault(m => m.UserID == a);
            string Manager = Managername.Username;
            if (Term == "HalfYearly")
            {
                UserTerms = Duration * 2;

            }
            else if (Term == "Quarterly")
            {
                UserTerms = Duration * 3;
            }
            else
            {
                UserTerms = Duration * 1;
            }
            PremiumAmount = PolicyAmount / UserTerms;
            List<object> TermDetails = new List<object>();
            TermDetails.Add(UserTerms);
            TermDetails.Add(PremiumAmount);
            TermDetails.Add(Manager);
            //return View();
            return Json(TermDetails, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Application(PolicyDetailCoverageModel Model)
        {
            CustomerPolicyDetail usertable = new CustomerPolicyDetail();
            // PolicyDetailCoverageModel Model = new PolicyDetailCoverageModel();
            int Userid = (int)Session["userId"];
            //int Userid = ViewBag.UserId;
           
           
                if (ModelState.IsValid)
                {
                    if (dbObj != null)
                    {
                        //dbObj.CustomerPolicyDetails.Add(userdetails);
                        usertable.UserID = Userid;
                        usertable.PolicyID = Model.PolicyID;
                        usertable.RegisterdDate = Model.RegisterdDate;
                        usertable.Duration = Model.PolicyDuration;
                        usertable.PolicyAmount = Model.Srlno;
                        usertable.PolicyTerm = Model.PolicyTerm;
                        usertable.UserNoTerms = Model.UserNoTerms;
                        usertable.PremiumAmount = Model.PremiumAmount;
                        usertable.NomineeName = Model.NomineeName;
                        usertable.NomineeRelation = Model.NomineeRelation;
                        usertable.ManagerID = (int)Session["ManagerId"];
                        Random R = new Random();
                        int num = R.Next();
                        usertable.RegisteredID = num;
                        TempData["msg"] = "Your Registration Id is :" + num;
                        // TempData.Keep("message");
                        // ViewBag.SuccessMessage = TempData["msg"];
                        Session["RegisterId"] = num;
                        dbObj.CustomerPolicyDetails.Add(usertable);
                        dbObj.SaveChanges();
                        //return View(Model);
                        TempData["UserId"] = usertable.UserID;
                       
                     return RedirectToAction("Index", "Home", new { area = "Customer" });
                    //return Content("<script language='javascript' type='text/javascript'>alert('Your application is successfully saved');</script>");
                    //return View();
                }
                else
                        return Content("Registration is not successful...Please try again...");
                }
                else
                    return View(Model);
           


            

            
        }
    }
}