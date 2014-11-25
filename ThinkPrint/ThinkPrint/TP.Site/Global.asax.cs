using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using TP.Core.Infrastructure;
using TP.EntityFramework;
using TP.Repository;
using TP.Service;
using TP.Service.Authentication;
using TP.Web.Framework.Security;

namespace TP.Site
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            EngineContext.Initialize();
            ContainerBuilder builder = EngineContext.Current.ContainerBuilder;
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModule<EntityFrameworkModel>();
            builder.RegisterModule<RepositoryModel>();
            builder.RegisterModule<ServiceModel>();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }


        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

            PostAuthenticateRequestHandler(sender, e);
        }

        private void PostAuthenticateRequestHandler(object sender, EventArgs e)
        {
            HttpCookie authCookie = this.Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (IsValidAuthCookie(authCookie))
            {
                ILifetimeScope scope = AutofacDependencyResolver.Current.RequestLifetimeScope;
                IAuthenticationService authenticationService = scope.Resolve<IAuthenticationService>();

                try
                {
                    var authUser = new AuthUser(Context.User.Identity.Name, authenticationService.GetAuthenticatedUserInfo());
                    var id = HttpContext.Current.User.Identity as FormsIdentity;
                    id.Ticket.UserData.Split(',');
                    this.Context.User = new GenericPrincipal(authUser, null);
                }
                catch (Exception)
                {

                    authenticationService.SignOut();
                }

            }
        }

        private static bool IsValidAuthCookie(HttpCookie authCookie)
        {
            return authCookie != null && !String.IsNullOrEmpty(authCookie.Value);
        }
    }
}
