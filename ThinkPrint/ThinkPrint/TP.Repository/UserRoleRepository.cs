using TP.EntityFramework;
using TP.EntityFramework.Models;
using TP.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP.Repository
{
    public class UserRoleRepository : BaseRepository<AUT_UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(IDataBaseFactory dataBaseFactory)
            : base(dataBaseFactory)
        {

        }
    }
}
