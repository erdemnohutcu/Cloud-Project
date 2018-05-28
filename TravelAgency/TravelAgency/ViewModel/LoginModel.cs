using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelAgency.ViewModel
{
    public class LoginModel
    {
        [Key]
        public int userid { get; set; }

        [Display(Name = "UserName:")]
        [Required(ErrorMessage = "You must enter your user name")]
        [StringLength(50, ErrorMessage = "Your limit is 50 character")]
        public string username { get; set; }

        [Display(Name = "Password:")]
        [Required(ErrorMessage = "You must enter your user password")]
        [StringLength(50, ErrorMessage = "Your limit is 50 character")]
        [DataType(DataType.Password)]
        public string userpassword { get; set; }
    }
}