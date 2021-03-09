using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EntityFrameworkExample;
/*
 Entity Framework does not comes with .NET, it has to be downloaded---for downloading a Entity Framework---
--goto above Tools---NuGet Package Manager---Manage NuGetPackages for Solution---Browse---EntityFramework---click EntityFramework(Entity Framework 6 (EF6))---on right side select for which project you want it to be installed---Tick EntityFrameworkExample---Install---OK---I Accept---


Now for DB---goto Project above---Add New Item---in the left goto Data---ADO.NET Entity Data Model---give name---Add---EF Designer from database---Next---select your Connection if not then New Connection---drop down Server name---type your server name if not comming---below Select DB name---Test Connection---OK--
--a connection string will be generated---Next---in Tables tick all the Tables---if you want stored procedures, tick it---Finish---Open Toolbox----drag drop Entities---ER Diagrams will appear---right click on(Departments) any one for viewing properties---
--Now goto Build above---Build Solution---Now Add a controller in Controller---MVC 5 Controller with views, using Entity Framework---select Model class---Employees(EntityFrameworkExamples)---Data context class---select the one which we created---Add
 

Entity Framework is similar to previous code where we used .NET framework but with different syntax
 
 */
namespace EntityFrameworkExample.Controllers
{
    public class EmployeesController : Controller
    {
        private JKDec20Entities db = new JKDec20Entities(); //we have created an DB to populate some values in it---here question arises from where the DB is getting loaded without specifing name?--Ans => In return View when the employee is returned to ToList at that time it is loaded and accessed to collection.---
        //---This concept is called as LazyLoading-----therefore it populates the DB when the 1st time we access any object using it---if we access on Employee, then only its objects are loaded in it

        // GET: Employees
        public ActionResult Index() 
        {
            var employees = db.Employees.Include(e => e.Department); //with Employees object, it also passes you the object of Departments
            
            return View(employees.ToList()); //all the objects are converted into a list here---
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); //if details not found then this will be shown
            }
            Employee employee = db.Employees.Find(id); //here we are trying to find Employee object based on id
            if (employee == null)
            {
                return HttpNotFound(); //if not found then it will return 404 Error 
            }
            return View(employee); //if found then return that view
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.DeptNo = new SelectList(db.Departments, "DeptNo", "DeptName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpNo,Name,Basic,DeptNo")] Employee employee) //binding specific properties
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeptNo = new SelectList(db.Departments, "DeptNo", "DeptName", employee.DeptNo);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeptNo = new SelectList(db.Departments, "DeptNo", "DeptName", employee.DeptNo);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit(Employee employee)

        //public ActionResult Edit([Bind(Exclude = "Department")] Employee employee)

        public ActionResult Edit([Bind(Include = "EmpNo,Name,Basic,DeptNo")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified; //if we make any changes then it will turn EntityState to modified---if commited then commited---if deleted, then it will turn to deleted
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeptNo = new SelectList(db.Departments, "DeptNo", "DeptName", employee.DeptNo);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")] //since the para passed in below is the same as get, so to differentate and tell that this POST method belongs to the above GET method, we write ActionName
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) //since for get both method have same parameter---hence post methods delete method is named as DeleteConfirmed for differentation---if same para were not there then Delete will only be called
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
