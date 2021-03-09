using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project1
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqllocalDb;Initial Catalog=JKDec20;Integrated Security=True";

            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT INTO Employee VALUES (" + txtId.Text + "," + txtEmpNo.Text + ",'" + txtEmpName.Text + "')";

            MessageBox.Show("Done");
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Done Right");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            cn.Close();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SqlConnection cn1 = new SqlConnection();
            cn1.ConnectionString = @"Data Source=(localdb)\MsSqllocalDb;Initial Catalog=JKDec20;Integrated Security=True";

            cn1.Open();

            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = cn1;
            cmd1.CommandType = System.Data.CommandType.StoredProcedure;
            cmd1.CommandText = "Insert";

            cmd1.Parameters.AddWithValue("@Id", txtId.Text);
            cmd1.Parameters.AddWithValue("@EmpNo", txtId.Text);
            cmd1.Parameters.AddWithValue("@EmpName", txtId.Text);

            MessageBox.Show("Done Insert");
            try
            {
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Done Right");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}


