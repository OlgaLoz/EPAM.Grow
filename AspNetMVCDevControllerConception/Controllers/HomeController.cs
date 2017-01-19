using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Helpers;
using System.Web.Mvc;
using AspNetMVCDevControllerConception.Filters;
using AspNetMVCDevControllerConception.ORM;

namespace AspNetMVCDevControllerConception.Controllers
{
    public class HomeController : Controller
    {
        private readonly EntityModel _entityModel = new EntityModel();
        public ActionResult Index()
        {
            ViewBag.Name = Request.Cookies["userName"]?.Value ?? "Anonumous";
            List<Test> tests;
            if (HttpContext.Cache["Tests"] == null)
            {
                tests = _entityModel.Tests.ToList();
                HttpContext.Cache.Add("Tests", tests, null, DateTime.Now.AddDays(1), TimeSpan.Zero,
                    CacheItemPriority.Default, null);

            }
            else
            {
                tests = (List<Test>) HttpContext.Cache["Tests"];
            }

            return View(tests);
        }

        [CustomActionFilter]
        [HttpGet]
        public ActionResult Details(int id)
        {
            var test = _entityModel.Tests.FirstOrDefault(t => t.Id == id) ?? new Test();
            return View(test);
        }

        [HttpPost]
        public ActionResult TestResults()
        {
            int testId;
            if (!int.TryParse(HttpContext.Request.Form["testId"], out testId))
                return RedirectToAction("Index");

            var test = _entityModel.Tests.FirstOrDefault(t => t.Id == testId);
            if (test == null)
                return RedirectToAction("Index");

            var xValues = new List<string>();
            var yValues = new List<int>();
            var rightAnswers = test.Questions.Count(x => x.RightAnswerId == int.Parse(HttpContext.Request.Form[x.Id.ToString()]));
            if (rightAnswers > 0)
            {
                xValues.Add("Correct");
                yValues.Add(rightAnswers);

            }
            var incorrectAnwers = test.Questions.Count - rightAnswers;
            if (incorrectAnwers > 0)
            {
                xValues.Add("Incorrect");
                yValues.Add(incorrectAnwers);
            }
            TempData["Chart"] = new Chart(width: 600, height: 400)
                .AddTitle("Test results")
                .AddSeries(
                    chartType: "Pie",
                    xValue: xValues,
                    yValues: yValues).GetBytes();

            return View("TestResults");
        }


        public ActionResult GenerateChart()
        {
            var myChart = TempData["Chart"] as byte[];

            return File(myChart, "image/png");
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userName)
        {
            Response.Cookies.Add(new HttpCookie("userName", userName));

            return RedirectToAction("Index");
        }
    }
}