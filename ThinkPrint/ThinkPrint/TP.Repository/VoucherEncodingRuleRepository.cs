using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Repository.Base;
using TP.EntityFramework.Models;
using TP.EntityFramework;

namespace TP.Repository {

    public class VoucherEncodingRuleRepository : BaseRepository<SYS_VoucherEncodingRule>, IVoucherEncodingRuleRepository {

        public VoucherEncodingRuleRepository(IDataBaseFactory dataBaseFactory)
            : base(dataBaseFactory) {

        }
    }
}
