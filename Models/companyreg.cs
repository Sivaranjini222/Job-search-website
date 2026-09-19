using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcproject.Models
{
    public class companyreg
    {
        //[Required(ErrorMessage = "enter the name")]
        public string companyname { set; get; }
        //[Required(ErrorMessage = "enter the address")]
        public string companyaddress { set; get; }
        //[Required(ErrorMessage = "enter the phone")]
        //[RegularExpression(@"^(\d{10})$",ErrorMessage ="enter valid number")]
        public string phone { set; get; }
        //[EmailAddress(ErrorMessage ="enter valid email id")]
        public string email { set; get; }
        public string username { set; get; }

        public string password { set; get; }
        //[Compare("pass",ErrorMessage ="password mismatch")]
        public string cpassword { set; get; }
        public string companymsg { set; get; }
    }
}