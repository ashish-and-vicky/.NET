using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
/*

the steps for creating this is same as previous---but here we will add two controllers(by controller creating process) one for Departments and for Employees because we need to add departements data in employees

The rest of the code generated here is just like the previous---the DB will also be created for us with Namespace and DBContect hierachy

*/
namespace EFCodeFirst.Models
{
    public class Employee
    {
        [Key]
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
        public virtual Department Department { get; set; }
    }

    public partial class Department
    {
        [Key]
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }

    public partial class JKMyDbContext : DbContext
    {
        //public JKMyDbContext() : base("name=cn")

        //    // database will be named as given in the connectionStrings section in web.config
        //{
        //}
        //public JKMyDbContext() : base("DatabaseName")-------whatever name we passed here then DB with the same name will be created
        //    // database will be called "DatabaseName"

        //{
        //}
        //public JKMyDbContext() : base()  
        //    //database will be called EFCodeFirst.Models.JKMyDbContext
        //    //with same name if no constructors given
        //{
        //}

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
    }
}