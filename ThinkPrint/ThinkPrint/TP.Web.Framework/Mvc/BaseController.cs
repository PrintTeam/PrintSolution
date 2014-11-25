using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.Web.Framework.Security;

namespace TP.Web.Framework.Mvc
{
    public class BaseController : Controller
    {

        public AuthUser CurrentUser
        {
            get
            {
                if (HttpContext.User.Identity == null)
                    Response.Redirect("Account/Login");
                return HttpContext.User.Identity as AuthUser;
            }
        }

        /// <summary>
        /// On exception
        /// </summary>
        /// <param name="filterContext">Filter context</param>
        protected override void OnException(ExceptionContext filterContext)
        {

            if (filterContext.Exception != null)


                LogException(filterContext.Exception);
            base.OnException(filterContext);
        }

        /// <summary>
        /// Log exception
        /// </summary>
        /// <param name="exc">Exception</param>
        protected void LogException(Exception exc)
        {
            ErrorModel model = new ErrorModel();
            model.Source = exc.Source;
            model.Message = exc.Message;
        }

        /// <summary>
        /// Display success notification
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="persistForTheNextRequest">A value indicating whether a message should be persisted for the next request</param>
        protected virtual void SuccessNotification(string message, bool persistForTheNextRequest = true)
        {
            AddNotification(NotifyType.Success, message, persistForTheNextRequest);
        }
        /// <summary>
        /// Display error notification
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="persistForTheNextRequest">A value indicating whether a message should be persisted for the next request</param>
        protected virtual void ErrorNotification(string message, bool persistForTheNextRequest = true)
        {
            AddNotification(NotifyType.Error, message, persistForTheNextRequest);
        }
        /// <summary>
        /// Display error notification
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <param name="persistForTheNextRequest">A value indicating whether a message should be persisted for the next request</param>
        /// <param name="logException">A value indicating whether exception should be logged</param>
        protected virtual void ErrorNotification(Exception exception, bool persistForTheNextRequest = true, bool logException = true)
        {
            if (logException)

                AddNotification(NotifyType.Error, exception.Message, persistForTheNextRequest);
        }

        /// <summary>
        /// Display notification
        /// </summary>
        /// <param name="type">Notification type</param>
        /// <param name="message">Message</param>
        /// <param name="persistForTheNextRequest">A value indicating whether a message should be persisted for the next request</param>
        protected virtual void AddNotification(NotifyType type, string message, bool persistForTheNextRequest)
        {
            string dataKey = string.Format("tp.notifications.{0}", type);
            if (persistForTheNextRequest)
            {
                if (TempData[dataKey] == null)
                    TempData[dataKey] = new List<string>();
                ((List<string>)TempData[dataKey]).Add(message);
            }
            else
            {
                if (ViewData[dataKey] == null)
                    ViewData[dataKey] = new List<string>();
                ((List<string>)ViewData[dataKey]).Add(message);
            }
        }

        protected virtual void ActiveMenu(string activeId)
        {
            string dataKey = "tp.activeMenu";

            if (System.Web.HttpContext.Current.Session[dataKey] == null)
            {
                System.Web.HttpContext.Current.Session.Add(dataKey, activeId);
            }
            else
            {

                System.Web.HttpContext.Current.Session[dataKey] = activeId;
            }

        }

        protected virtual void ActiveNavigation(string activeId)
        {
            string dataKey = "tp.activeMenu";

            if (ViewData[dataKey] == null)
            {
             
                ViewData.Add(dataKey, activeId);

            }
            else
            {
                ViewData[dataKey] = activeId;
            }


        }

    }
}