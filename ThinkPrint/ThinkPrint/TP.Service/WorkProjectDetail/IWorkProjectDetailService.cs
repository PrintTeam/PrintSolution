using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.WorkProjectDetail {

    public interface IWorkProjectDetailService {
        SAL_WorkProjectDetail GetWorkProjectDetail(int  WorkProjectDetailId);
        List<SAL_WorkProjectDetail> GetWorkProjectDetails();
        PagedList<SAL_WorkProjectDetail> GetWorkProjectDetails(int pageIndex, int pageSize);
        void InsertWorkProjectDetail(SAL_WorkProjectDetail WorkProjectDetail);
        void UpdateWorkProjectDetail(SAL_WorkProjectDetail WorkProjectDetail);
        void DeleteWorkProjectDetail(SAL_WorkProjectDetail WorkProjectDetail);
    }
}

