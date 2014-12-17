using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.WorkProjectDetail {

    /// <summary>
    /// 制作项目明细业务服务对象
    /// </summary>
    public class WorkProjectDetailService:IWorkProjectDetailService {
        private readonly IWorkProjectDetailRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public WorkProjectDetailService(IWorkProjectDetailRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public SAL_WorkProjectDetail GetWorkProjectDetail(int  WorkProjectDetailId) {
            return m_Repository.GetById(WorkProjectDetailId);
        }

        public List<SAL_WorkProjectDetail> GetWorkProjectDetails() {
            return m_Repository.Table.ToList();
        }

        public PagedList<SAL_WorkProjectDetail> GetWorkProjectDetails(int pageIndex, int pageSize) {            
            var q =  m_Repository.Table.OrderByDescending(p => p.ModifiedDate);
            PagedList<SAL_WorkProjectDetail> result = q.ToPagedList<SAL_WorkProjectDetail>(pageIndex, pageSize);
            return result;
        }

        public void InsertWorkProjectDetail(SAL_WorkProjectDetail WorkProjectDetail) {
            if (WorkProjectDetail == null) throw new ArgumentNullException("制作项目明细实体不能为null值");           
            WorkProjectDetail.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(WorkProjectDetail);
            m_UnitOfWork.Commint();
        }

        public void UpdateWorkProjectDetail(SAL_WorkProjectDetail WorkProjectDetail) {
            if (WorkProjectDetail == null) throw new ArgumentNullException("制作项目明细实体不能为null值");           
            WorkProjectDetail.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(WorkProjectDetail);
            m_UnitOfWork.Commint();
        }

        public void DeleteWorkProjectDetail(SAL_WorkProjectDetail WorkProjectDetail) {
            if (WorkProjectDetail == null) throw new ArgumentNullException("制作项目明细实体不能为null值");           
            WorkProjectDetail.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(WorkProjectDetail);
            m_UnitOfWork.Commint();
        }    
    }
}

