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
        DataSet ds;
        // GET: Employees
        public ActionResult Index()
        {
            List<Employee> emplist = new List<Employee>();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true;";

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

        // GET: Employees/Details/5
        public ActionResult Details(int id=0)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true;";

            cn.Open();

            SqlCommand cmd = new SqlCommand("Select * from Employees where EmpNo = " + id, cn);

            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            Employee emp = new Employee { EmpNo = (int)dr["EmpNo"], Name = (string)dr["Name"], Basic = (decimal)dr["Basic"], DeptNo = (short)(int)dr["DeptNo"] };

            cn.Close();
            return View(emp);
        }

        // GET: Employees/Create
        [HttpGet]
        public ActionResult Create()
        {
            Employee emp = new Employee();
            return View(emp);
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true;";

                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "InsertEmployee";

                cmd.Parameters.AddWithValue("@EmpNo", emp.EmpNo);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Basic", emp.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", emp.DeptNo);

                cmd.ExecuteNonQuery();

                return RedirectToAction("Index");
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id=0)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true;";

            cn.Open();

            SqlCommand cmd = new SqlCommand("Select * from Employees where EmpNo = " + id, cn);

            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            Employee emp = new Employee { EmpNo = (int)dr["EmpNo"], Name = (string)dr["Name"], Basic = (decimal)dr["Basic"], DeptNo = (short)(int)dr["DeptNo"] };

            

            return View(emp);
            cn.Close();
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee emp)
        {
            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true;";

                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UpdateEmployee";

                cmd.Parameters.AddWithValue("@EmpNo", emp.EmpNo);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Basic", emp.Basic);
                cmd.Parameters.AddWithValue("@DeptNo", emp.DeptNo);

                cmd.ExecuteNonQuery();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true;";

            cn.Open();

            SqlCommand cmd = new SqlCommand("Select * from Employees where EmpNo = " + id, cn);

            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            Employee emp = new Employee { EmpNo = (int)dr["EmpNo"], Name = (string)dr["Name"], Basic = (decimal)dr["Basic"], DeptNo = (short)(int)dr["DeptNo"] };

            cn.Close();

            return View(emp);
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee emp)
        {
            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true;";

                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "DeleteEmployee";

                cmd.Parameters.AddWithValue("@EmpNo", emp.EmpNo);


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
