using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Repository.Base;
using TP.EntityFramework.Models;
using TP.EntityFramework;

namespace TP.Repository {

    public class PaperRepository : BaseRepository<BOM_Paper>, IPaperRepository {

        public PaperRepository(IDataBaseFactory dataBaseFactory)
            : base(dataBaseFactory) {

        }
    }
}
