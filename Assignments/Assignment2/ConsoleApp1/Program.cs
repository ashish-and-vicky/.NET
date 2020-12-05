using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAssignment
{
    public interface IDbFunctions
    {
        void insert();
        void update();

        void delete();
    }
    class Program
    {
        static void Main(string[] args)
        {
            Manager m1 = new Manager("Ashish", 24000, 10, "Developer");

            Console.WriteLine("Manager Empno : " + m1.EmpNo);
            Console.WriteLine("Manager Employee Name : " + m1.Name);
            Console.WriteLine("Manager Employee Department No. : " + m1.DeptNo);
            Console.WriteLine("Manager Employee Desgination : " + m1.Designation);
            Console.WriteLine("Manager Net Salary : " + m1.CalcNetSalary(24000));

            Console.WriteLine("-------------------------------------------");

            GeneralManager gm1 = new GeneralManager("Saurav", 55000, 20, "Developer", "GM");
            IDbFunctions oIdb = gm1;
            Console.WriteLine("GManager Empno : " + gm1.EmpNo);
            Console.WriteLine("GManager Employee Name : " + gm1.Name);
            Console.WriteLine("GManager Employee Department No. : " + gm1.DeptNo);
            Console.WriteLine("GManager Employee Perks : " + gm1.Perks);
            Console.WriteLine("GManager Employee Desgination : " + gm1.Designation);
            Console.WriteLine("GManager Net Salary : " + gm1.CalcNetSalary(65000));

            Console.WriteLine("-------------------------------------------");

            CEO c1 = new CEO("Rohit", 70000, 20);

            Console.WriteLine("CEO Empno : " + c1.EmpNo);
            Console.WriteLine("CEO Employee Name : " + c1.Name);
            Console.WriteLine("CEO Employee Department No. : " + c1.DeptNo);
            Console.WriteLine("CEO Employee Desgination : CEO");
            Console.WriteLine("CEO Net Salary : " + c1.CalcNetSalary(35000));

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Interfaces");
            Console.WriteLine();
            m1.insert();
            m1.update();
            m1.delete();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Interfaces");
            Console.WriteLine();
            c1.insert();
            c1.update();
            c1.delete();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Interfaces");
            Console.WriteLine();
            oIdb.insert();
            oIdb.update();
            oIdb.delete();


            Console.ReadLine();
        }
    }

    public abstract class Employee
    {
        private string name;
        private static int empNo = 101;
        private short deptNo;

        private int id;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != "")
                    name = value;
                else
                    Console.WriteLine("Employee Name should not be blanked.");
            }
        }

        public int EmpNo
        {
            get
            {
                return empNo;
            }
        }

        public short DeptNo
        {
            get
            {
                return deptNo;
            }
            set
            {
                if (value > 0)
                    deptNo = value;
                else
                    Console.WriteLine("Employee department number must be greater than 0");
            }
        }

        public abstract decimal Basic
        {

            get;

            set;

        }

        public Employee(string name, short deptNo)
        {
            this.name = name;
            this.deptNo = deptNo;
            id = ++empNo;
        }

        public abstract decimal CalcNetSalary(decimal d);
    }

    public class Manager : Employee, IDbFunctions
    {
        private decimal basic;

        public decimal netsalary;
        private string designation;

        public string Designation
        {
            get
            {
                return designation;
            }
            set
            {
                if (value != "")
                    designation = value;
                else
                    Console.WriteLine("Designation must not be blanked");
            }
        }
        public Manager(string name, decimal bas, short deptNo, string designation) : base(name, deptNo)
        {
            Basic = bas;
            Designation = designation;
        }


        public override decimal Basic
        {
            get
            {
                return basic;
            }

            set
            {
                basic = value;
            }
        }

        public override decimal CalcNetSalary(decimal d)
        {
            decimal da = 5;
            decimal hra = 10;

            decimal da1 = (da * d) / 100;
            decimal hra1 = (hra * d) / 100;

            decimal netsalary = da1 + hra1 + d;

            return netsalary;
        }

        public void insert()
        {
            Console.WriteLine("interface insert() from Manager");
        }

        public void update()
        {
            Console.WriteLine("interface update() from Manager");
        }

        public void delete()
        {
            Console.WriteLine("interface delete() from Manager");
        }
    }

    public class GeneralManager : Manager, IDbFunctions
    {
        private string perks;
        private decimal basic;
        public GeneralManager(string name, decimal bas, short deptNo, string perk, string des) : base(name, bas, deptNo, des)
        {
            Designation = des;
            Basic = bas;
            Perks = perk;
        }
        public override decimal Basic
        {
            get
            {
                return basic;
            }
            set
            {
                if (value > 90000 || value < 350000)
                    basic = value;
                else
                    Console.WriteLine("Basic Salary should be between 90000 to 350000");
            }
        }

        public string Perks
        {
            get
            {
                return perks;
            }
            set
            {
                perks = value;
            }
        }
        public override decimal CalcNetSalary(decimal d)
        {
            decimal da, hra, net;
            da = (7 * d) / 100;
            hra = (10 * d) / 100;
            net = da + hra + d;
            return net;

        }

        public new void insert()
        {
            Console.WriteLine("interface insert() from GM");
        }
        public new void update()
        {
            Console.WriteLine("interface update() from GM");
        }
        public new void delete()
        {
            Console.WriteLine("interface delete() from GM");
        }
    }
    public class CEO : Employee, IDbFunctions
    {
        private decimal basic;
        public CEO(string name, decimal bas, short deptNo) : base(name, deptNo)
        {
            Basic = bas;

        }
        public override decimal Basic
        {
            get
            {
                return basic;
            }
            set
            {
                if (value > 600000 || value < 120000)
                    basic = value;
                else
                    Console.WriteLine("Basic Salary should be between 600000 to 120000");
            }
        }
        public sealed override decimal CalcNetSalary(decimal d)
        {
            decimal da, hra, net;
            da = (9 * d) / 100;
            hra = (10 * d) / 100;
            net = da + hra + d;
            return net;

        }

        public void delete()
        {
            Console.WriteLine("interface delete() from CEO");
        }

        public void insert()
        {
            Console.WriteLine("interface insert() from CEO");
        }

        public void update()
        {
            Console.WriteLine("interface update() from CEO");
        }
    }

}

