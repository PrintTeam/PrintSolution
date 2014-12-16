using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.WorkProject {

    /// <summary>
    /// 制作项目业务服务对象
    /// </summary>
    public class WorkProjectService:IWorkProjectService {
        private readonly IWorkProjectRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public WorkProjectService(IWorkProjectRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public SAL_WorkProject GetWorkProject(int  WorkProjectId) {
            return m_Repository.GetById(WorkProjectId);
        }

        public List<SAL_WorkProject> GetWorkProjects() {
            return m_Repository.Table.ToList();
        }

        public PagedList<SAL_WorkProject> GetWorkProjects(int pageIndex, int pageSize, string searchKey = null) {
            var q = m_Repository.Table;
            if (!string.IsNullOrWhiteSpace(searchKey)) {
                q = q.Where(p => p.ProjectName.Contains(searchKey));
            }
            q = q.OrderByDescending(p => p.WorkProjectId);
            PagedList<SAL_WorkProject> result = q.ToPagedList<SAL_WorkProject>(pageIndex, pageSize);
            return result;
        }

        public void InsertWorkProject(SAL_WorkProject WorkProject) {
            if (WorkProject == null) throw new ArgumentNullException("制作项目实体不能为null值");          
            m_Repository.Add(WorkProject);
            m_UnitOfWork.Commint();
        }

        public void UpdateWorkProject(SAL_WorkProject WorkProject) {
            if (WorkProject == null) throw new ArgumentNullException("制作项目实体不能为null值");
            m_Repository.Update(WorkProject);
            m_UnitOfWork.Commint();
        }

        public void DeleteWorkProject(SAL_WorkProject WorkProject) {
            if (WorkProject == null) throw new ArgumentNullException("制作项目实体不能为null值");           
            m_Repository.Update(WorkProject);
            m_UnitOfWork.Commint();
        }    
    }
}

