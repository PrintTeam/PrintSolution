using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.Shift {

    public interface IShiftService {
        ORG_Shift GetShift(int  ShiftId);
        List<ORG_Shift> GetShifts();
        PagedList<ORG_Shift> GetShifts(int pageIndex, int pageSize, string searchKey = null);
        void InsertShift(ORG_Shift Shift);
        void UpdateShift(ORG_Shift Shift);
        void DeleteShift(ORG_Shift Shift);
    }
}

