using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop3.Models
{
    public class RegisterModel
    {
        [Key]
        public long ID { set; get; }
        [Display(Name="Login name")]
        [Required(ErrorMessage ="The login name cannot be blank.")]
        public string UserName { set; get; }
        [Display(Name = "Password")]
        [StringLength(20, MinimumLength =6, ErrorMessage ="The password is too short. It needs to be longer than 6 characters.")]
        [Required(ErrorMessage = "The Password cannot be blank.")]
        public string Password { set; get; }
        [Display(Name = "Confirmation password")]
        [Compare("Password",ErrorMessage ="The password doesn't match with the confirmation password.")]
        public string ConfirmPassword { set; get; }
        [Display(Name = "Full name")]
        [Required(ErrorMessage = "Please enter your full name.")]
        public string Name { set; get; }
        [Display(Name = "Address")]
        public string Address { set; get; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter your correct email.")]
        public string Email { set; get; }
        [Display(Name = "Phone")]
        public string Phone { set; get; }

        [Display(Name= "District")]
        public string DistrictID { get; set; }  // problem here: should be int, not string
        [Display(Name = "Province")]
        public string ProvinceID { get; set; }  // problem here: should be int, not string

        //public bool Status { set; get; }
    }
}