using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.MyTypedDsTableAdapters;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        MyTypedDs ds = new MyTypedDs(); //hence from below function the DataSet ds has all the values

        private void Form2_Load(object sender, EventArgs e) //here the TableAdapter is filling a DataSet
        {
            DepartmentsTableAdapter daDeps = new DepartmentsTableAdapter();
            daDeps.Fill(ds.Departments);
            EmployeesTableAdapter daEmps = new EmployeesTableAdapter();
            daEmps.Fill(ds.Employees);

        }

        private void button1_Click(object sender, EventArgs e) //here since this a now a Typed DataSet, writing a query is quiet easier here
        {
           var recs = ds.Employees.AsEnumerable(); //like previous Form1.cs we are not mentioning here Tables
            var emps = from emp in recs
                       where emp.Basic > 1000 //and no mentioning of Fields
                       select emp;
            DataTable dt = emps.CopyToDataTable(); //after conversion coping data to data table

            dataGridView1.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var recs = ds.Employees.AsEnumerable();
            var emps = recs.Where(emp => emp.Basic > 10000).Select(emp => new { emp.EmpNo, emp.Basic }); //same as above---here it is written with functions(lambda)
            DataTable dt = emps.ToDataTable();

            dataGridView1.DataSource = dt;

        }
    }
}
