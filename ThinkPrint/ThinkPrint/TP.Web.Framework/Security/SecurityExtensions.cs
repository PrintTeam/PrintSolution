using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;

namespace TP.Web.Framework.Security
{
    public static class SecurityExtensions
    {
        public static AuthUser GetAuthUser(this IPrincipal principal)
        {
            if (principal.Identity is AuthUser)
                return (AuthUser)principal.Identity;
            else
                return new AuthUser(string.Empty, new AUT_User());
        }
    }
}
