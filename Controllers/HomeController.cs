using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Expensify.Models;

namespace Expensify.Controllers
{
    public class HomeController : Controller
    {
        private string username;
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


            username = HttpContext.Request.Cookies["username"].Value;
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
            //ViewBag.username = HttpContext.Request.Cookies["username"].Value;
            ViewBag.username = "samajayi13";
            return View();
        }

         [Route("home/monthly-expenses")]

        public ActionResult MonthlyExpenses(int month  = 0)
        {
            month = month == 0 ? DateTime.Today.Month : month;
            ViewBag.MonthName = GetMonthName(month);
            ViewBag.Username = "samajayi13";
            MonthlyExpense monthlyExpenses = new MonthlyExpense();

            monthlyExpenses.GetCurrentData("samajayi13", month);
            return View(monthlyExpenses);
        }

        private string GetMonthName(int number)
        {
            string[] months = { "January", "Febuary", "March", "April", "May", "June", "July", "August", "Spetember", "October", "Novemember", "December" };

            return months[number];
        }
    }
}