using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.Core.WebHelper;
using TP.EntityFramework.Models;
using TP.Service.Authentication;
using TP.Service.User;
using TP.Site.Models.Account;
using TP.Web.Framework.ActionFilters;
using TP.Web.Framework.Security;

namespace TP.Site.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IWebHelper _webHelper;

        public AccountController(IUserService userService, IAuthenticationService authenticationService)
        {
            this._userService = userService;
            this._authenticationService = authenticationService;
            _webHelper = new WebHelper(this.HttpContext);
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                string pwd = Encryption.MD5(model.Password.Trim());
                AUT_User loginUser = _userService.ValidateUser(model.UserName.Trim(), pwd);
                if (loginUser != null)
                {
                    loginUser.ModifiedDate = DateTime.UtcNow.ToLocalTime();
                    loginUser.LastLoginDate = DateTime.UtcNow.ToLocalTime();
                    loginUser.LastLoginIP = _webHelper.GetCurrentIpAddress();
                    _userService.UpdateUser(loginUser);

                    _authenticationService.SignIn(loginUser);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }
                else
                {
                    ModelState.AddModelError("", "用户名或密码不正确！");
                }

            }


            return View(model);
        }

        [UserAuthorizeAttributeFilter]
        public ActionResult LogOff()
        {
            _authenticationService.SignOut();

            return RedirectToAction("Login", "Account");
        }


    }
}