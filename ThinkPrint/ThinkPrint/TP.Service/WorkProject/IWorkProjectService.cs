using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.WorkProject {

    public interface IWorkProjectService {
        SAL_WorkProject GetWorkProject(int  WorkProjectId);
        List<SAL_WorkProject> GetWorkProjects();
        PagedList<SAL_WorkProject> GetWorkProjects(int pageIndex, int pageSize, string searchKey = null);
        void InsertWorkProject(SAL_WorkProject WorkProject);
        void UpdateWorkProject(SAL_WorkProject WorkProject);
        void DeleteWorkProject(SAL_WorkProject WorkProject);
    }
}

