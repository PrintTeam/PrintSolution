using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework;
using TP.EntityFramework.Models;
using TP.Repository.Base;

namespace TP.Repository
{
    public class SysSettingRepository : BaseRepository<SYS_SysSetting>, ISysSettingRepository
    {
        public SysSettingRepository(IDataBaseFactory dataBaseFactory)
            : base(dataBaseFactory)
        {

        }
    }
}
