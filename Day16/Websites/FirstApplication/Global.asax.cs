using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FirstApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start() //This is the 1st method which runs when an application is runned. 
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes); //This is being sent to 'public static void RegisterRoutes(RouteCollection routes)' method in RouteConfig.cs file
        }
    }
}
