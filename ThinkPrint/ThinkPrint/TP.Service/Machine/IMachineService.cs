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
        List<PMWMachine> GetMachines();
        PagedList<PMWMachine> GetMachines(int pageIndex, int pageSize, string searchKey = null);
        void InsertMachine(PMW_Machine Machine);
        void UpdateMachine(PMW_Machine Machine);
        void DeleteMachine(PMW_Machine Machine);
    }

    public class PMWMachine {

        public int MachineId {
            get;
            set;
        }
        public int MachineCategoryId {
            get;
            set;
        }
        public String MachineCategoryName {
            get;
            set;
        }
        public string Name {
            get;
            set;
        }
        public string UniqueCode {
            get;
            set;
        }
        public string ShortName {
            get;
            set;
        }
        public string MnemonicCode {
            get;
            set;
        }
        public string MachineType {
            get;
            set;
        }

        public String MachineTypeName {
            get;
            set;
        }
        public string ColorType {
            get;
            set;
        }

        public String ColorTypeName {
            get;
            set;
        }

    }
}

