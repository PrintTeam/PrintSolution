using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TP.Web.Framework.ActionFilters
{
    public class ErrorAttributeFilter : ActionFilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            Exception Error = filterContext.Exception;
            string Message = Error.Message;//错误信息
            string Url = HttpContext.Current.Request.RawUrl;//错误发生地址

            filterContext.ExceptionHandled = true;
            filterContext.Result = new RedirectResult("/Error/Show/");//跳转至错误提示页面
        }
    }
}