using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.Paper {

    /// <summary>
    /// 纸张信息业务服务对象
    /// </summary>
    public class PaperService:IPaperService {
        private readonly IPaperRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public PaperService(IPaperRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public BOM_Paper GetPaper(int  PaperId) {
            return m_Repository.GetById(PaperId);
        }

        public List<BOM_Paper> GetPapers() {
            return m_Repository.Table.Where(p => p.IsDelete == false).ToList();
        }

        public PagedList<BOM_Paper> GetPapers(int pageIndex, int pageSize, string searchKey = null) {
            var q = m_Repository.Table.Where(u => u.IsDelete == false);
            if (!string.IsNullOrWhiteSpace(searchKey)) {
                q = q.Where(p => p.Name.Contains(searchKey));
            }
            q = q.OrderByDescending(p => p.ModifiedDate);
            PagedList<BOM_Paper> result = q.ToPagedList<BOM_Paper>(pageIndex, pageSize);
            return result;
        }

        public void InsertPaper(BOM_Paper Paper) {
            if (Paper == null) throw new ArgumentNullException("纸张信息实体不能为null值");
            Paper.IsDelete = false;
            Paper.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(Paper);
            m_UnitOfWork.Commint();
        }

        public void UpdatePaper(BOM_Paper Paper) {
            if (Paper == null) throw new ArgumentNullException("纸张信息实体不能为null值");           
            Paper.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(Paper);
            m_UnitOfWork.Commint();
        }

        public void DeletePaper(BOM_Paper Paper) {
            if (Paper == null) throw new ArgumentNullException("纸张信息实体不能为null值");
            Paper.IsDelete = true;
            Paper.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(Paper);
            m_UnitOfWork.Commint();
        }    
    }
}

