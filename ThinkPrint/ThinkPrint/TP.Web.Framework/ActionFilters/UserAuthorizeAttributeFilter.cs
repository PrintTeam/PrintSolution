using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TP.EntityFramework.Models;
using TP.Web.Framework.Security;


namespace TP.Web.Framework.ActionFilters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class UserAuthorizeAttributeFilter : FilterAttribute,IExceptionFilter, IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            UserModel userModel;

            if (filterContext.Controller.ViewBag.UserModel == null)
            {
                userModel = new UserModel();
                filterContext.Controller.ViewBag.UserModel = userModel;
            }
            else
            {
                userModel = filterContext.Controller.ViewBag.UserModel as UserModel;
            }
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
                //filterContext.HttpContext.Response.Redirect("~/Account/LogOn");

            }
            else
            {
                AuthUser authUser = filterContext.HttpContext.User.GetAuthUser();
                userModel.IsUserAuthenticated = authUser.IsAuthenticated;
                userModel.UserName = authUser.Name;
                userModel.RoleList = authUser.RoleList;
                userModel.UserId = authUser.UserId;

            }
        }

       


        public void OnException(ExceptionContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
            filterContext.ExceptionHandled = true;
           
        }
    }

    public class UserModel
    {
        public int UserId { get; set; }
        public bool IsUserAuthenticated { get; set; }
        public string UserName { get; set; }

        public IList<AUT_UserRole> RoleList  { get; set; }
    }
}
