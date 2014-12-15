using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework;
using TP.EntityFramework.Models;
using TP.Repository.Base;

namespace TP.Repository {
    public class UnitRepository : BaseRepository<SYS_Unit>, IUnitRepository {
        public UnitRepository(IDataBaseFactory dataBaseFactory)
            : base(dataBaseFactory) {

        }
    }
}
