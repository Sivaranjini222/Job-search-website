using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcproject.Models
{
    public class userinsert
    {
        public int uid { set; get; }
        [Required(ErrorMessage = "Enter the name")]
        public string name { get; set; }

        [Required(ErrorMessage = "Enter the address")]
        public string address { get; set; }

        [Required(ErrorMessage = "Enter the email")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string email { get; set; }

        [Required(ErrorMessage = "Select gender")]
        public string gender { get; set; }

        [Required(ErrorMessage = "Select date of birth")]
        [DataType(DataType.Date)]
        public DateTime? dob { get; set; }

        [Required(ErrorMessage = "Enter phone number")]
        [Phone(ErrorMessage = "Enter a valid phone number")]
        public string phone { get; set; }

        public string image { get; set; }

        [Required(ErrorMessage = "Enter skills")]
        public string skills { get; set; }

        [Required(ErrorMessage = "Enter experience")]
        [Range(0, 50, ErrorMessage = "Experience must be between 0 and 50 years")]
        public string experience { get; set; }

        [Required(ErrorMessage = "Enter education")]
        public string education { get; set; }

        public string status { get; set; }


        [Required(ErrorMessage = "Enter username")]
        public string username { get; set; }
        public string pass { set; get; }
        [Compare("pass", ErrorMessage = "password mismatch")]

        public string cpassword { set; get; }
        public string usermsg { set; get; }
    }
}