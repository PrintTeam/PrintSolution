using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using TP.EntityFramework.Models;
using TP.Service.User;


namespace TP.Service.Authentication
{
    public class FormsAuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly HttpContext _httpContext;
        private readonly TimeSpan _expirationTimeSpan;
        private AUT_User _cachedUser;

        public FormsAuthenticationService(IUserService userService)
        {
            _userService = userService;
            _httpContext =HttpContext.Current ;
            _expirationTimeSpan = FormsAuthentication.Timeout;
        }

        public void SignIn(AUT_User user)
        {
            DateTime nowTime = DateTime.UtcNow.ToLocalTime();

            var ticket = new FormsAuthenticationTicket(1, user.Name, nowTime, nowTime.Add(_expirationTimeSpan), false, user.Name, FormsAuthentication.FormsCookiePath);
            FormsAuthentication.SetAuthCookie(user.Name, true, FormsAuthentication.FormsCookiePath);
            var encryptedTicket = FormsAuthentication.Encrypt(ticket);
           
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            
            cookie.HttpOnly = true;
            if (ticket.IsPersistent)
            {
                cookie.Expires = ticket.Expiration;
            }
            cookie.Secure = FormsAuthentication.RequireSSL;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            if (FormsAuthentication.CookieDomain != null)
            {
                cookie.Domain = FormsAuthentication.CookieDomain;
            }

            _httpContext.Response.Cookies.Add(cookie);
            _cachedUser = user;
        }

        public void SignOut()
        {
            _cachedUser = null;
            FormsAuthentication.SignOut();
        }

        public AUT_User GetAuthenticatedUserInfo()
        {
            if (_cachedUser != null)
                return _cachedUser;

            if (_httpContext == null ||
                _httpContext.Request == null ||
                !_httpContext.Request.IsAuthenticated ||
                !(_httpContext.User.Identity is FormsIdentity))
            {
                return null;
            }

            var formsIdentity = (FormsIdentity)_httpContext.User.Identity;
            try
            {
                var user = GetAuthenticatedCustomerFromTicket(formsIdentity.Ticket);
                if (user != null)
                    _cachedUser = user;
                return _cachedUser;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public AUT_User GetAuthenticatedCustomerFromTicket(FormsAuthenticationTicket ticket)
        {
            if (ticket == null)
                throw new ArgumentNullException("ticket");

            try
            {
                var usernameOrEmail = ticket.UserData;

                if (String.IsNullOrWhiteSpace(usernameOrEmail))
                    return null;

                var user = _userService.GetUserByUserName(usernameOrEmail);
                return user;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

        }
    }
}
