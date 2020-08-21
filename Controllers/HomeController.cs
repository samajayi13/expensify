using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Expensify.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        public ActionResult SetUserNameCookie(string username)
        {
            HttpCookie cookie = new HttpCookie("username", username);
            cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(cookie);
            return Json(username,JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            //SetUserNameCookie("samajayi13");


            ViewBag.cookiName = HttpContext.Request.Cookies["username"].Value;
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

  
        public ActionResult LoginForm()
        {
            return View();
        }
        public ActionResult Homepage()
        {
            ViewBag.username = HttpContext.Request.Cookies["username"].Value;
            return View();
        }
    }
}