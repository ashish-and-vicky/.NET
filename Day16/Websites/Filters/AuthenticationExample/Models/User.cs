using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuthenticationExample.Models
{
    public class User
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string passWord { get; set; }

    }
}