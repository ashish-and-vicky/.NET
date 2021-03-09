using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//linqsamples.com
//LINQ - Language INtegrated Query-----it is a common syntax for multiple languages(LYNQ Syntax for Collections, SQL Database)----we don't need to learn any different syntax for any different Collection, Database, Dataset etc.
namespace LinqExample
{
   //LINQ Queries for SQL:-
    class Program
    {
        static List<Employee> lstEmp = new List<Employee>();
        static List<Department> lstDept = new List<Department>();
        static void Main1()
        {
            AddRecs();
            //from SINGLE_OBJECT in COLLECTION select SOMETHING-----this is a general syntax for the below line of code of what it is
            var emps = from emp in lstEmp select emp; //here 'emp' will select elements from Employee class one by one. The objects just like a for each loop in it-----this query is called a LINQ Query and is default------here emp is an object. Therefore IEnumerable<Employee> is returning an object
            //for above code 'lstEmp' is List of Employee, left 'emp' is the Employee class and right 'emp' is the class object from Employee with datatype  
            //IEnumerable<Employee> emps = from emp in lstEmp select emp;----as IEnumerable is supreme collection type
            //List<Employee> emps =(List<Employee>) from emp in lstEmp select emp;

            foreach (Employee emp  in emps)
            {
                Console.WriteLine( emp.Name );
            }

            Console.ReadLine();

        }
        static void Main2()
        {
            AddRecs();
            //from SINGLE_OBJECT in COLLECTION select SOMETHING
            var emps = from emp in lstEmp select emp.Name; //here emp.Name is a string. Therefore IEnumerable<Employee> is returning a string. Therefore in line no 40, emp has become a string
            //var emps = from emp in lstEmp select emp.Basic;----now here as Basic is decimal. Therefore var emps will become IEnumerable of decimal
            //IEnumerable<Employee> emps = from emp in lstEmp select emp;
            //List<Employee> emps =(List<Employee>) from emp in lstEmp select emp;

            foreach (var emp in emps) //var emp is used because var changes its type based of the type of query(int ,string etc) is passed in it-----here emp will become string now----Therefore emp is now Name here
            {
                Console.WriteLine(emp);
            }

            Console.ReadLine();

        }
        static void Main3()
        {
            AddRecs();
            //from SINGLE_OBJECT in COLLECTION select SOMETHING
            
            var emps = from emp in lstEmp select new { emp.Name, emp.Basic }; //now as there are 2 datatypes here it has to be made anonymous by using 'new'

            //var emps = from emp in lstEmp select emp.Basic;
            //IEnumerable<Employee> emps = from emp in lstEmp select emp;
            //List<Employee> emps =(List<Employee>) from emp in lstEmp select emp;

            foreach (var emp in emps) //therefore emp is now anonymous
            {
                Console.WriteLine(emp.Name);
            }

            Console.ReadLine();

        }

        static void Main4()
        {
            AddRecs();


            var emps = from emp in lstEmp
                       where emp.Basic > 10000 //LINQ querie with conditions 
                       select emp;
            //var emps = from emp in lstEmp
            //           where emp.Basic > 10000 && emp.Basic < 12000
            //           select emp;
            //var emps = from emp in lstEmp
            //           where emp.Name.StartsWith("V")
            //           select emp;

            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name);
            }

