using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalAssign.Models
{
    public class User
    {
        [DisplayName("Login Name")]
        [Required(ErrorMessage = "Login Name is a required field")]
        public string LoginName { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password is a required field")]        
        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        [Required(ErrorMessage = "Confirm Password is a required field")]   
        [Compare("Password", ErrorMessage = "Password is not identical")]
        public string Confirm_Password { get; set; }

        [DisplayName("Full Name")]
        [Required(ErrorMessage = "Full Name is a required field")]
        public string FullName { get; set; }

        [DisplayName("Email ID")]
        [Required(ErrorMessage = "Email ID is a required field")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail id is not valid")]
        public string EmailID { get; set; }

        [DisplayName("City")]
        [Required(ErrorMessage = "City is a required field")]
        public string City { get; set; }

        [DisplayName("Phone")]
        public string Phone { get; set; }
    }
}