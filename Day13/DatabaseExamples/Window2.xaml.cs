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
//DataAdaptor - while the DataSet is initialized then it first countionusly 'Fills' the DB (in a DataTable)(it has a function called Fill()) and then it 'Updates'.
namespace DatabaseExamples //In this example we will try to display the data in the DataGrid
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }
        DataSet ds; //we have declared DataSet over here because we do not want it to be destroyed as soon as the button click is done---therefore we have kept it Global
        private void Button_Click(object sender, RoutedEventArgs e) //This button is for filling the DataSet(ListGrid)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true";

            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Employees";

            SqlDataAdapter da = new SqlDataAdapter(); //First initializing the DataAdaptor----it has 4 commands SELECT, INSERT, UPDATE, DELETE
            da.SelectCommand = cmd; //while firing the select query the DataAdapter can connect to DB at any time, as select commands need DB access/connectivity as if its the owner of the house with door keys

            ds = new DataSet();
            da.Fill(ds, "Emps"); //here DataSet has created a table in which it has filled with the select query passed above---while creating a data table it will not give it a name---therefore we are giving it a name as "Emps" just for demonstration that Emps(DataSet table name) and data table name is not equal
            //Note: for .Fill()---while the connection was open then the DataAdaptor will use that connection and after fill is over, it will leave the connection open after it is finished---but if the connection was closed then the .Fill() will open the connection, do the Fill operation and as soon as the Fill is over it will close the connection. Therefore while using DataAdaptor we don't need to use Open() & Close() connections but for a single operation only. If multiple Fills are there then use it
            cmd.CommandText = "select * from Departments";
            da.Fill(ds, "Deps");

//Now here we want to add validations in the DataSet in the ListGrid we created

            //primary key validation------for creating validations in the table for PK specially we do below code---now by this if we try to enter duplicate EmpNo in the DataGrid then it will show error
            DataColumn[] arrCols = new DataColumn[1]; //here we have input as [1] beacuse we have only one PK, if we would have 2 PK then we would have passed [2]
            arrCols[0] = ds.Tables["Emps"].Columns["EmpNo"]; //Note: Every data table has a collection called 'Columns'---now here we want to refer to the EmpNo column, in the Emps DataTable, of the DataSet
            ds.Tables["Emps"].PrimaryKey = arrCols; //since every column has a primary key, hence it is mentioned here, which takes array of columns as a parameter because there might be possibility that there might be a composite value i.e eg 2 values forming a primary key. Hence we have passed array of data columns here


            //foreign key validation---here we want that DeptNo we are entering in the employee data table must match with one of the DeptNo that is there in my Departments data (Creating DataRelation just like in diagram) 
            ds.Relations.Add(ds.Tables["Deps"].Columns["DeptNo"], ds.Tables["Emps"].Columns["DeptNo"]);//---the DataSet has a collection called 'Relations'---now to establish the relation, the DeptNo in Employees should be connected to the DeptNo in Department---a red symbol will be shown after adding the dame deptno in one column in a data grid


            //column level constraints ---here we want that the DeptName should not be duplicate ---means duplicates in the same column should not be allowed
            //ds.Tables["Deps"].Columns["DeptName"].Unique = true;

//Now here we want to display the items selected by the above SQL queries to be displayed in the DataGrid. Therefore...

            //dgEmps.ItemsSource = ds.Tables[0].DefaultView;-------dgEmps is the name of the DataGrid in Windows2.xaml---ds.Tables[0] is the index no of the first Column---we are passing that by index here---below we are passing it by name
            dgEmps.ItemsSource = ds.Tables["Emps"].DefaultView; //this is a better syntax because if it has many data sets in there then confusion will occur---here ItemsSource requires a DataView(which allows filtering and sorting), so DefaultView is the default quality we get with DataView. Therefore it passes to view the data
            //dgEmps.ItemsSource = ds.Tables["Deps"].DefaultView;
            cn.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e) //this button is for Update
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true";

            cn.Open();
            //command for update 
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.Connection = cn;
            cmdUpdate.CommandType = CommandType.Text;
            cmdUpdate.CommandText = "update Employees set Name =@Name, Basic= @Basic, DeptNo = @DeptNo where EmpNo =@EmpNo"; //Note: EmpNo in the where clause should be Original and not be Current

            // cmdUpdate.Parameters.AddWithValue("@Name", txtName.Text);---this syntax which we used previously is used when command is called only once---and as here we are using DataSet then Insert, Update or Delete are called multiple times as DataSet was offline and we have made multiple changes using it---so below is the syntax for it

            //SqlParameter p = new SqlParameter();-----SqlParameter used for updating multiple values in a DataSet
            //p.ParameterName = "@Name";
            //p.SourceColumn = "Name";---suppose we changed/modified the ParameterName's Name in future------therefore we are using source column as Name for that
            //p.SourceVersion = DataRowVersion.Current;----when name is updated in the DataSet, then it stores Current value and Original value both --- now as over here we want current value except EmpNo, it is taken so --- we have to mention this command for every parameter eg Name, Basic, DeptNo
            //cmdUpdate.Parameters.Add(p);----adding the data in the DataAdapter
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current }); //this is similar to above code for Name as the parameters with .Current() values
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current }); //similarly for Basic and others
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });
            cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original }); //EmpNo should be taken as Original and not Current as it should remain old and rest param should be current---just like key value pair

            //similarly create the insert command

            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.Connection = cn;
            cmdInsert.CommandType = CommandType.Text;
            cmdInsert.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";

            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Current });
            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
            cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });

            //similarly create the delete command

            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.Connection = cn;
            cmdDelete.CommandType = CommandType.Text;
            cmdDelete.CommandText = "delete from Employees where EmpNo=@EmpNo";

            cmdDelete.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original }); //since the Original value has to be deleted. Therefore it is deleted

            SqlDataAdapter da = new SqlDataAdapter();

            da.UpdateCommand = cmdUpdate;
            da.InsertCommand = cmdInsert;
            da.DeleteCommand = cmdDelete;

            da.Update(ds, "Emps"); //this command is simalar to .Fill()---this command will initialize the DataAdapter and update the DataSet at last
        }
    }
}

