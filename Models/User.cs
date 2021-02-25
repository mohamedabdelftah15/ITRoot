using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITRoot_Task.Models
{
    public class User
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="Full Name is required!")]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "UserName is required!")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress(ErrorMessage = "Write valid Email, please!")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone is required!")]
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        public bool ConfirmedEmail { get; set; }
        public int? RoleID { get; set; }
        public string RoleName { get; set; }
        public  List<Role> Roles { get; set; }
        public  List<Invoice> Invoices { get; set; }
        public string CurrentUser { get; set; }
    }
}