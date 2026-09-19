using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcproject.Models;

namespace mvcproject.Controllers
{
    public class jobpostController : Controller
    {
        mvcprojectEntities dbobj = new mvcprojectEntities();

        // GET
        public ActionResult JobPost_PageLoad()
        {
            return View();
        }

        [HttpPost]
        public ActionResult jobPost_Click(companyhome clsobj)
        {
            
            {
                if (ModelState.IsValid)
                {
                    int compid = Convert.ToInt32(Session["uid"]);

                    dbobj.sp_jobpost(
                        //clsobj.jobid,
                        compid,
                        clsobj.jobtitle,
                        clsobj.jobdescription,
                        clsobj.jobtype,
                        clsobj.jobexperience,
                        clsobj.jobskills,
                        clsobj.jobsalary,
                        clsobj.enddate,
                        clsobj.joblocation,
                        clsobj.jobstatus
                    );

                    clsobj.jobmsg= "Job posted successfully.";
                    ModelState.Clear();
                    return View("JobPost_PageLoad", clsobj);
                }

                return View("JobPost_PageLoad", clsobj);
            }

        }
    }
}