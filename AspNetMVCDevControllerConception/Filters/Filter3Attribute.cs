using System.Web;
using System.Web.Mvc;

namespace AspNetMVCDevControllerConception.Filters
{
    public class Filter3Attribute : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext.Current.Response.Write("Hello from OnActionExecuting of Filter3Attribute filter!<br/>");

            this.OnActionExecuting(filterContext);
        }

        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
            HttpContext.Current.Response.Write("Hello from OnActionExecuted of Filter3Attribute filter!<br/>");

            this.OnActionExecuted(filterContext);
        }
    }
}