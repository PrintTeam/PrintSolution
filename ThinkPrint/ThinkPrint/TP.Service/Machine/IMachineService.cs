using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.Machine {

    public interface IMachineService {
        PMW_Machine GetMachine(int  MachineId);
        PMW_Machine GetMachine(String UniqueCode);
        List<PMW_Machine> GetMachines();
        PagedList<PMW_Machine> GetMachines(int pageIndex, int pageSize, string searchKey = null);
        void InsertMachine(PMW_Machine Machine);
        void UpdateMachine(PMW_Machine Machine);
        void DeleteMachine(PMW_Machine Machine);
    }    
}

