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
        private MonthlyExpense monthlyExpenses = new MonthlyExpense();
        private string[] months = { "January", "Febuary", "March", "April", "May", "June", "July", "August", "Spetember", "October", "Novemember", "December" };

        [HttpPost]
        public ActionResult SetUserNameCookie(string username)
        {
            HttpCookie cookie = new HttpCookie("username", username);
            cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(cookie);

            return Json(username,JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        public ActionResult UpdateData(Object[] actualAmount, Object[] budgetAmount, Object[] category)
        {
            monthlyExpenses.UpdateData(actualAmount, budgetAmount, category,8,"samajayi13");

            return Json(actualAmount,JsonRequestBehavior.AllowGet);
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

         [Route("home/monthly-expenses/{month}")]

        public ActionResult MonthlyExpenses(int month  = 0)
        {
            month = month == 0 ? DateTime.Today.Month : month;
            ViewBag.MonthName = GetMonthName(month);
            ViewBag.Username = "samajayi13";
            

            monthlyExpenses.GetCurrentData("samajayi13", month);
            return View(monthlyExpenses);
        }

        [HttpPost]
        public ActionResult TrendGraphJson()
        {
            TrendGraphModel trendGraphModel = new TrendGraphModel();
            trendGraphModel  = this.monthlyExpenses.GetDataForLineGraph("samajayi13");
            return Json(trendGraphModel, JsonRequestBehavior.AllowGet);

        } 
        public ActionResult TrendGraph()
        {
            return View();

        }

       
        private string GetMonthName(int number)
        {

            return months[number-1];
        }

        public ActionResult YearlyReport()
        {
            YearlyReportModel yearlyReportModel = new YearlyReportModel("samajayi13");
            ViewBag.months = this.months;
            return View(yearlyReportModel);
        }

        [HttpPost]
        public ActionResult Recommendations(int budgetFigure = 1500 ,int month = 8 )
        {
            monthlyExpenses.GetCurrentData("samajayi13", month);
            RecommendationModel recommendationModel = new RecommendationModel("samajayi13", budgetFigure, this.monthlyExpenses, month);

            return Json(recommendationModel, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ViewRecommendations()
        {

            return View();
        }
    }
}