using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog(); //as soon as we load the assembly, a dialog box is loaded to select the assembly---this is a predefined method
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            Assembly asm = Assembly.LoadFile(openFileDialog1.FileName); //loading the assembly based on the file type


            //TaxCalculator t = new TaxCalculator();------as we do not have a class defined here(ReflectionExample) for this. Therefore we cannot use a class directly... 
            Type t = asm.GetType(asm.GetName().Name + ".TaxCalculator", true, true); //Therefore we use here a type which use asm.GetType() here which takes namespace and its method/type as parameters----asm.GetName() returns name of the assembly i.e its namespace----".TaxCalculator" is the name of the method defined in that namespace---3rd para true is to return an exception if any, 4th para is for returning if the ".TaxCalculator" was written as ".taxcalculator"(case sensitivity)
            object obj = Activator.CreateInstance(t); //this line is equivalent to TaxCalculator t = new TaxCalculator();-----to create an object we have a class called as Activator in chich we have taken .CreateInstance() which returns type as a parameter which is further returning us an object of that particular type---therefore as we cannot create an object directly, we are doing all this
            
          
            //t.Basic = 10000 ----as we have created an object but we cannot call the methods of that object directly. Therefore...
            PropertyInfo p = t.GetProperty("Basic");//we use .GetProperty() under PropertyInfo to call those properties
            
            p.SetValue(obj, 10000.00M, null); //this is similar to setting value of basic (In sir's DB Basic Column) as 10000 just like t.Basic = 10000
            MessageBox.Show(p.GetValue(obj, null).ToString()); //to retrive the value and display

            //MessageBox.Show(t.GetNetSal());
            MethodInfo m = t.GetMethod("GetNetSalary"); //now we want to call the next method in that type i.e GetNetSalary which is possible using MethodInfo
            decimal NetSal = (decimal)m.Invoke(obj, null); //here we are calling the method using .Invoke() which takes 1st para as an object, 2nd as array of para if any more methods were present inside it or its variables---here we take it as null because no methods in it
            //object[] objParams = new object[2]; ------if parameters we present inside that method then this is how we need to access them 
            //objParams[0] = 10;
            //objParams[1] = 20;

            //decimal NetSal = (decimal)m.Invoke(obj, objParams);
            
            MessageBox.Show(NetSal.ToString());
        }

    }
}
