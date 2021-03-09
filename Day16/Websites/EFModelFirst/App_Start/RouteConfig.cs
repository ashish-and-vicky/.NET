using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EFModelFirst
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}



/*
 
 Now for DB---goto Project above---Add New Item---in the left goto Data---ADO.NET Entity Data Model---give name---Add---Empty EF Designer model---Next----------rest code is same as before

---open Toolbox---drag drop Entity---right click id---Add New---Scalar Property---again drag drop 2nd Entity---right click id---Add New---Add Association---Entity1---Entity2---Multiciplity 1(One)---Multiciplity Many---Tick Foreign Key---Add--
right click in blank space outside---Generate Database from Model---New Connection-------same as before---
---right click---Add Code Generation---EF 6.x---it generates classes for us---
 
 
 */
