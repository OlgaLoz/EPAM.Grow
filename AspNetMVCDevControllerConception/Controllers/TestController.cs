using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspNetMVCDevControllerConception.Infrastructure;
using AspNetMVCDevControllerConception.ORM;
using AspNetMVCDevControllerConception.ViewModels;
using AutoMapper;
using WebGrease.Css.Extensions;

namespace AspNetMVCDevControllerConception.Controllers
{
    public class TestController : Controller
    {
        private readonly EntityModel _entityModel = new EntityModel();

        public TestController() 
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<TestViewModel, Test>();
                cfg.CreateMap<QuestionViewModel, Question>();
                cfg.CreateMap<AnswerViewModel, Answer>();

            });
        }

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
        public ActionResult Create([ModelBinder(typeof(CustomModelBinder))]TestViewModel model)
        {
            var testModel = Mapper.Map<Test>(model);

            var testFromDb = _entityModel.Tests.Add(testModel);
            _entityModel.SaveChanges();

            testFromDb.Questions.ForEach(x => x.RightAnswerId = x.Answers.ElementAt(x.RightAnswerId).Id);
            _entityModel.Entry(testFromDb).State = EntityState.Modified;
            _entityModel.SaveChanges();

            return View("CreateTest");
        }
    }
}