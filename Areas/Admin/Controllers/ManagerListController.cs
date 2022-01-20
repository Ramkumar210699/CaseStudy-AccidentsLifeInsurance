using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaseStudy.Models;
using CaseStudy.ViewModel;

namespace CaseStudy.Areas.Admin.Controllers
{
    public class ManagerListController : Controller
    {
        CaseStudyEntities1 dbObj = new CaseStudyEntities1();
        // GET: Admin/ManagerList
        public ActionResult Index()
        {
            var table = new PolicyDetailsAll
            {
                vwPolicydetls = dbObj.vw_PolicyDetails.ToList(),

            };
            return View(table);
        }
    }
}