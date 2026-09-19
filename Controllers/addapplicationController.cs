using mvcproject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcproject.Controllers
{
    public class addapplicationController : Controller
    {
        mvcprojectEntities dbobj = new mvcprojectEntities();

        // GET: addapplication
        public ActionResult application_load(int jid)
        {
            Session["jid"] = jid;

            var job = dbobj.jobposts.FirstOrDefault(j => j.jobid == jid);
            if (job != null)
            {
                Session["cid"] = job.compid;
            }

            int userid = Convert.ToInt32(Session["uid"]);
            int jobids = Convert.ToInt32(Session["jid"]);

            var result = dbobj.sp_countuserappliedjobwithid(userid, jobids).FirstOrDefault();
            int countapply = result ?? 0;

            if (countapply == 1)
            {
                ViewBag.isapplied = countapply;
            }

            var model = new applicationcls();
            model.selectjobdetails = dbobj.jobposts.Where(j => j.jobid == jid).ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult application_click(HttpPostedFileBase file, applicationcls clsobj)
        {
            int userid = Convert.ToInt32(Session["uid"]);
            int jobid = Convert.ToInt32(Session["jid"]);
            int companyid = Convert.ToInt32(Session["cid"]);

            // resume is populated from the file upload below, not a form field —
            // remove it from validation so it doesn't block ModelState.
            ModelState.Remove("resume");

            // Server-side duplicate-application guard (don't rely on the UI alone)
            var already = dbobj.sp_countuserappliedjobwithid(userid, jobid).FirstOrDefault() ?? 0;
            if (already == 1)
            {
                ModelState.AddModelError("", "You have already applied to this job.");
            }

            // Require a resume file on submit
            if (file == null || file.ContentLength == 0)
            {
                ModelState.AddModelError("", "Please attach a resume file.");
            }

            if (!ModelState.IsValid)
            {
                // Re-populate job details, otherwise the view will render empty
                clsobj.selectjobdetails = dbobj.jobposts.Where(j => j.jobid == jobid).ToList();
                if (already == 1)
                {
                    ViewBag.isapplied = 1;
                }
                return View("application_load", clsobj);
            }

            // Save the uploaded resume
            string fname = Path.GetFileName(file.FileName);
            var folder = Server.MapPath("~/applicationresume");
            string savePath = Path.Combine(folder, fname);
            file.SaveAs(savePath);

            clsobj.resume = savePath;
            clsobj.appdate = DateTime.Today;
            clsobj.userid = userid;
            clsobj.job_id = jobid;
            clsobj.company_id = companyid;

            dbobj.sp_postapplication(
                clsobj.userid,
                clsobj.company_id,
                clsobj.job_id,
                clsobj.resume,
                clsobj.appdate,
                "pending"
            );

            return RedirectToAction("viewjobpost_pageload", "viewjobpost");
        }
    }
}