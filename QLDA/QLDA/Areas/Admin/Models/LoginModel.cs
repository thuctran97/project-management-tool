using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLDA.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required]
        public string Account { get; set;  }

        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}