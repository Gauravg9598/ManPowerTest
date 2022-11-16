using CarDetails_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDetails_Test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserProfile objUser)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ManPowerTestEntities db = new ManPowerTestEntities())
                    {
                        var obj = db.tblLogins.Where(a => a.Email.Equals(objUser.Email) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                        if (obj != null)
                        {
                            Session["Email"] = obj.Email.ToString();
                            Session["Password"] = obj.Password.ToString();
                            return RedirectToAction("Index", "Car");
                        }
                    }
                }
                return View(objUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return View();
        }

        //[HttpPost]
        //public JsonResult Login(string email, string password)
        //{
        //    ManPowerTestEntities db = new ManPowerTestEntities();
        //    var data = from c in db.tblLogins where c.Email == email && c.Password == password select c;
        //    if (data.Count() > 0)
        //        return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
        //    else
        //        return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
        //}
    }
}