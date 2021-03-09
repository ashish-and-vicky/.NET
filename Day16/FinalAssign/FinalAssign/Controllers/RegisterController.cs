using FinalAssign.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalAssign.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            User user = new User();
            return View(user);
        }

        // GET: Register/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Register/Create
        public ActionResult Register()
        {
            User user = new User();
            return View(user);
        }

        // POST: Register/Create
        [HttpPost]
        public ActionResult Register(User user)
        {
            try
            {
                // TODO: Add insert logic here
                /* string Name = objEmp.Name; //-----------------In Edit we were passing an object. In create we are not passing an object, therefore values comming in here are blank. Hence we pass values when we build this.
                 return RedirectToAction("Index");
                */

                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=(localdb)\MsSqllocalDb;Initial Catalog=JKDec20;Integrated Security=True;";

                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into User values (@LoginName, @Password, @Confirm_Password, @FullName, @EmailID, @City, @Phone)";

                cmd.Parameters.AddWithValue("@LoginName", user.LoginName);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Confirm_Password", user.Confirm_Password);
                cmd.Parameters.AddWithValue("@FullName", user.FullName);
                cmd.Parameters.AddWithValue("@EmailID", user.EmailID);
                cmd.Parameters.AddWithValue("@City", user.City);
                cmd.Parameters.AddWithValue("@Phone", user.Phone);
                
                cmd.ExecuteNonQuery();
                cn.Close();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Register/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Register/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Register/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Register/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
