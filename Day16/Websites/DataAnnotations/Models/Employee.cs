using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Web;
//Annotations are the attributes that are given to the data
namespace DataAnnotations.Models
{
    public class Employee
    {
        [Key] //used for denoting a primary key
        public int EmpNo { get; set; }

        [DataType(DataType.Text)] //this ensure data entered will be text
        [Required(ErrorMessage = "Please enter name")] //Required will make it compulsary to enter the values
        [StringLength(10, ErrorMessage = "The {0} value cannot exceed {1} characters. ")] //{0} here is for the 'Name' below and {1} is for the value 10 in this which is the no. of characters
        public string Name { get; set; }

        [Range(1000, 500000, ErrorMessage = "Please enter values between 1000-500000")] //here 1000 is min value and 500000 is for max value
        [MaxLength(6), MinLength(4)] //it is for the max, min values for the char
        [Display(Name = "Basic Salary")]
        [DataType(DataType.Currency)] //this will ensure that the data entered will be of type decimal like how currency is
        public decimal Basic { get; set; }
        public short DeptNo { get; set; }
        
        [ScaffoldColumn(false)] //if we don't want Scaffolding for the below Dummy column
        public string Dummy { get; set; }

        [EmailAddress]
        public string EmailId { get; set; }
    }
}





//Data Annotations
//https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=netframework-4.7

//DataType
//https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.datatype?view=netframework-4.7