using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DatabaseExamples
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqllocalDb;Initial Catalog=JKDec20;Integrated Security=true";

            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Employees";


            SqlDataReader dr = cmd.ExecuteReader(); //ExecuteReader to initialize data reader

            while (dr.Read()) //dr.Read() reads the record and places a record pointer (->) in the DataTable and returns true if it could read a record or false if could not read a record values
            {
                // dr.GetString(1)---this will directly return us the string as its return type is string---this is more efficient because this can be used in place of Add(dr["Name"] which returns an object
                //dr.GetInt32(0)---this returns an integer as a retun type

                lstNames.Items.Add(dr["Name"]); //this will read the data from the DataReader while we press the button---this will only go in the forward direction-----------lstNames is the name of the ListGrid
                //lstNames.Items.Add(dr[1]);
            }
            dr.Close(); //DataReader should be closed once the data is read successfully 

            cn.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true";

            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Employees; select * from Departments";


            SqlDataReader dr = cmd.ExecuteReader();
            lstNames.Items.Add("EMPS"); //EMPS is sir's Employees Table name

            while (dr.Read())
            {
                lstNames.Items.Add(dr["Name"]);
            }

            lstNames.Items.Add("DEPTS"); //DEPTS is sir's Departments Table name

            dr.NextResult(); //this will shift the pointer of DataReader to the next set of records or table---as we have passed 2 sql queries above---this also returns True and False
            while (dr.Read())
            {
                lstNames.Items.Add(dr["DeptName"]);

            }

            dr.Close();

            cn.Close();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true;MultipleActiveResultSets=true";
            cn.Open();

            SqlCommand cmdDepts = new SqlCommand();
            cmdDepts.Connection = cn;
            cmdDepts.CommandType = CommandType.Text;
            cmdDepts.CommandText = "Select * from Departments";

            SqlCommand cmdEmps = new SqlCommand();
            cmdEmps.Connection = cn;
            cmdEmps.CommandType = CommandType.Text;

            SqlDataReader drDepts = cmdDepts.ExecuteReader();
            while (drDepts.Read()) //here we have nested DataReader i.e 2 DataReader, which by default does not allow 2 DataReaders to run togather---we have to manually allow it to read the data like that---we do that by writing 'MultipleActiveResultSets=true' (MARS) in the above cn.ConnectionString
            {
                lstNames.Items.Add(drDepts["DeptName"]);

                cmdEmps.CommandText = "Select * from Employees where DeptNo = " + drDepts["DeptNo"];
                SqlDataReader drEmps = cmdEmps.ExecuteReader();
                while (drEmps.Read())
                {
                    lstNames.Items.Add("    " + drEmps["Name"]);
                }
                drEmps.Close();
            }
            drDepts.Close();
            cn.Close();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SqlDataReader dr = GetDataReader();
            while (dr.Read())
            {
                lstNames.Items.Add(dr["Name"]);
            }
            dr.Close(); //here the connection is closed---and the connection that DataReader was using is closed by CommandBehavior.CloseConnection
            //MessageBox.Show(cn.State.ToString()); ---to display the state of the connection
        }

        private SqlDataReader GetDataReader()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Employees";
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); //CommandBehavior.CloseConnection closes the connection and the undermine connection which the data reader was using.
            //SqlDataReader dr = cmd.ExecuteReader();
            //cn.Close(); ---a problem was there while Closing the connection here---if we closed it here, then the SQL connection will not be able to connect---therefore to solve the problem---the above code is written
            return dr;
        }
    }
}