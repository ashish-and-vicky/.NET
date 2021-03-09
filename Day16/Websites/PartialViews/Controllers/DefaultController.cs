using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartialViews.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly] //if we write this, then we will not be able to call the PartialView independently, but we will only be able to use it when we call it---we should call it whenever we find when the code is being repeated
        public ActionResult PartialView1() //here we are able to call the partial view we have created
        {

            return View();
        }
    }
}