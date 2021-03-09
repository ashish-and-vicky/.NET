using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//LINQ - SQL is a ORM( Object Relational Mapper like Hibernate )------------------Here in ER Diagram, Tabls becomes(generates a) Class and Columns becomes(generates a) Properties---after creating a Class, it also creats a connection of a class eg we have a class of Employee, then it becomes a collection of Employees-----LINQ will read the values and put it into these collection to whichwe write LINQ queries to manipulate the collection
namespace LinqTOSql //i.e from 1) Table to Class -> 2) Class to Collection -> 3) Read the data from the collections and Manipulate through LINQ queries----at bottom are the steps to create LINQ queries 
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void insert_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext dbContext = new DataClasses1DataContext();
            Employee o = new Employee();


            try
            {
                o.EmpNo = Convert.ToInt32(txtEmpNo.Text);
                o.Name = txtName.Text;
                o.Basic = Convert.ToDecimal(txtBasic.Text);
                o.DeptNo = Convert.ToInt32(txtDeptNo.Text);
                dbContext.Employees.InsertOnSubmit(o);
                dbContext.SubmitChanges();
            }
            catch (InvalidEmpNoException ex)
            {
                MessageBox.Show(ex.Message);
            }

            catch (InvalidNameException ex)
            {
                MessageBox.Show(ex.Message);
            }

            catch (InvalidBasicException ex)
            {
                MessageBox.Show(ex.Message);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            dataGridView1.DataSource = dbContext.Employees;


        }

        private void update_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext dbContext = new DataClasses1DataContext();
            Employee o = dbContext.Employees.SingleOrDefault(emp => emp.EmpNo == Convert.ToInt32(txtEmpNo.Text));
            if (o != null)
            {
                try
                {
                    
                    o.Name = txtName.Text;
                    o.Basic = Convert.ToDecimal(txtBasic.Text);
                    o.DeptNo = Convert.ToInt32(txtDeptNo.Text);
                
                    dbContext.SubmitChanges();
                }

                catch (InvalidEmpNoException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                catch (InvalidNameException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                catch (InvalidBasicException ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else MessageBox.Show("Employee with given employee number doesnt exists");




        }

        private void btshow_Click(object sender, EventArgs e)
        {
             DataClasses1DataContext dbContext = new DataClasses1DataContext();

           
             DataTable dt = dbContext.Employees.ToDataTable();
             dt.Columns.Remove("Department");  
            dataGridView1.DataSource = dt;
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext dbContext = new DataClasses1DataContext();
            Employee o = dbContext.Employees.SingleOrDefault(emp => emp.EmpNo == Convert.ToInt32(txtEmpNo.Text));
            if (o != null)
            {
                    dbContext.Employees.DeleteOnSubmit(o);
                    dbContext.SubmitChanges();

            }
            else MessageBox.Show("Employee with given employee number doesnt exists");

        }
    }

    public static class ListHelper
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> list)
        {
            DataTable dt = new DataTable();
            Type listType = list.ElementAt(0).GetType();
            //get element properties nad datatable columns 
            PropertyInfo[] properties = listType.GetProperties();

            foreach (PropertyInfo property in properties)
                dt.Columns.Add(new DataColumn() { ColumnName = property.Name });
            foreach (object item in list)
            {
                DataRow dr = dt.NewRow();
                foreach (DataColumn col in dt.Columns)
                    dr[col] = listType.GetProperty(col.ColumnName).GetValue(item, null);
                dt.Rows.Add(dr);
            }

            return dt;
        }
    }

}



//File at top---New Project---WPF App---Project at top---Add New Item---Scroll for LINQ to SQL Classes---Give name---Add---1st step is to generate a Class from the Entities---open Toolbox---drop down Object Relational Design  or  Click Server Explorer---drag drop Tables---right click the line joining the tables---Edit Association---every time we do this or make a change then Build this by---Build above or Start---the App.config gets updated---connectionString will be generated there---now Open DataClass1.designer.cs file where the code is---
---
