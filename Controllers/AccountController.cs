using CaseStudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaseStudy.Controllers
{
    public class AccountController : Controller
    {
        CaseStudyEntities1 dbObj = new CaseStudyEntities1();
        // GET: Account
        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Registration()
        {
            return View();
        }

            [HttpPost]
        public ActionResult Login(UsersRegistrationDetail User)
        {
            //CaseStudyEntities usersEntities = new CaseStudyEntities();
            var searchUser = dbObj.UsersRegistrationDetails.FirstOrDefault(u => u.Username == User.Username && u.UserPassword == User.UserPassword && u.UserType == User.UserType);
            if (searchUser != null)
            {
                Session["username"] = searchUser.Username;
                Session["userType"] = searchUser.UserType;
                Session["userId"] = searchUser.UserID;
                //TempData["UserId"]= searchUser.UserID;
                int usrtype = (int)Session["userType"];
                switch (usrtype)
                {
                    case 1:
                        {
                           TempData["UserId"] = Session["userId"];
                            return RedirectToAction("Index", "Home", new { area = "Admin" });

                        }
                    case 2:
                        {
                            TempData["UserId"] = Session["userId"];
                            return RedirectToAction("Index", "Home", new { area = "Manager" });

                        }
                    case 3:
                        {
                            TempData["UserId"] = Session["userId"];
                            return RedirectToAction("Index", "Home", new { area = "Customer" });

                        }
                    default:
                        
                        return RedirectToAction("InvalidLogin", "Account");

                }

            }
            else
            {
                Session.Clear();
                Session.Abandon();

                return RedirectToAction("InvalidLogin", "Account");
            }
        }
        public ActionResult InvalidLogin()
        {
            Session.Clear();
            Session.Abandon();
            ViewBag.ErrMsg = "Invalid User Credentials, Please login again";
            return View();

        }

    }
}