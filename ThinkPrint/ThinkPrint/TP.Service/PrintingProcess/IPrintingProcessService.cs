using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.PrintingProcess {

    public interface IPrintingProcessService {
        PMW_PrintingProcess GetPrintingProcess(int  PrintingProcessId);
        List<PMW_PrintingProcess> GetPrintingProcesss();
        PagedList<PMW_PrintingProcess> GetPrintingProcesss(int pageIndex, int pageSize, string searchKey = null);
        void InsertPrintingProcess(PMW_PrintingProcess PrintingProcess);
        void UpdatePrintingProcess(PMW_PrintingProcess PrintingProcess);
        void DeletePrintingProcess(PMW_PrintingProcess PrintingProcess);
    }
}

