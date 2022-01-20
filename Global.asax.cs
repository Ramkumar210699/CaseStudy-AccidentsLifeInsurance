using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;

namespace CaseStudy
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            App_Start.FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            App_Start.BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
