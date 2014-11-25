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
    public class UserRepository : BaseRepository<AUT_User>, IUserRepository
    {
        public UserRepository(IDataBaseFactory dataBaseFactory)
            : base(dataBaseFactory)
        {

        }
    }
}
