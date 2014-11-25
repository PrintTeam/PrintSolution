using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;

namespace TP.Service.Authentication
{
    public interface IAuthenticationService
    {
        void SignIn(AUT_User user);
        void SignOut();
        AUT_User GetAuthenticatedUserInfo();
    }
}
