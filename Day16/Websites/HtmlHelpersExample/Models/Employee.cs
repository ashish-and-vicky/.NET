using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HtmlHelpersExample.Models
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public short DeptNo { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; } //we have taken this because we want to display the Departments in a drop down (Employee has a Department as foreign key)---SelectListItem has a property with text and value
                                                                     //this is called a view model class which has a collection of Employees and Departments and then pass boththe objects to view
    }

}