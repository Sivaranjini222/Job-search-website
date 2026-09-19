using mvcproject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcproject.Controllers
{
   
    public class userregController : Controller
    {
        mvcprojectEntities dbobj = new mvcprojectEntities();

        // GET: userreg
        public ActionResult userregpageload()
        {
            return View();
        }
        public ActionResult insertclick(userinsert clsobj, HttpPostedFileBase file)

        {
            if (ModelState.IsValid)
            {
                if (file.ContentLength > 0)
                {
                    string fname = Path.GetFileName(file.FileName);
                    var s = Server.MapPath("~/userimage");
                    string pa = Path.Combine(s, fname);
                    file.SaveAs(pa);
                    var fullpath = Path.Combine("~\\userimage", fname);
                    clsobj.image = fullpath;//set
                }
                var getmaxid = dbobj.sp_maxidlogin().FirstOrDefault();
                int mid = Convert.ToInt32(getmaxid);
                int regid = 0;
                if (mid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = mid + 1;
                }
                dbobj.sp_userreg(regid, clsobj.name,  clsobj.address, clsobj.email, clsobj.gender, clsobj.dob, clsobj.phone, clsobj.image, clsobj.skills, clsobj.experience, clsobj.education, clsobj.status);
                dbobj.sp_loginsert(regid, clsobj.username, clsobj.pass, "user");
                clsobj.usermsg = "successfully inserted";
                return View("userregpageload", clsobj);
            }

            return View("userregpageload", clsobj); ;

        }
    }
}