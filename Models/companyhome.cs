using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcproject.Models
{
    public class jobsearch
    {

        public jobsearch()
        {
            selectjob = new List<companyhome>();
            insertse = new companyhome();

        }
        public companyhome insertse { set; get; }
        public List<companyhome> selectjob { set; get; }
    }
    public class companyhome
    {
        public int jobid { get; set; }

        [Required(ErrorMessage = "Company Id is required")]
        public int compid { get; set; }

        [Required(ErrorMessage = "Job Title is required")]
        public string jobtitle { get; set; }

        [Required(ErrorMessage = "Job Description is required")]
        public string jobdescription { get; set; }

        [Required(ErrorMessage = "Job Type is required")]
        public string jobtype { get; set; }

        [Required(ErrorMessage = "Job Experience is required")]
        public string jobexperience { get; set; }

        [Required(ErrorMessage = "Job Skills are required")]
        public string jobskills { get; set; }

        [Required(ErrorMessage = "Job Salary is required")]
        public string jobsalary { get; set; }

        [Required(ErrorMessage = "Job End Date is required")]
        [DataType(DataType.Date)]
        public System.DateTime enddate { get; set; }   // ✅

        [Required(ErrorMessage = "Job Location is required")]
        public string joblocation { get; set; }

        [Required(ErrorMessage = "Job Status is required")]
        public string jobstatus { get; set; }
        public string jobmsg { get; set; }
    }

   
}
