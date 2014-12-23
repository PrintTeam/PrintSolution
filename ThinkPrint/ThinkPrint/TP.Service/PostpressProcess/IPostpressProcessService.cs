using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.PostpressProcess {

    public interface IPostpressProcessService {
        PMW_PostpressProcess GetPostpressProcess(int PostpressProcessId);
        PMWPostpressProcess GetPostpressProcess(String UniqueCode);
        List<PMWPostpressProcess> GetPostpressProcesss();
        PagedList<PMWPostpressProcess> GetPostpressProcesss(int pageIndex, int pageSize, string searchKey = null);
        void InsertPostpressProcess(PMW_PostpressProcess PostpressProcess);
        void UpdatePostpressProcess(PMW_PostpressProcess PostpressProcess);
        void DeletePostpressProcess(PMW_PostpressProcess PostpressProcess);
    }

    public class PMWPostpressProcess {
        public int PostpressProcessId {
            get;
            set;
        }
        public int MachineId {
            get;
            set;
        }
        public String Machine {
            get;
            set;
        }
        public string ProcessType {
            get;
            set;
        }
        public string ProcessTypeName {
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
        public string SideProperty {
            get;
            set;
        }
        public String PricingModels {
            get;
            set;
        }
        public string PricingModelName {
            get;
            set;
        }
    }
}

