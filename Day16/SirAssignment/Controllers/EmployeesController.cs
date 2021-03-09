using ModelBindingAndDbCode.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelBindingAndDbCode.Controllers
{
    public class EmployeesController : Controller
    {

        // GET: Employees
        public ActionResult Index() //Corresponds to Template: List---------------here to pass the id as EmpNo we have used ActionLink in the bottom
        {
            /*   List<Employee> objEmpList = new List<Employee>(); //-------------------here values are hardcoded
               objEmpList.Add(new Employee { EmpNo = 1, Name = "V", Basic = 1234, DeptNo = 10 });
               objEmpList.Add(new Employee { EmpNo = 2, Name = "A", Basic = 1234, DeptNo = 10 });
               objEmpList.Add(new Employee { EmpNo = 3, Name = "B", Basic = 1234, DeptNo = 10 }); 

               return View(objEmpList);
            */
            List<Employee> emplist = new List<Employee>();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqllocalDb;Initial Catalog=JKDec20;Integrated Security=True;";

            cn.Open();

            SqlCommand cmd = new SqlCommand("Select * from Employees", cn);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                emplist.Add(new Employee { EmpNo = (int)dr["EmpNo"], Name = (string)dr["Name"], Basic = (decimal)dr["Basic"], DeptNo = (short)(int)dr["DeptNo"] });
            }
         
            cn.Close();

            return View(emplist);
        }

        //TO DO: Take Values from DB tables over here

        // GET: Employees/Details/5
        public ActionResult Details(int EmpNo=0) //Corresponds to Template: Details ----as in its view object, Details is accepting Employee object---hence we are passing Employee object here---hard coding for now---later will be read from the DB
        {
            /*Employee objEmp = new Employee();
            objEmp.EmpNo = 123;
            objEmp.Name = "Vik";
            objEmp.Basic = 12345;
            objEmp.DeptNo = 10;
            return View(objEmp); //as View takes object model as a parameter
            */

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqllocalDb;Initial Catalog=JKDec20;Integrated Security=True;";
            cn.Open();

            SqlCommand cmd = new SqlCommand("Select * from Employees where EmpNo = " + EmpNo, cn);

            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            //while (dr.Read()) { 
            Employee emp = new Employee { EmpNo = (int)dr["EmpNo"], Name = (string)dr["Name"], Basic = (decimal)dr["Basic"], DeptNo = (short)(int)dr["DeptNo"]};
           // }

            cn.Close();
            return View(emp);
        }

        // GET: Employees/Create ----------------by default any method is of GET type
        [HttpGet] //-----------------------------------------------------------Here 2 Create methods are there with 1) GET, 2) POST
        public ActionResult Create() //Corresponds to Template: Create
        {
            Employee emp = new Employee(); 
            return View(emp);
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(Employee objEmp) //Corresponds to Template: Details
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
                cmd.CommandText = "insert into Employees values (@EmpNo, @Name, @Basic, @DeptNo)";

                cmd.Parameters.AddWithValue("@EmpNo", objEmp.EmpNo);
                cmd.Parameters.AddWithValue("@Name", objEmp.Name);
                cmd.Parameters.AddWithValue("@Basic", objEmp.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", objEmp.DeptNo);

                cmd.ExecuteNonQuery();
                cn.Close();
                return RedirectToAction("Index");
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int EmpNo=0) //Corresponds to Template: Edit
        {
            /* Employee objEmp = new Employee();
               objEmp.EmpNo = 123;
               objEmp.Name = "Vik";
               objEmp.Basic = 12345;
               objEmp.DeptNo = 10;
               return View(objEmp);
             */

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqllocalDb;Initial Catalog=JKDec20;Integrated Security=True;";

            cn.Open();

            SqlCommand cmd = new SqlCommand("Select * from Employees where EmpNo = " + EmpNo, cn);

            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            Employee emp = new Employee { EmpNo = (int)dr["EmpNo"], Name = (string)dr["Name"], Basic = (decimal)dr["Basic"], DeptNo = (short)(int)dr["DeptNo"]};

            cn.Close();

            return View(emp);         
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(int EmpNo=0, Employee objEmp = null) //Corresponds to Template: Edit-----insted of FormController we are using Employee objEmp over here
        {
            //try
            //{
                // TODO: Add update logic here

                //int EmpNo =Convert.ToInt32(collection["EmpNo"]);----------------the values are being received here are of EmpNo from Employee of Edit.cshtml---similarly for Name, Basic & DeptNo.
                //string Name = collection["Name"];

                //string Name = objEmp.Name;

                //return RedirectToAction("Index");

                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=(localdb)\MsSqllocalDb;Initial Catalog=JKDec20;Integrated Security=True;";
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Employees set Name = @Name, Basic = @Basic, DeptNo = @DeptNo where EmpNo = @EmpNo";

                cmd.Parameters.AddWithValue("@EmpNo", EmpNo);
                cmd.Parameters.AddWithValue("@Name", objEmp.Name);
                cmd.Parameters.AddWithValue("@Basic", objEmp.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", objEmp.DeptNo);

                cmd.ExecuteNonQuery();
                cn.Close();
                return RedirectToAction("Index");
            //}
            //catch
            //{
                //return View();
            //}
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int EmpNo) //Corresponds to Template: Delete
        {
            /* Employee objEmp = new Employee();
             objEmp.EmpNo = 123;
             objEmp.Name = "Vik";
             objEmp.Basic = 12345;
             objEmp.DeptNo = 10;
             return View(objEmp);
            */

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqllocalDb;Initial Catalog=JKDec20;Integrated Security=True;";

            cn.Open();

            SqlCommand cmd = new SqlCommand("Select * from Employees where EmpNo = " + EmpNo, cn);
             
            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            Employee emp = new Employee { EmpNo = (int)dr["EmpNo"], Name = (string)dr["Name"], Basic = (decimal)dr["Basic"], DeptNo = (short)(int)dr["DeptNo"] };

            cn.Close();

            return View(emp);
        }

        // POST: Employees/Delete/5
        [HttpPost] //here the EmpNo is being passed as an id
        public ActionResult Delete(int EmpNo, Employee objEmp) //Corresponds to Template: Delete----here we want the id to delete an Employee---but code generated by VS while creating view is such that we cannot use this 'id' as it is outside from the form 
        {                                                   //only EmpNo will be received here in objEmp as we have used HiddenFor tag in its View component which was not included by default while generating View for Delete
            try
            {
                // TODO: Add delete logic here
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=(localdb)\MsSqllocalDb;Initial Catalog=JKDec20;Integrated Security=True;";

                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from Employees where EmpNo=@EmpNo";

                cmd.Parameters.AddWithValue("@EmpNo", objEmp.EmpNo);


                cmd.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
