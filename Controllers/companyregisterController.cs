using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvcproject.Models;

namespace mvcproject.Controllers
{
    public class companyregisterController : Controller
    {
        mvcprojectEntities dbobj=new mvcprojectEntities();
        // GET: companyregister
        public ActionResult companyreg_pageload()
        {
            return View();
        }
        public ActionResult companyreg_click(companyreg clsobj)
        {
            if (ModelState.IsValid)

            {
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
                dbobj.sp_companyreg(regid, clsobj.companyname, clsobj.companyaddress, clsobj.phone, clsobj.email);
                dbobj.sp_loginsert(regid, clsobj.username, clsobj.password, "company");
                clsobj.companymsg = "successfully inserted";
                return View("companyreg_pageload", clsobj);
            }
            return View("companyreg_pageload", clsobj);
        }
    }
}