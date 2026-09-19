using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebGrease.Configuration;

namespace mvcproject.Models
{
    public class applicationcls
    {
        public applicationcls()
        {
            selectjobdetails = new List<jobpost>();
        }

        public int appid { get; set; }
        public int userid { get; set; }
        public int company_id { get; set; }
        public int job_id { get; set; }

       
        public string resume { get; set; }

        public DateTime appdate { get; set; }
        public string appstatus { get; set; }

        public List<jobpost> selectjobdetails { get; set; }
    }
}