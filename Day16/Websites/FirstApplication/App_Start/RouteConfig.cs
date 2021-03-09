using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FirstApplication
{
    public class RouteConfig //This method is called in Global.asax.cs file Application_Start() which has RouteConfig... method for calling it---
    {
        public static void RegisterRoutes(RouteCollection routes) //RouteConfig.RegisterRoutes(RouteTable.Routes); calling function from Global.asax.cs is received here as a collection(Collection of Routes are formed here)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute( //After Application_Start() runs, it loads the default through this.
                name: "Default",
                url: "{controller}/{action}/{id}", //the controller should be provided in this format
                defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional } //localhost:57000/Default/Index-----here we has assigned 'Index' as default route---hence if we write localhost:57000/Default then it will automatically take Index
            ); //in the above statement, id is ignored because it is marked as optional---if not provided than it is ok 
        }
    }
}