            Console.ReadLine();

        }
        static void Main5()
        {
            AddRecs();


            //var emps = from emp in lstEmp
            //           orderby emp.Name ascending
            //           select emp;

            var emps = from emp in lstEmp
                       orderby emp.DeptNo, emp.Name descending
                       select emp;


            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name);
            }

            Console.ReadLine();

        }
      
        static void Main6()
        {
            AddRecs();

            var emps = from emp in lstEmp
                       join dept in lstDept
                             on emp.DeptNo equals dept.DeptNo
                       select new { dept.DeptName, emp.Name };

            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name);
            }

            Console.ReadLine();

        }

       static Employee GetEmployees(Employee obj)
        {
            return obj;
        }

        static void Main7()
        {
            AddRecs();

            // var emps = from emp in lstEmp select emp;

            //passing function as a parameter to Select
            //var emps = lstEmp.Select(GetEmployees);-----we can also use objects of Employee by using inbuilt functions

            //passing anon method as a parameter to Select
            //var emps = lstEmp.Select(delegate(Employee obj)-----also by using anonymous methods
            //{
            //    return obj;
            //});

            //using a lambda instead of anon method
            var emps = lstEmp.Select(emp=>emp); //also by using lambda functions

            //longer way
            //Func<Employee, Employee> o = e => e;-----also by using Func<>
            //var emps = lstEmp.Select(o);

            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name);
            }

            Console.ReadLine();
        }
        static void Main8()
        {
            AddRecs();


            //using a lambda instead of anon method
            //var emps = lstEmp.Select(emp => emp);
            var emps1 = lstEmp.Where(emp => emp.Basic > 11000); //also include conditions
            var emps2 = lstEmp.Where(emp => emp.Basic > 11000).Select(emp => emp); //also conditions with inbuilt solution----.Select() should be provided only when we require multiple columns or single object also can be ok
            var emps3 = lstEmp.Where(emp => emp.Basic > 11000).Select(emp => emp.Name);
            var emps = lstEmp.Where(emp => emp.Basic > 11000).Select(emp => new { emp.Name, emp.Basic });


            var emps4a = lstEmp.Select(emp => emp).Where(emp => emp.Basic > 11000); //we can also write .Select() first. o/p will be same
            var emps4b = lstEmp.Where(emp => emp.Basic > 11000).Select(emp => emp);

             var emps5a = lstEmp.Where(emp => emp.Basic > 11000).Select(emp => emp.Name);
             //var emps5b = lstEmp.Select(emp => emp.Name).Where(emp => emp.Basic > 11000);----this will not run since we can only call only object properties after selecting an object but can't pass another Property in one property(Name and Basic are two seperate properties of Employee)

            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name + "," + emp.Basic);
            }

            Console.ReadLine();
        }

        static void Main9()
        {
            AddRecs();


            //using a lambda instead of anon method
            var emps = lstEmp.OrderBy(emp => emp.Name);
            var emps2 = lstEmp.OrderByDescending(emp => emp.Name);


            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name + "," + emp.Basic);
            }

            Console.ReadLine();
        }
        static void Main10()
        {
            AddRecs();

            //var emps = from emp in lstEmp
            //           join dept in lstDept
            //                 on emp.DeptNo equals dept.DeptNo
            //           select new { dept.DeptName, emp.Name };    

            var emps2a = lstEmp.Join(lstDept, emp => emp.DeptNo, dept => dept.DeptNo, (emp, dept) => emp);
            var emps2b = lstEmp.Join(lstDept, emp => emp.DeptNo, dept => dept.DeptNo, (emp, dept) => dept);
            var emps2c = lstEmp.Join(lstDept, emp => emp.DeptNo, dept => dept.DeptNo, (emp, dept) => emp.Basic);
            var emps2d = lstEmp.Join(lstDept, emp => emp.DeptNo, dept => dept.DeptNo, (emp, dept) => dept.DeptName);
            var emps = lstEmp.Join(lstDept, emp => emp.DeptNo, dept => dept.DeptNo, (emp, dept) => new { dept.DeptName, emp.Name });


            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name + "," + emp.DeptName);
            }

            Console.ReadLine();
        }

        //Explore linqsamples.com for more about these queries 

        static void Main11()
        {
            AddRecs();
            //What is Deferred Execution?
            //deferred execution----means execution of this query does not takes place when you define this query, but when you access it for eg. in the for loop
            var emps = from emp in lstEmp select emp;
            Console.WriteLine();
            lstEmp.RemoveAt(0);

            foreach (var emp in emps) //as we have called 'emps', therefore execution will take place it this
            {
                Console.WriteLine(emp.Name + "," + emp.EmpNo);
            }
            Console.WriteLine();
            lstEmp.Add(new Employee { EmpNo = 9, Name = "New", Basic = 11000, DeptNo = 40, Gender = "F" });
            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name + "," + emp.EmpNo);
            }
            Console.ReadLine();
        }
        static void Main()
        {
            AddRecs();
            var emps = from emp in lstEmp select emp;

            //What is Immediate Execution?
            //immediate execution
            emps = emps.ToList(); //in this the above query has ran, and it won't be affected by the inbuilt functions like line no. 267 here

            Console.WriteLine();
            lstEmp.RemoveAt(0);
            foreach (var emp in emps) //here emps will run unaffected
            {
                Console.WriteLine(emp.Name + "," + emp.EmpNo);
            }
            Console.WriteLine();
            lstEmp.Add(new Employee { EmpNo = 9, Name = "New", Basic = 11000, DeptNo = 40, Gender = "F" });
            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Name + "," + emp.EmpNo);
            }
            Console.ReadLine();
        }
        public static void AddRecs()
        {
            lstDept.Add(new Department { DeptNo = 10, DeptName = "SALES" });
            lstDept.Add(new Department { DeptNo = 20, DeptName = "MKTG" });
            lstDept.Add(new Department { DeptNo = 30, DeptName = "IT" });
            lstDept.Add(new Department { DeptNo = 40, DeptName = "HR" });

            lstEmp.Add(new Employee { EmpNo = 1, Name = "Vikram", Basic = 10000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 2, Name = "Vikas", Basic = 11000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 3, Name = "Abhijit", Basic = 12000, DeptNo = 20, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 4, Name = "Mona", Basic = 11000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 5, Name = "Shweta", Basic = 12000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 6, Name = "Sanjay", Basic = 11000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 7, Name = "Arpan", Basic = 10000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 8, Name = "Shraddha", Basic = 11000, DeptNo = 40, Gender = "F" });
        }
    }

    public class Department
    {
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
    }
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
        public string Gender { get; set; }
        //public override string ToString()
        //{
        //    string s = Name + "," + EmpNo.ToString() + "," + Basic.ToString() + "," + DeptNo.ToString();
        //    return s;
        //}
    }
}
