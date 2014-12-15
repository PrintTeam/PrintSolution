using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.Unit {
    public interface IUnitService {
        SYS_Unit GetUnit(int unitID);
        List<SYS_Unit> GetUnits();
        PagedList<SYS_Unit> GetUnits(int pageIndex, int pageSize, string searchKey = null);
        void InsertUnit(SYS_Unit unit);
        void UpdateUnit(SYS_Unit unit);
        void DeleteUnit(SYS_Unit unit);
    }
}
