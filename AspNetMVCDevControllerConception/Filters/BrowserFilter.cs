using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace AspNetMVCDevControllerConception.Filters
{
    public class BrowserFilter : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext.Current.Response.Write("Hello from OnActionExecuting of Browser filter!<br/>");

            this.OnActionExecuting(filterContext);
        }

        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
            var clientBrowser = HttpContext.Current.Request.Browser.Browser;
            if (clientBrowser == "InternetExplorer")
            {
                filterContext.Result = new ViewResult()
                {
                    ViewName = "~/Views/Shared/IEView.cshtml",
                    ViewData = new ViewDataDictionary
                    {
                        new KeyValuePair<string, object>("Version",  HttpContext.Current.Request.Browser.Version)
                    } 
                };
            }
            HttpContext.Current.Response.Write("Hello from OnActionExecuted of Browser filter!<br/>");
        }
    }
}