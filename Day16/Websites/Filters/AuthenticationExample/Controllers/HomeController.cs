using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthenticationExample.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Authorize] //this means if the user has not logged in then throw him to the login page---this actually blocks the unauthorized user to visit certain pages
        public ActionResult Index()
        {
            return View();
        }


        [Authorize]
        public ActionResult UpdateProfile()
        {
            return View();
        }


        [AllowAnonymous] //here we have allowed Anonymous
        public ActionResult Register()
        {
            return View();
        }
        [NonAction] //here if the user tries to call this method in the url, then this annotation will not allow him to do o
        public ActionResult DoSomething()
        {
            return View();
        }
    }
}