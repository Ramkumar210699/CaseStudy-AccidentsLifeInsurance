﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CaseStudy.Models;
using CaseStudy.ViewModel;

namespace CaseStudy.Areas.Admin.Controllers
{
    public class ListofPolicyHoldersController : Controller
    {
        // GET: Admin/ListofPolicyHolders
        CaseStudyEntities1 dbObj = new CaseStudyEntities1();
        public ActionResult Index()
        {
            var table = new PolicyDetailsAll
            {
                vwcustomerPolicies = dbObj.Vw_customerpolicydetails.ToList(),

            };
            return View(table);
        }
    }
}