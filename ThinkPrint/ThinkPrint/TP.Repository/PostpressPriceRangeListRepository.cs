using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Repository.Base;
using TP.EntityFramework.Models;
using TP.EntityFramework;

namespace TP.Repository {

    public class PostpressPriceRangeListRepository : BaseRepository<PMW_PostpressPriceRangeList>, IPostpressPriceRangeListRepository {

        public PostpressPriceRangeListRepository(IDataBaseFactory dataBaseFactory)
            : base(dataBaseFactory) {

        }
    }
}
