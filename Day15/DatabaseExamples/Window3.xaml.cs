using DatabaseExamples.MyDataSetTableAdapters;
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
using System.Windows.Shapes;

namespace DatabaseExamples
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }
        MyDataSet ds; //here firstly MyDataSet is the name of the Typed DataSet which we made----secondaly the order should remain the same i.e we can't add Employee first as its a child table---here we don't need to create Connection and a DataAdapter because it is already initialized in the table eg for Departments table in file DataSet we have DepartmentsTableAdapter
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ds = new MyDataSet();
            DepartmentsTableAdapter daDeps = new DepartmentsTableAdapter(); //here we don't need to create Connection and a DataAdapter because it is already initialized in the table--just using it here
            daDeps.Fill(ds.Departments); //normally we were mentioning the .Tables in here which was generated during run time...but since we have that, therefore mentioning the table name directly

            EmployeesTableAdapter daEmps = new EmployeesTableAdapter(); //similarly for Employee
            daEmps.Fill(ds.Employees); //for Fill button

            dgEmps.ItemsSource = ds.Employees.DefaultView; //creating a default view for Employees table
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            EmployeesTableAdapter daEmps = new EmployeesTableAdapter();
            daEmps.Update(ds.Employees); //for Update button

        }
    }
}


//Hence the code we did in previous examples need notbe done while using Typed DataSet 
//-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
/*
 * 
 * Untyped Data - Which does not have any structure. Initially it is blank.
 * 
 * 
 * Typed Data - Will have the structure of the data with the constraints as well---the benifits of Typed is that we do not need to define the constraints like PK, Columns etc.
 * 
 * To create a Typed Data:-
 * 
 * Goto Projects in top---Add new item---Scroll and look for DataSet---Give a Name---Add---now it appears in the Solution Explorer---drop down that---Open Toolbox---drop down in DataSet---drag and drop DataTable---
 * Right Click on that---Add---Column---again Add---Key---etc...now delete that(Just for demo)---on screen Click Server Explorer---drag and drop the Tables in Tables from DB in here---by this the <connectionString> from App.config gets copied in our file---
 * If there is a relation between 2 tables then it is showed by a line---to establish new relation---right click on that line---Edit Relations--Choose Both Relation and Foreign Key Constraint---here Update Rule is....supose we update DeptNo in Departments Table, then what happens in the DeptNo in the Employee table---here if we choose Cascade, that means in the employees table it will also update DeptNo if it was updated in Departments Table--
 * ---for SetNull if we change DeptNo in Department then it will set Null in Employee table---for Default value it will set 0 ---choose Cascade---now in Delete Rule---Cascade will delete all the Employees in the Deptartments table---choose Cascade here---now for Accept/Reject Rule changes---it means that do you want to refelect that value which are changed in that---select Cascade---
 * 
 * 
 * Now Build your solution---now DataSet is ready for use---Now Add another form in the solution explorer---goto build---Add WPF---name it---Add---Make it as a start up project by double clicking App.xaml---edit StartupUri---Add 2 buttons for Fill and Update---now double click on it and code
 * 
 * 
 * Pesimistic Query - it is where we assume that others have made the changes in the DataSet
 * 
 * Optimistic Query - it is where we do not assume that others have made the changes in the DataSet
 */