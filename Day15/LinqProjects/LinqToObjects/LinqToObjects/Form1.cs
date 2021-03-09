using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqToObjects
{
    public partial class Form1 : Form
    {
        List<Employee> lstEmployees = new List<Employee>();
        List<Department> lstDepartments=new List<Department>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
    
            lstEmployees.Add(new Employee{EmpNo=1,Name="Suraj",Basic=90000,DeptNo=5,Gender="M"});
            lstEmployees.Add(new Employee{EmpNo=2,Name="Sagar",Basic=10000,DeptNo=2,Gender="M"});
            lstEmployees.Add(new Employee{EmpNo=3,Name="Mrunmayee",Basic=23000,DeptNo=5,Gender="F"});
            lstEmployees.Add(new Employee{EmpNo=4,Name="Rupali",Basic=14000,DeptNo=5,Gender="F"});
            lstEmployees.Add(new Employee{EmpNo=5,Name="Santosh",Basic=10000,DeptNo=1,Gender="M"});
            lstEmployees.Add(new Employee{EmpNo=6,Name="Ameya",Basic=60000,DeptNo=1,Gender="M"});
            lstEmployees.Add(new Employee{EmpNo=7,Name="Ashu",Basic=32000,DeptNo=3,Gender="M"});

            lstDepartments.Add(new Department{DeptNo=5,DeptName="DotNet"});
            lstDepartments.Add(new Department{DeptNo=2,DeptName="Testing"});
            lstDepartments.Add(new Department{DeptNo=1,DeptName="Finance"});
            lstDepartments.Add(new Department{DeptNo=3,DeptName="HR"});
            lstDepartments.Add(new Department{DeptNo=4,DeptName="BI"});

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
          
            
            var emps= from emp in lstEmployees select emp;
            //IEnumerable<Employee> emps = from emp in lstEmployees select emp;
            //List<Employee> emps = from emp in lstEmployees select emp;
            
            //type of left hand is iEnumerable<T>

            foreach (var item in emps)
                listBox1.Items.Add("Empno: " + item.EmpNo + ", Name: " + item.Name + ", Basic: " + item.Basic + ", DeptNum : " + item.DeptNo + ",Gender: " + item.Gender);
            
            //below code has emps1 of iEnumerable<string>

            //var emps1 = from emp in lstEmployees select emp.Name;
            //foreach (var item in emps1)
            //    listBox1.Items.Add("Name: " + item);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var emps = from emp in lstEmployees select new { emp.EmpNo,emp.Name};
            //in above query anonymous type is used and therefore we are forced to use 'var'

            foreach (var item in emps)
                listBox1.Items.Add("EmpNo: " + item.EmpNo+", Name : " + item.Name);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var emps = from emp in lstEmployees
                       where emp.Basic>20000
                       select emp;

            foreach (var item in emps)
                listBox1.Items.Add("Empno; " + item.EmpNo + "Name: " + item.Name + ", Basic: " + item.Basic + ", DeptNum : " + item.DeptNo+",Gender: "+item.Gender);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var emps = from emp in lstEmployees
                       where emp.Basic > 20000 && emp.Gender=="M"
                       select emp;

            foreach (var item in emps)
                listBox1.Items.Add("Empno; " + item.EmpNo + "Name: " + item.Name + ", Basic: " + item.Basic + ", DeptNum : " + item.DeptNo + ",Gender: " + item.Gender);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var emps = from emp in lstEmployees
                       where emp.Basic > 20000 || emp.Name.EndsWith("r")
                       select emp;

            foreach (var item in emps)
                listBox1.Items.Add("Empno; " + item.EmpNo + "Name: " + item.Name + ", Basic: " + item.Basic + ", DeptNum : " + item.DeptNo + ",Gender: " + item.Gender);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var emps = from emp in lstEmployees
                       orderby emp.Basic,emp.DeptNo,emp.Gender,emp.Name
                       select emp;

            foreach (var item in emps)
                listBox1.Items.Add("Empno; " + item.EmpNo + "Name: " + item.Name + ", Basic: " + item.Basic + ", DeptNum : " + item.DeptNo + ",Gender: " + item.Gender);
        
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var emps = from emp in lstEmployees
                       orderby emp.Basic descending, emp.DeptNo, emp.Gender descending, emp.Name ascending
                       select emp;

            foreach (var item in emps)
                listBox1.Items.Add("Empno; " + item.EmpNo + "Name: " + item.Name + ", Basic: " + item.Basic + ", DeptNum : " + item.DeptNo + ",Gender: " + item.Gender);
        
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            //var emps = from emp in lstEmployees
            //           join dept in lstDepartments
            //           on emp.DeptNo equals dept.DeptNo
            //           select new { emp,dept };

            //foreach (var item in emps)
            //    listBox1.Items.Add("Empno; " + item.emp.EmpNo+ "Name: " + item.emp.Name + ", Basic: " + item.emp.Basic + ", DeptNum : " + item.dept.DeptNo + ",DeptName: " + item.dept.DeptName);

            var emps = from emp in lstEmployees
                       join dept in lstDepartments
                       on emp.DeptNo equals dept.DeptNo
                       select new { emp.EmpNo,emp.Name,emp.Basic, dept.DeptNo,dept.DeptName };

            foreach (var item in emps)
                listBox1.Items.Add("Empno; " + item.EmpNo + "Name: " + item.Name + ", Basic: " + item.Basic + ", DeptNum : " + item.DeptNo + ",DeptName: " + item.DeptName);
        

        }

        private void button9_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            var emps = from emp in lstEmployees
                       group emp by emp.DeptNo into grpDeptNo
                       where grpDeptNo.Count() < 3
                       select new { grpDeptNo.Key, EmpCount = grpDeptNo.Count() };

            foreach (var item in emps)
                listBox1.Items.Add("Key:" + item.Key + "Count: " + item.EmpCount );

        }

        private void button10_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            var emps = from emp in lstEmployees
                       group emp by emp.DeptNo into grpDeptNo
                       select grpDeptNo;

            foreach (var item in emps)
            {
                listBox1.Items.Add("Key:" + item.Key + "Count: " + item.Count());
                foreach (var emp in item)
                    listBox1.Items.Add("----" + emp.Name);   
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            var emps = lstEmployees.Select(new Func<Employee, Result>(GetEmps));


            foreach (var item in emps)
                   listBox1.Items.Add("Empno: " + item.EmpNo + ", Name: " + item.Name );

        }

        Result GetEmps(Employee o) { 
            Result t=new Result();
            t.EmpNo=o.EmpNo ;
             t.Name=o.Name ;
            return t ; }

        private void button12_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var emps = lstEmployees.Select(emp => emp);
            foreach (var item in emps)
                listBox1.Items.Add("Empno: " + item.EmpNo + ", Name: " + item.Name + ", Basic: " + item.Basic + ", DeptNum : " + item.DeptNo + ",Gender: " + item.Gender);
          
        }

        private void button13_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var emps = lstEmployees.Select(emp => new {emp.EmpNo,emp.Name,emp.Basic });
            foreach (var item in emps)
                listBox1.Items.Add("Empno: " + item.EmpNo + ", Name: " + item.Name + ", Basic: " + item.Basic);
          
        }

        private void button14_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var emps = lstEmployees.Where(emp =>emp.Basic >20000);
            foreach (var item in emps)
                listBox1.Items.Add("Empno: " + item.EmpNo + ", Name: " + item.Name + ", Basic: " + item.Basic);
          
        }

        private void button15_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var emps = lstEmployees.Where(emp => emp.Basic > 20000).Select(emp => new { emp.EmpNo, emp.Name});
            foreach (var item in emps)
                listBox1.Items.Add("Empno: " + item.EmpNo + ", Name: " + item.Name );
          
        }

        private void button16_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var emps = lstEmployees.OrderBy(emp => emp.DeptNo).ThenBy(emp=>emp.Basic).ThenBy(emp=>emp.Gender) ;
            foreach (var item in emps)
                listBox1.Items.Add("Empno: " + item.EmpNo + ", Name: " + item.Name + ", Basic: " + item.Basic);
          
        }

        private void button17_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var emps = lstEmployees.OrderByDescending(emp => emp.DeptNo).ThenByDescending(emp => emp.Basic).ThenBy(emp => emp.Gender).ThenByDescending(emp=>emp.EmpNo);
            foreach (var item in emps)
                listBox1.Items.Add("Empno: " + item.EmpNo + ", Name: " + item.Name + ", Basic: " + item.Basic);
          
        }

        private void button18_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var emps = lstEmployees.Select(emp => new { emp.EmpNo, emp.Name, emp.Basic }).Where(emp => emp.Basic > 20000).OrderBy(emp => emp.Basic);

            foreach (var item in emps)
                listBox1.Items.Add("Empno: " + item.EmpNo + ", Name: " + item.Name + ", Basic: " + item.Basic);
          
        }

        private void button19_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            //var emps = from emp in lstEmployees
            //           join dept in lstDepartments
            //           on emp.DeptNo equals dept.DeptNo
            //           select new { emp.EmpNo, emp.Name, emp.Basic, dept.DeptNo, dept.DeptName };

            var emps = lstEmployees.Join(
                        lstDepartments,
                        emp => emp.DeptNo,
                        dept => dept.DeptNo,
                        (emp, dept) => new {emp,dept });
            //you can also give multiple column in new{ }
            foreach (var item in emps)
                listBox1.Items.Add("Empno; " + item.emp.EmpNo+ "Name: " + item.emp.Name + ", Basic: " + item.emp.Basic + ", DeptNum : " + item.dept.DeptNo + ",DeptName: " + item.dept.DeptName);

        }

        private void button20_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            
            var emps = lstEmployees.GroupBy(emp => emp.DeptNo).Select(emp=>emp);

            foreach (var item in emps)
            {
                listBox1.Items.Add("Key:" + item.Key + "Count: " + item.Count());
                foreach (var emp in item)
                    listBox1.Items.Add("----" + emp.Name);
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            
            var emps=lstEmployees.Take(3);
            foreach (var item in emps)
                listBox1.Items.Add("Empno: " + item.EmpNo + ", Name: " + item.Name + ", Basic: " + item.Basic + ", DeptNum : " + item.DeptNo + ",Gender: " + item.Gender);
           

        }

        private void button22_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            var emps = lstEmployees.TakeWhile(emp=>emp.Basic>10000);


            foreach (var item in emps)
                listBox1.Items.Add("Empno: " + item.EmpNo + ", Name: " + item.Name + ", Basic: " + item.Basic + ", DeptNum : " + item.DeptNo + ",Gender: " + item.Gender);
           
        }

        private void button23_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var emps = lstEmployees.Skip(3);
            foreach (var item in emps)
                listBox1.Items.Add("Empno: " + item.EmpNo + ", Name: " + item.Name + ", Basic: " + item.Basic + ", DeptNum : " + item.DeptNo + ",Gender: " + item.Gender);
           
        }

        private void button24_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            var emps = lstEmployees.SkipWhile(emp => emp.Basic >10000);
              foreach (var item in emps)
                listBox1.Items.Add("Empno: " + item.EmpNo + ", Name: " + item.Name + ", Basic: " + item.Basic + ", DeptNum : " + item.DeptNo + ",Gender: " + item.Gender);
          
        }

        private void button25_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var emps = lstEmployees.Take(5).Concat(lstEmployees.Take(2));
            foreach (var item in emps)
                listBox1.Items.Add("Empno: " + item.EmpNo + ", Name: " + item.Name + ", Basic: " + item.Basic + ", DeptNum : " + item.DeptNo + ",Gender: " + item.Gender);

        }

        private void button26_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var emps = lstEmployees.Concat(lstEmployees);

            foreach (var item in emps)
                listBox1.Items.Add("EmpNo : " + item.EmpNo.ToString() + ", Name:" + item.Name + ", Basic:" + item.Basic.ToString() + ", DeptNo :" + item.DeptNo.ToString() + ", Gender:" + item.Gender);

            MessageBox.Show("After distinct");
            listBox1.Items.Clear();
            var distinctEmps = emps.Distinct();
            foreach (var item in distinctEmps)
                listBox1.Items.Add("EmpNo : " + item.EmpNo.ToString() + ", Name:" + item.Name + ", Basic:" + item.Basic.ToString() + ", DeptNo :" + item.DeptNo.ToString() + ", Gender:" + item.Gender);

        }

        private void button27_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var lst2 = lstEmployees.Take(4);
            var emps = lstEmployees.Union(lst2);

            foreach (var item in emps)
                listBox1.Items.Add("EmpNo : " + item.EmpNo.ToString() + ", Name:" + item.Name + ", Basic:" + item.Basic.ToString() + ", DeptNo :" + item.DeptNo.ToString() + ", Gender:" + item.Gender);

        }

        private void button28_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var lst2 = lstEmployees.Take(4);
            var emps = lstEmployees.Intersect(lst2);

            foreach (var item in emps)
                listBox1.Items.Add("EmpNo : " + item.EmpNo.ToString() + ", Name:" + item.Name + ", Basic:" + item.Basic.ToString() + ", DeptNo :" + item.DeptNo.ToString() + ", Gender:" + item.Gender);

        }

        private void button29_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            var lst2 = lstEmployees.Take(2);
            var emps = lstEmployees.Except(lst2);

            foreach (var item in emps)
                listBox1.Items.Add("EmpNo : " + item.EmpNo.ToString() + ", Name:" + item.Name + ", Basic:" + item.Basic.ToString() + ", DeptNo :" + item.DeptNo.ToString() + ", Gender:" + item.Gender);

        }

        private void button30_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            ArrayList employees = new ArrayList(lstEmployees);
            //employees.Add(10); cannot cast object of type other than employee
            var lst2 = employees.Cast<Employee>();

            var emps = lst2.Select(emp => emp);
            foreach (var item in emps)
                listBox1.Items.Add("EmpNo : " + item.EmpNo.ToString() + ", Name:" + item.Name + ", Basic:" + item.Basic.ToString() + ", DeptNo :" + item.DeptNo.ToString() + ", Gender:" + item.Gender);

        }

        private void button31_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            ArrayList employees = new ArrayList(lstEmployees);
            employees.Add(10);
            var lst2 = employees.OfType<Employee>();
            //oftype accepts only object of employee type
            var emps = lstEmployees.Select(emp => emp);
            foreach (var item in emps)
                listBox1.Items.Add("EmpNo : " + item.EmpNo.ToString() + ", Name:" + item.Name + ", Basic:" + item.Basic.ToString() + ", DeptNo :" + item.DeptNo.ToString() + ", Gender:" + item.Gender);

        }

        private void button32_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Employee obj = lstEmployees.Where(emp => emp.Name == "Suraj").DefaultIfEmpty().First();
            if (obj != null)
                MessageBox.Show(obj.Name);
            else
                MessageBox.Show("not found");
            
        }

        private void button33_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Employee obj = lstEmployees.SingleOrDefault(emp => emp.Name == "Suraj");
            if (obj != null)
                MessageBox.Show(obj.Name);
            else
                MessageBox.Show("not found");
        }

        private void button34_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Employee obj = lstEmployees.ElementAtOrDefault(3);
            if (obj != null)
                MessageBox.Show(obj.Name);
            else
                MessageBox.Show("not found");
        }


    }

    class Result { public string  Name { get; set; }
    public int EmpNo { get; set; }
    }
}
