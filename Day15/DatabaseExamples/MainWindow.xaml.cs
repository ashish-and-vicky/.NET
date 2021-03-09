using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
//Refer Imp Links and Notes File to create DB
namespace DatabaseExamples
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection(); //creating an object of connection first
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true"; //Pooling=False";----For connecting server with Windows Authentication---for this path goto Server Explorer---right click the created DB---select Properties---copy the same path from Connection String---here Pooling is required when doing connection threading, but not for now
                                                                                                                          //cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;User Id=sa;Password=sa"; //For connecting server with SQL server Authentication

            //Data Source=(localdb)\MsSqllocalDb;Initial Catalog=JKDec20;Integrated Security=True;Pooling=False;---path copied from Server Explorer
            //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Trainings\JKDec20\Sample.mdf;Integrated Security=True;Connect Timeout=30; --------this is for when a new connection is added---Connect Timeout=30 means that the connection will try for max 30 sec
            cn.Open();

            SqlCommand cmd = new SqlCommand(); //to pass a command, its object is to be connected first
            cmd.Connection = cn; //connecting object with Sql Connection
            cmd.CommandType = CommandType.Text; //here the type of command we are passing is in text
            //cmd.CommandText = "insert into Employees values(1,'Vikram',10000, 10)";-----hard coding the values
            // )
            cmd.CommandText = "insert into Employees values(" + txtEmpNo.Text + ",'" + txtName.Text + "',"  //applying ' ' only with string
                + txtBasic.Text + "," + txtDeptNo.Text +  ")";//since DB takes integer by default, but here we have passed the parameter .Text() type---therefore we are passing text, but dosen't takes special char and while passing elements it can also take SQL queries called as SQL injection here and that is the problem in string concatination. Hence never use it.
            MessageBox.Show(cmd.CommandText);
            try
            {
                cmd.ExecuteNonQuery(); //returns the no. of rows affected---if error occurs which will happen here only, then msg will be shown---hence this is putted in a try catch block
                MessageBox.Show("okay");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }



            cn.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true";

            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            //PreparedStatements
            cmd.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";//for maintaining security so that all developers do not get access to access the DB, PreparedStatements are used. This solves the problem of special char, SQL injection passed as elements.
            //PreparedStatements are used when Stored Procedures are not available

            cmd.Parameters.AddWithValue("@EmpNo", txtEmpNo.Text);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Basic", txtBasic.Text);
            cmd.Parameters.AddWithValue("@DeptNo", txtDeptNo.Text);

            //MessageBox.Show(cmd.CommandText);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("okay");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }



            cn.Close();

        }
        //Open Server Explorer---drop down Database Connections---right click on Stored Procedures---Add Stored Procedure---CREATE PROCEDURE [dbo].InsertEmployee@EmpNo int,@EmpName varchar(50) AS insert into Employee values(@EmpNo, @EmpName) RETURN 0---click Update---then close the window
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true";

            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "InsertEmployee";  //we just need to pass the name of the Stored Procedure here in this---Stored Procedure should always be taken in consideration

            cmd.Parameters.AddWithValue("@EmpNo", txtEmpNo.Text);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@Basic", txtBasic.Text);
            cmd.Parameters.AddWithValue("@DeptNo", txtDeptNo.Text);

            //MessageBox.Show(cmd.CommandText);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("okay");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            cn.Close();


        }

        //TO DO: Try passing stored procedures for Update(update Employee set EmpName = @EmpName, DeptNo = @DeptNo where EmpNo = @EmpNo) and Delete(delete from Employee where EmpNo = 1);


        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true";
            cn.Open();
            SqlTransaction t = cn.BeginTransaction(); //we want both below commands to work successfully called transaction, else rollback---hence by declaring this we compulsary put the process in Transaction
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.Transaction = t; //putting command in a Transaction
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Employees values(300,'new emp',12345,10)";
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = cn;
            cmd2.Transaction = t; //putting command in a Transaction
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "insert into Employees values(300,'new emp2',12345,10)";
            try
            {
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                t.Commit(); //this means if both the commands are fine then commit them
                MessageBox.Show("commit");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                t.Rollback(); //if either of them does not work then throw error
            }
            finally
            {
                cn.Close();
            }

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true";

            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            //count(*) type of commands that return a single value is called as a Aggrigate value
            MessageBox.Show(cmd.ExecuteScalar().ToString()); //ExecuteScalar will return single value of 1st Row, 1st Column i.e the top left single value
            cn.Close();
        }
    }
}