private void Button_Click_2(object sender, RoutedEventArgs e)
{
    SqlConnection cn = new SqlConnection();
    cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true";

    cn.Open();

    SqlCommand cmdUpdate = new SqlCommand();
    cmdUpdate.Connection = cn;
    cmdUpdate.CommandType = CommandType.Text;
    cmdUpdate.CommandText = "update Employees set Name = @Name, Basic= @Basic, DeptNo = @DeptNo where EmpNo =@EmpNo";

    // cmdUpdate.Parameters.AddWithValue("@Name", txtName.Text);

    //SqlParameter p = new SqlParameter();
    //p.ParameterName = "@Name";
    //p.SourceColumn = "Name";
    //p.SourceVersion = DataRowVersion.Current;
    //cmdUpdate.Parameters.Add(p);
    cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
    cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
    cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });
    cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });

    //similarly create the insert command
    SqlCommand cmdInsert = new SqlCommand();
    cmdInsert.Connection = cn;
    cmdInsert.CommandType = CommandType.Text;
    cmdInsert.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";

    cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Current });
    cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
    cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
    cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });


    //similarly create the delete command
    SqlCommand cmdDelete = new SqlCommand();
    cmdDelete.Connection = cn;
    cmdDelete.CommandType = CommandType.Text;
    cmdDelete.CommandText = "delete from Employees where EmpNo=@EmpNo";

    cmdDelete.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });

    SqlDataAdapter da = new SqlDataAdapter();

    da.UpdateCommand = cmdUpdate;
    da.InsertCommand = cmdInsert;
    da.DeleteCommand = cmdDelete;

    //da.ContinueUpdateOnError = true;------------suppose da.Update gives an error in the middle while updating. Therefore to continue updating the values we do this.

    da.Update(ds, "Emps");

}

private void Button_Click_3(object sender, RoutedEventArgs e)
{
    SqlConnection cn = new SqlConnection();
    cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true";

    cn.Open();

    SqlCommand cmdUpdate = new SqlCommand();
    cmdUpdate.Connection = cn;
    cmdUpdate.CommandType = CommandType.Text;
    cmdUpdate.CommandText = "update Employees set Name =@Name, Basic= @Basic, DeptNo = @DeptNo where EmpNo =@EmpNo";

    // cmdUpdate.Parameters.AddWithValue("@Name", txtName.Text);

    //SqlParameter p = new SqlParameter();
    //p.ParameterName = "@Name";
    //p.SourceColumn = "Name";
    //p.SourceVersion = DataRowVersion.Current;
    //cmdUpdate.Parameters.Add(p);
    cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
    cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
    cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });
    cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });

    //similarly create the insert command
    SqlCommand cmdInsert = new SqlCommand();
    cmdInsert.Connection = cn;
    cmdInsert.CommandType = CommandType.Text;
    cmdInsert.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";

    cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Current });
    cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
    cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
    cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });


    //similarly create the delete command
    SqlCommand cmdDelete = new SqlCommand();
    cmdDelete.Connection = cn;
    cmdDelete.CommandType = CommandType.Text;
    cmdDelete.CommandText = "delete from Employees where EmpNo=@EmpNo";

    cmdDelete.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });

    SqlDataAdapter da = new SqlDataAdapter();

    da.UpdateCommand = cmdUpdate;
    da.InsertCommand = cmdInsert;
    da.DeleteCommand = cmdDelete;
    DataSet ds2 = ds.GetChanges();
    //DataSet ds2 = ds.GetChanges(DataRowState.Modified);--------(Undo changes)---if changes were made in a few columns---but DataAdapter checks all the records for update, hence to avoid that, GetChanges applies change to only those changed column---as this is for a few rows, it takes DataRowState as a para which is modified. Hence Modified is taken

    da.Update(ds2, "Emps");
}

