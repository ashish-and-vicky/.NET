using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObjects
{

    
    class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public int DeptNo { get; set; }
        public decimal  Basic { get; set; }
        public string  Gender { get; set; }
    }
    class Department
    {
        public int DeptNo { get; set; }
        
        public string DeptName { get; set; }
        
        
    }
}
