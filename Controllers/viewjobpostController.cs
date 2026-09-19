using mvcproject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcproject.Controllers
{
    public class viewjobpostController : Controller
    {
        mvcprojectEntities dbobj = new mvcprojectEntities();

        // GET: viewjobpost
        public ActionResult viewjobpost_pageload()
        {
            var spResults = dbobj.sp_viewjobs().ToList();

            var model = new jobsearch();
            foreach (var row in spResults)
            {
                model.selectjob.Add(new companyhome
                {
                    jobid = row.jobid,
                    compid = row.compid,
                    jobtitle = row.jobtitle,
                    jobdescription = row.jobdesc,
                    jobtype = row.jobtype,
                    jobexperience = row.jobexperience,
                    jobskills = row.jobskills,
                    jobsalary = row.jobsalary,
                    enddate = row.enddate,
                    joblocation = row.joblocation,
                    jobstatus = row.jobstatus
                });
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult searchjob_click(jobsearch job)
        {
            string qry = "";
            if (!string.IsNullOrWhiteSpace(job.insertse.jobexperience))
            {
                qry += "and jobexperience like'%" + job.insertse.jobexperience + "%'";
            }
            if (!string.IsNullOrWhiteSpace(job.insertse.jobskills))
            {
                qry += "and jobskills like'%" + job.insertse.jobskills + "%'";
            }
            if (!string.IsNullOrWhiteSpace(job.insertse.joblocation))
            {
                qry += "and joblocation like'%" + job.insertse.joblocation + "%'";
            }
            return View("viewjobpost_pageload", getdata(job, qry));
        }

        private jobsearch getdata(jobsearch job, string qry)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["importdataconnection"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_jobsearch", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@qry", qry);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                var companyhome = new jobsearch();
                while (dr.Read())
                {
                    var jobcls = new companyhome();
                    jobcls.jobid = Convert.ToInt32(dr["jobid"].ToString());
                    jobcls.compid = Convert.ToInt32(dr["compid"].ToString());
                    jobcls.jobtitle = dr["jobtitle"].ToString();
                    jobcls.jobdescription = dr["jobdesc"].ToString();
                    jobcls.jobtype = dr["jobtype"].ToString();
                    jobcls.jobexperience = dr["jobexperience"].ToString();
                    jobcls.jobskills = dr["jobskills"].ToString();
                    jobcls.jobsalary = dr["jobsalary"].ToString();
                    jobcls.enddate = Convert.ToDateTime(dr["enddate"].ToString());
                    jobcls.joblocation = dr["joblocation"].ToString();
                    jobcls.jobstatus = dr["jobstatus"].ToString();
                    companyhome.selectjob.Add(jobcls);
                }
                con.Close();
                return companyhome;
            }
        }
    }
}