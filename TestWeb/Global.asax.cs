using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace TestWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error()
        {
            var ex = Server.GetLastError();
            string message = $"Ha ocurrido una excepción, el mensaje es el siguiente: {ex.Message}";
            log.Error($"Ha ocurrido una excepción, el mensaje es el siguiente: {ex.Message}");
            Response.Clear();
            Server.ClearError();
            Response.Redirect(String.Format("~/Error/{0}/?message={1}", "", Server.UrlEncode(ex.Message)));

        }

    }
}
