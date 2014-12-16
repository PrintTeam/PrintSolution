using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.PostpressProcess {

    public interface IPostpressProcessService {
        PMW_PostpressProcess GetPostpressProcess(int  PostpressProcessId);
        List<PMW_PostpressProcess> GetPostpressProcesss();
        PagedList<PMW_PostpressProcess> GetPostpressProcesss(int pageIndex, int pageSize, string searchKey = null);
        void InsertPostpressProcess(PMW_PostpressProcess PostpressProcess);
        void UpdatePostpressProcess(PMW_PostpressProcess PostpressProcess);
        void DeletePostpressProcess(PMW_PostpressProcess PostpressProcess);
    }
}

