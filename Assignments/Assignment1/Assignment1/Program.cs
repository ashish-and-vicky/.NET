using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Employee
    {
        private string n;
        public string Name
        {
            set
            {
                if(value!=null)
                {
                    n = value;
                }
                else
                {
                    Console.WriteLine("No blank names are allowed");
                    return;
                }
            }
        }

        private int e;

        public int EmpNo
        {
            set
            {
                e = value;
            }
            get
            {
                return e;
            }
        }


        private decimal b;

        public decimal Basic
        {
            set
            {
                if(b > 100 && b < 200)
                {
                    b = value;
                }
                else
                {
                    Console.WriteLine("Enter Salary in the range of 101 - 199 inclusive ");
                    return;
                }
            }
            get
            {
                return b;
            }
        }


        private short d;

        public short DeptNo
        {         
            set
            {
                if(value > 0)
                {
                    d = value;
                }
                else
                {
                    Console.WriteLine("Dept No. must be greater than 0");
                }
            }
            get
            {
                return d;
            }
        }


        public static int count = 0;

        public Employee(string n, decimal b = 0, short d = 0 )
        {
            count++;
            Name = n;
            Basic = b;
            DeptNo = d;
            EmpNo = Employee.count;

        }

        public Employee()
        {
        }

        public decimal GetNetSalary(decimal Basic)
        {
            decimal da = 2;
            decimal hra = 5;

            decimal da1 = (da * Basic) / 100;
            decimal hra1 = (hra * Basic) / 100;

            decimal NetSalary = da1 + hra1 + Basic;

            return NetSalary;
        }



        static void Main(string[] args)
        {
            Employee emp1 = new Employee("Amol", 156, 10);
            Employee emp2 = new Employee("Amol", 65);
            Employee emp3 = new Employee("Amol");
            Employee emp4 = new Employee();

            Console.WriteLine("1=" + emp1.EmpNo);
            Console.WriteLine("2=" + emp2.EmpNo);
            Console.WriteLine("3=" + emp3.EmpNo);
            Console.WriteLine("4=" + emp4.EmpNo);
            Console.WriteLine("4=" + emp4.DeptNo);
            Console.WriteLine("4=" + emp4.Basic);


            Console.WriteLine(emp4.EmpNo);
            Console.WriteLine(emp3.EmpNo);
            Console.WriteLine(emp2.EmpNo);
            Console.WriteLine(emp1.EmpNo);
            Console.ReadLine();
        }
    }
}
