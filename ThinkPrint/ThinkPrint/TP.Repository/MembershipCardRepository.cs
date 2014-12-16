using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Repository.Base;
using TP.EntityFramework.Models;
using TP.EntityFramework;

namespace TP.Repository {

    public class MembershipCardRepository : BaseRepository<CRM_MembershipCard>, IMembershipCardRepository {

        public MembershipCardRepository(IDataBaseFactory dataBaseFactory)
            : base(dataBaseFactory) {

        }
    }
}
