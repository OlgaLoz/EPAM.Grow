using System.Web;
using System.Web.Mvc;

namespace AspNetMVCDevControllerConception.Filters
{
    public class CustomActionFilter : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext.Current.Response.Write("Hello from OnActionExecuting of CustomAction filter!<br/>");
            
            this.OnActionExecuting(filterContext);
        }

        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
            HttpContext.Current.Response.Write("Hello from OnActionExecuted of CustomAction filter!<br/>");

            this.OnActionExecuted(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            HttpContext.Current.Response.Write("Hello from OnResultExecuting of CustomAction filter!<br/>");
            base.OnResultExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            HttpContext.Current.Response.Write("Hello from OnResultExecuted of CustomAction filter!<br/>");
            base.OnResultExecuted(filterContext);
        }
    }
}