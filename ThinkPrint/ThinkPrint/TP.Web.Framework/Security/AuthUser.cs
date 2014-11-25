using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using TP.EntityFramework.Models;


namespace TP.Web.Framework.Security
{
    public class AuthUser : IIdentity
    {
        public AuthUser(int userId,string name)
        {
            this.UserId = userId;
            this.Name = name;
        }
        public AuthUser(int userId, string name, IList<AUT_UserRole> roleList)
        {
            this.UserId = userId;
            this.Name = name;
            this.RoleList= roleList;
        }

        public AuthUser(string name, AUT_User loginUser)
            : this(loginUser.UserId, name, (IList<AUT_UserRole>)loginUser.AUT_UserRole)
        {
        
        }

        public string AuthenticationType
        {
            get { return "ORANGEUSER"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }

        public string Name { get; private set; }

        public int UserId { get; private set; }

        public IList<AUT_UserRole> RoleList { get; private set; }
    }
}