private void Button_Click_4(object sender, RoutedEventArgs e)
{
    SqlConnection cn = new SqlConnection();
    cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=true";

    cn.Open();

    SqlCommand cmdUpdate = new SqlCommand();
    cmdUpdate.Connection = cn;
    cmdUpdate.CommandType = CommandType.Text;
    cmdUpdate.CommandText = "update Employees set Name =@Name, Basic= @Basic, DeptNo = @DeptNo where EmpNo =@EmpNo";


    cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
    cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
    cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });
    cmdUpdate.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });

    //similarly create the insert command
    SqlCommand cmdInsert = new SqlCommand();
    cmdInsert.Connection = cn;
    cmdInsert.CommandType = CommandType.Text;
    cmdInsert.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";

    cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Current });
    cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Name", SourceColumn = "Name", SourceVersion = DataRowVersion.Current });
    cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@Basic", SourceColumn = "Basic", SourceVersion = DataRowVersion.Current });
    cmdInsert.Parameters.Add(new SqlParameter { ParameterName = "@DeptNo", SourceColumn = "DeptNo", SourceVersion = DataRowVersion.Current });


    //similarly create the delete command
    SqlCommand cmdDelete = new SqlCommand();
    cmdDelete.Connection = cn;
    cmdDelete.CommandType = CommandType.Text;
    cmdDelete.CommandText = "delete from Employees where EmpNo=@EmpNo";

    cmdDelete.Parameters.Add(new SqlParameter { ParameterName = "@EmpNo", SourceColumn = "EmpNo", SourceVersion = DataRowVersion.Original });

    SqlDataAdapter da = new SqlDataAdapter();

    da.UpdateCommand = cmdUpdate;
    da.InsertCommand = cmdInsert;
    da.DeleteCommand = cmdDelete;


    da.Update(ds, "Emps");
    ds.AcceptChanges(); //Now as the chenges are made and updated, the DataSet has  make those Row State as Original---hence to do that we use this

}



private void Button_Click_5(object sender, RoutedEventArgs e)
{
    ds.RejectChanges(); //here in DataSet, Added changes will be rolled back, Deleted Changes state will change back to Unchanged and will remain in the table.
}

//Now here we want only the department records to show to the user. Hence we need to filter out certain records. Therefore for that we will need a 'DataView'

private void Button_Click_6(object sender, RoutedEventArgs e)
{
    //DataView dv = new DataView(ds.Tables["Emps"]);
    //dv.RowFilter = "DeptNo=" + txtDeptNo.Text;----------RowFilter is similar to whatever we give in where clause-----DataView can filter and sort
    //dv.Sort = "Name";---------------Sort is similar to whatever we give in order by clause
    //dgEmps.ItemsSource = dv;

//When we need to display the data at 2 different places, only then we need an additional view. Hence DataView should be used in there 
//Now if we don't want to create a DataView which comes with the table by default, then we use a DefaultView to show the data

    ds.Tables["Emps"].DefaultView.RowFilter = "DeptNo=" + txtDeptNo.Text;
    //ds.Tables["Emps"].DefaultView.RowFilter = "";-----since in above statement we have filtered the table view. Therefore for showing all the values back and removing the filter
}

private void Button_Click_7(object sender, RoutedEventArgs e)
{
    //MessageBox.Show(ds.GetXml());----will show the entire DataSet in XML format
    //ds.GetXmlSchema()----------this will show the entire data with the constraints of the data

//Now we want to save the DataSet in a file

    ds.WriteXmlSchema("a.xsd");
    ds.WriteXml("a.xml", XMLWriteMode.DiffGram); //DiffGram returns/saves RowState current value and new value both in that file saved   

}

private void Button_Click_8(object sender, RoutedEventArgs e)
{
    ds = new DataSet();
    ds.ReadXmlSchema("a.xsd");
    ds.ReadXml("a.xml", XmlReadMode.DiffGram);
    dgEmps.ItemsSource = ds.Tables["Emps"].DefaultView; //same as above but little different

}
    }
}
//To verify weather working properly or not---start/run the project from---enter/delete/update in the DataSet pop-up---click the Fill Dataset---click Update---go and check the DB weather updated or not 


/*     
                            RowState -- Initially the row state is unchanged. All these values will remain here until disconnected in the table
2	Ashish	1234.25	    20	    U
3	Pravin	5595.16	    10	    M -- for M, Update command will be called if values Updated
4	D'Souza	4455.6	    30	    U
100	Harshit	5946.5	    10	    D -- will only change to D, but row will be there --- for D, Delete command will be called ---- All the commands for this listed below will be called internally
200	Nidhi	59266.5	    10	    M
300	Akansha	5464.26	    10	    A -- for A, Insert command will be called


 

U = Unchanged
M = Modified
A = Added
D = Deleted


FOR THIS(U, I, D) this command will be passed by the DataAdapter automatically:-
Therefore we need to create these 3 commands for DataSet which will function on these to modify the above table when DataAdepter is called to Fill first

U ==> da.UpdateCommand = cmdUpdate-----------this row calls the update command
I ==> da.InsertCommand = cmdInsert 
D ==> da.DeleteCommand = cmdDelete

da.Update(ds, "Emps"); ---- this command is responsible for calling the above commands ----we are only telling if commands like U, M, A or D --- therefore the Grid will show the wrong value till it is Updated

Therefore for setting one connection(da.Update(ds, "Emps");) we need to pass 3 commands

 */