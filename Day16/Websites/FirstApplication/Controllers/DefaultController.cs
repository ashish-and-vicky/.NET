using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//The View Folder name should match the controller name
namespace FirstApplication.Controllers
{ //All Controllers inherit from Controllers Class
    public class DefaultController : Controller //All controller end with the Suffix 'Controller'---while using the Controller we call it with the prefix i.e 'Default' and one of its function name eg. ....Default/Index
    { 
        // GET: Default
        public ActionResult Index() //this method is defined in the RouteConfig which further calls View() method----To add the View() method, right click on the Index()---Add View---In left select View---select MVC 5 View---Add---or---right click Default Folder in Views and Add --Add View---(Default1 folder if added in the Views Folder which is a controller---delete it because the name of controller 'Default' should match with the View we are using)---look for the 'View name:' should match Index here---
                                    //--in Template select Empty(without model)---Tick Use a Layout---OK---after this, in Content folder bootstrap files will be added---In Views folder 'Index.cshtml' file will be added---as we Ticked Add Layout page---it is added in Shared Folder(it is a file where html tags are automatically added internally. It consists of a @RenderBody(used only once per Layout page) method in that internally in it. If we add anything in that file, then it goes over there in it. If we have Unticked it than a Layout page with html tags will have been added )
        {
            return View();
        }
        //public string Index() -------...../Index should be written in the url
        //{
        //    return "Hello <b>World</b>";
        //}
        public ActionResult Method2()
        {
            return View();
        }

        //only receiving id
        //url will be http://localhost:57000/Controller/Action/Id
        public ActionResult First(int id=0) //id is taken here as a parameter--------if we do not pass id here----then it will take it as 'null' and return an error----for that we need to make it nullable by 'int id' or we can pass a default value by 'int id=0'---which means if we do not pass a value then it takes id as 0 by default
        {
            ViewBag.Id = id; //value is passed overhere from First.cshtml---ViewBag is bringing the values from there to here---this will be printed here
            return View();
        }

        //receiving other parameters
        //url will be http://localhost:57000/Controller/Action/Id?a=10&b=20&c=Vik

        public ActionResult Second(int id = 0, int a=0, int b=0, string c= "") //as other para are not mentioned in the RouteConfig.cs file---it will be taken as a query
        { //values are passed overhere from Second.cshtml
            ViewBag.Id = id; 
            ViewBag.a = a;
            ViewBag.b = b;
            ViewBag.c = c;

            return View();
        }
    }
}

//TO DO: Create your own Layout Page and use it for one of the views we are creating
//Hint: Create the Layout in the Shared folder by right clicking and adding and add a @RenderBody in it


/*
 
Create a new project-- - Filter in the above 3 columns---C#, Windows, Web---Scroll for Asp.net Web Application(.NET Framework) ---Next---Give name---Next---in the right Tick MVC---select Empty---Next
---Now in the Controller---right click---Add---Controller---Empty Controller---Add---(Scaffolding comes which means some pre-requsite code is written in it)---



After running the Web App an IIS server is created which acts as our server and beholds the Web App we ran

while we run/build the app it is by default looking for some controller---Therefore for that it looks in the App_Start/RouteConfig.cs
*/