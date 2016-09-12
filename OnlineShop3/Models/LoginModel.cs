using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop3.Models
{
    public class LoginModel
    {
        [Display(Name ="Login name")]
        [Required(ErrorMessage ="Please enter your login name.")]
        [Key]
        public string UserName { set; get; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter your password.")]
        public string Password { set; get; }
    }
}