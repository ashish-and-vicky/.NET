using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FiltersExample.Controllers
{
    //[HandleError]----------when we give to show our custom error pages, this then it will find the page(Error.cshtml ViewBag) where this error page is there
    public class ExceptionFilterExampleController : Controller
    {
        // GET: ExceptionFilterExample

        //[HandleError]---------if there are multiple error pages and we want to run this method only then we mention this 
        [MyErrorHandler] //this is used when we want to generate our own handled exception error class or when we want to generate our own additional exception handling code 
        public ActionResult Index(int ID = 0)
        {
            //some code here
            int i = 100;
            i = i / ID;
            return View();
        }
    }
}