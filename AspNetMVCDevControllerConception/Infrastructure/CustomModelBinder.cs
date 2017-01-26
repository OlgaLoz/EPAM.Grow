using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspNetMVCDevControllerConception.ViewModels;
using WebGrease.Css.Extensions;

namespace AspNetMVCDevControllerConception.Infrastructure
{
    public class CustomModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {

            TestViewModel testModel = bindingContext.Model as TestViewModel ?? new TestViewModel();
            HttpRequestBase request = controllerContext.HttpContext.Request;

            testModel.Name = request.Form.Get("name") ?? request.Form.Get("Name");
            testModel.Questions = request.Form.Get("question").Split(',').Select(x => new QuestionViewModel
            {
                Text = x,
                Answers = new List<AnswerViewModel>(),
            }).ToList();

            for (int i = 0; i < testModel.Questions.Count; i++)
            {
                testModel.Questions[i].RightAnswerId = int.Parse(request.Form.Get("question" + i));
                testModel.Questions[i].Answers.AddRange(request.Form.Get("answerquestion" + i)
                    .Split(',').Select( answer => new AnswerViewModel {Text = answer}).ToList());
            }
            
            return testModel;
        }
    }
}