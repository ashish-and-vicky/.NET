using AuthenticationExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AuthenticationExample.Controllers
{
    public class LoginExampleController : Controller
    {
       
        [AllowAnonymous] //to allow anonymous user to enter login page
        // GET: LoginExample/Login
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]

        // POST: LoginExample/Login
        [HttpPost]
        public ActionResult Login(User u, string returnUrl)
        {
            if (ModelState.IsValid)
            {

                if (u.UserName == "a" && u.passWord == "b") //this authenticates if user was logged in or not---here we have hardcoded 
                {
                    FormsAuthentication.SetAuthCookie(u.UserName, false); //here we are setting the authentication with the user's username---now the user can visit wny page as its Username is authenticated(the user has logged in or not)---here 'false' means we are not creating a permanent cookie which means if the user logout and then again login he'll be directed to the home page
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home"); //this means Index/Home---if 'returnUrl' was by default left blank then it will take to Index/Home--here if the user wants to go to update profile directly, then he has to login 1st then he will be able to visit there directly.
                    }
                }
                else
                {
                    ModelState.AddModelError("authenticationError", "User name or Password is wrong. Try it again");
                }
            }
            return View(u);
        }

        [Authorize]
        [HttpGet]
        public ActionResult logOut()
        {
            FormsAuthentication.SignOut(); //when the user logout it removes the authentication cookies which was set above
            return RedirectToAction("Login");

        }
    }

}


/*

To create a custom authentication filter in ASP.NET MVC, we need to create a class 
that implements the IAuthenticationFilter Interface. This IAuthenticationFilter interface has 2 methods.
OnAuthentication
OnAuthenticationChallenge

Demo
https://www.c-sharpcorner.com/article/custom-authentication-filter-in-asp-net-mvc/
https://visualstudiomagazine.com/articles/2013/08/28/asp_net-authentication-filters.aspx
*/ 