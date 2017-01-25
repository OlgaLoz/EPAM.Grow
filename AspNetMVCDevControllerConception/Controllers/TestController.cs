using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspNetMVCDevControllerConception.ViewModels;

namespace AspNetMVCDevControllerConception.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {


            return View("CreateTest");
        }

        [HttpPost]
        public ActionResult Create(TestViewModel model)
        {


            return View("CreateTest");
        }
    }
}