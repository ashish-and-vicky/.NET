using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//A view that uses a Model is called a strongly typed view---

//To add a model---right click on Modal---Add---New Item---Class---Give a name---Add--as the solution is build now add a controller
//right click Controller---Add---Controller---click MVC 5 Controller with read/write actions (a controller with methods written)---Add---Give name EmployeeController---Add---a controller with methods written will be created---

namespace ModelBindingAndDbCode.Models
{
    public class Employee
    {
        public int EmpNo { get; set; } 
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public short DeptNo { get; set; }
    }
}