using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.MachineCategory {

    public interface IMachineCategoryService {
        PMW_MachineCategory GetMachineCategory(int  MachineCategoryId);
        List<PMW_MachineCategory> GetMachineCategorys();
        PagedList<PMW_MachineCategory> GetMachineCategorys(int pageIndex, int pageSize, string searchKey = null);
        void InsertMachineCategory(PMW_MachineCategory MachineCategory);
        void UpdateMachineCategory(PMW_MachineCategory MachineCategory);
        void DeleteMachineCategory(PMW_MachineCategory MachineCategory);
    }
}

