using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop3.Areas.Admin.Models
{
    public class LoginModel
    {
        [Key]
        [Required(ErrorMessage ="Please enter correct username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter correct password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}