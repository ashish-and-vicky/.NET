using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//below is the demonstration of writing a LINQ( Language Integrated Query ) query to a DataSet----therefore to do that firstly we need to call a data table as AsEnumerable so that we now write a query on that---secondaly once we write the data into that data query and then convert that into the data table
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       //SqlConnection cn = new SqlConnection("Data Source=.;Integrated Security=true;Initial Catalog=Suraj ");
        SqlConnection cn = new SqlConnection();


        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter();

        private void Form1_Load(object sender, EventArgs e)
        {
            cn.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
            cn.Open();    
            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.Connection = cn;
            cmdSelect.CommandType = CommandType.Text;
            cmdSelect.CommandText = "select * from employees";

            da.SelectCommand = cmdSelect;
            da.Fill(ds, "Emps");

            cmdSelect.CommandType = CommandType.Text;
            cmdSelect.CommandText = "Select* from Departments";
            da.Fill(ds, "Deps");

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //AsEnumerable converts ds.table to ienumerable<t> collection which is of type/return EnumerableRowCollection
            var recs = ds.Tables["Emps"].AsEnumerable(); //here we are doing this explicitly

            //Therefore now recs have collection of data row

            //emp is single row in data row collection

            //var emps = from emp in recs                             ---------------as emp here is a data row and a 'row' which can have any number of columns(as in a row there are number of columns)
            //           where emp.Field<Decimal>("Basic") > 1000     ---------------therefore here we have taken Field<Decimal> mentioned here taking column specifically with its data type
            //           select emp;                                  ---------------here we are selecting the whole DB----suppose we wanted any 1 column then emp.Field<data-type>("<column-name>")----for 2 column select new { emp.Field<data-type>("<column-name>"), emp.Field<data-type>("<column-name>") }---this whole things data type becomes anonymous

            var emps = from emp in recs
                       where emp.Field<int>("DeptNo")== 10
                       select emp;

//Now we want to convert Emps back into data table

            DataTable dt = emps.CopyToDataTable(); //CopyToDataTable converts it back---

            dataGridView1.DataSource = dt;
            //dataGridView1.ItemsSource = dt.DefaultView; --------in WPF we needed to do this

        }

        private void button2_Click(object sender, EventArgs e)
        {

            //create new table
            //loop through emps
            //add rows to this table here rows have number and basic

            var recs = ds.Tables["Emps"].AsEnumerable();
            var emps = from emp in recs
                       where emp.Field<Decimal>("Basic") > 10000
                       select new { number = emp.Field<int>("EmpNo"), basic = emp.Field<Decimal>("Basic") }; //here when we have certain columns then we don't have CopyToDataTable method available----here the query will work, but converting it back to data table will not----so to do that ListHelper class is written below

            DataTable dt = emps.ToDataTable(); //using the below method here for conversion----i.e if we are using a anonymous data type(above), then this converts it into a data table

            dataGridView1.DataSource = dt;

        }

        private void button3_Click(object sender, EventArgs e) //this method is the demonstration of the internal method that is going behind ToDataTable---hence to avoid using this set of code, we are using ToDataTable
        {
            var recs = ds.Tables["Emps"].AsEnumerable();
            var emps = from emp in recs
                       where emp.Field<Decimal>("Basic") > 10000
                       select new { number = emp.Field<int>("EmpNo"), basic = emp.Field<Decimal>("Basic") };

            DataTable dt = new DataTable(); //here we are creating a new data table and adding 2 columns in it
            dt.Columns.Add("Basic", Type.GetType("System.Decimal"));
            dt.Columns.Add("EmpNo", Type.GetType("System.Int32"));

            foreach (var item in emps)
                dt.Rows.Add(item.basic, item.number); //after traversing through all the employees, we are now adding a row to the above data table

            dataGridView1.DataSource = dt;

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }


       
     
    }
    public static class ListHelper
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> list) //this method converts the Fields into data tables---it uses reflection---IEnumerable is mentioned because it should accept all types of collection
        {
            DataTable dt = new DataTable();
            Type listType = list.ElementAt(0).GetType();
            //get element properties nad datatable columns 
            PropertyInfo[] properties = listType.GetProperties();

            foreach (PropertyInfo property in properties) //
                dt.Columns.Add(new DataColumn() { ColumnName = property.Name }); //here each property is getting converted into column----i.e it is taking it as an Anonymous type and converting it into a data row which has these column
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
