using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.PostpressProcess {

    /// <summary>
    /// 印后工序业务服务对象
    /// </summary>
    public class PostpressProcessService:IPostpressProcessService {
        private readonly IPostpressProcessRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public PostpressProcessService(IPostpressProcessRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public PMW_PostpressProcess GetPostpressProcess(int  PostpressProcessId) {
            return m_Repository.GetById(PostpressProcessId);
        }

        public List<PMW_PostpressProcess> GetPostpressProcesss() {
            return m_Repository.Table.Where(p => p.IsDelete == false).ToList();
        }

        public PagedList<PMW_PostpressProcess> GetPostpressProcesss(int pageIndex, int pageSize, string searchKey = null) {
            var q = m_Repository.Table.Where(u => u.IsDelete == false);
            if (!string.IsNullOrWhiteSpace(searchKey)) {
                q = q.Where(p => p.Name.Contains(searchKey));
            }
            q = q.OrderByDescending(p => p.ModifiedDate);
            PagedList<PMW_PostpressProcess> result = q.ToPagedList<PMW_PostpressProcess>(pageIndex, pageSize);
            return result;
        }

        public void InsertPostpressProcess(PMW_PostpressProcess PostpressProcess) {
            if (PostpressProcess == null) throw new ArgumentNullException("印后工序实体不能为null值");
            PostpressProcess.IsDelete = false;
            PostpressProcess.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(PostpressProcess);
            m_UnitOfWork.Commint();
        }

        public void UpdatePostpressProcess(PMW_PostpressProcess PostpressProcess) {
            if (PostpressProcess == null) throw new ArgumentNullException("印后工序实体不能为null值");           
            PostpressProcess.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(PostpressProcess);
            m_UnitOfWork.Commint();
        }

        public void DeletePostpressProcess(PMW_PostpressProcess PostpressProcess) {
            if (PostpressProcess == null) throw new ArgumentNullException("印后工序实体不能为null值");
            PostpressProcess.IsDelete = true;
            PostpressProcess.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(PostpressProcess);
            m_UnitOfWork.Commint();
        }    
    }
}

