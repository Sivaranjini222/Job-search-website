using mvcproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace mvcproject.Controllers
{
    public class loginController : Controller
    {
        mvcprojectEntities dbobj=new mvcprojectEntities();
        // GET: login
        public ActionResult loginpageload()
        {
            return View();
        }
        public ActionResult companyhome()
        {
            return View();
        }
        public ActionResult userhome()
        {
            return View();
        }
        public ActionResult loginclick(userlogin objcls)
        {
            if (ModelState.IsValid)
            {
                var val = dbobj.sp_logincountid(objcls.uname, objcls.pwd).First();
                if (val == 1)
                {
                    var uid = dbobj.sp_loginid(objcls.uname, objcls.pwd).First();
                    Session["uid"] = uid;
                    var it = dbobj.sp_logintype(objcls.uname, objcls.pwd).First();
                    if (it == "user")
                    {
                        return RedirectToAction("viewjobpost_pageload","viewjobpost");

                    }
                    else if (it == "company")
                    {
                        return RedirectToAction("JobPost_PageLoad", "jobpost");
                        
                    }
                }
                else
                {
                    ModelState.Clear();
                    objcls.msg = "invalid username and password";
                    return View("loginpageload", objcls);
                }

            }
            //else
            //{
            //    ModelState.Clear();
            //    objcls.msg = "invalid login";
            //    return View("loginpageload", objcls);
            //}
            return View("loginpageload", objcls);
        }
    }
}