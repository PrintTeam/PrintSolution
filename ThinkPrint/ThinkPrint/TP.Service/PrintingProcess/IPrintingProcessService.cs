using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.PrintingProcess {

    public interface IPrintingProcessService {
        PMW_PrintingProcess GetPrintingProcess(int PrintingProcessId);
        List<PMWPrintingProcess> GetPrintingProcesss();
        PagedList<PMWPrintingProcess> GetPrintingProcesss(int pageIndex, int pageSize, string searchKey = null);
        void InsertPrintingProcess(PMW_PrintingProcess PrintingProcess);
        void UpdatePrintingProcess(PMW_PrintingProcess PrintingProcess);
        void DeletePrintingProcess(PMW_PrintingProcess PrintingProcess);
    }

    public class PMWPrintingProcess {
        public int PrintingProcessId {
            get;
            set;
        }
        public int MachineId {
            get;
            set;
        }
        public string Machine {
            get;
            set;
        }
        public string ProcessType {
            get;
            set;
        }
        public String ProcessTypeName {
            get;
            set;
        }
        public string Name {
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
        public string PartsAttributeCode {
            get;
            set;
        }
        public string SideProperty {
            get;
            set;
        }
        public string ColorType {
            get;
            set;
        }
        public string ColorTypeName {
            get;
            set;
        }
    }
}

