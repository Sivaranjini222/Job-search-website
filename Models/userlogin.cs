using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcproject.Models
{
    public class userlogin
    {
        [Required(ErrorMessage = "enter username")]
        public string uname { get; set; }
        [Required(ErrorMessage = "enter password")]
        public string pwd { get; set; }
        public string msg { get; set; }
    }
}