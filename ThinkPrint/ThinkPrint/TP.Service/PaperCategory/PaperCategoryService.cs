using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.PaperCategory {

    /// <summary>
    /// 纸张类型业务服务对象
    /// </summary>
    public class PaperCategoryService:IPaperCategoryService {
        private readonly IPaperCategoryRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public PaperCategoryService(IPaperCategoryRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public BOM_PaperCategory GetPaperCategory(int  PaperCategoryId) {
            return m_Repository.GetById(PaperCategoryId);
        }

        public BOM_PaperCategory GetPaperCategory(String UniqueCode) {           
            List<BOM_PaperCategory> List =  m_Repository.Filter(p => p.IsDelete == false 
                && p.UniqueCode == UniqueCode).ToList();
            if (List.Count > 0)
                return List.First();
            return null;
        }
        public List<BOM_PaperCategory> GetPaperCategorys() {
            return m_Repository.Table.Where(p => p.IsDelete == false).ToList();
        }

        public PagedList<BOM_PaperCategory> GetPaperCategorys(int pageIndex, int pageSize, string searchKey = null) {
            var q = m_Repository.Table.Where(u => u.IsDelete == false);
            if (!string.IsNullOrWhiteSpace(searchKey)) {
                q = q.Where(p => p.Name.Contains(searchKey));
            }
            q = q.OrderByDescending(p => p.ModifiedDate);
            PagedList<BOM_PaperCategory> result = q.ToPagedList<BOM_PaperCategory>(pageIndex, pageSize);
            return result;
        }

        public void InsertPaperCategory(BOM_PaperCategory PaperCategory) {
            if (PaperCategory == null) throw new ArgumentNullException("纸张类型实体不能为null值");
            PaperCategory.IsDelete = false;
            PaperCategory.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(PaperCategory);
            m_UnitOfWork.Commint();
        }

        public void UpdatePaperCategory(BOM_PaperCategory PaperCategory) {
            if (PaperCategory == null) throw new ArgumentNullException("纸张类型实体不能为null值");           
            PaperCategory.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(PaperCategory);
            m_UnitOfWork.Commint();
        }

        public void DeletePaperCategory(BOM_PaperCategory PaperCategory) {
            if (PaperCategory == null) throw new ArgumentNullException("纸张类型实体不能为null值");
            PaperCategory.IsDelete = true;
            PaperCategory.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(PaperCategory);
            m_UnitOfWork.Commint();
        }    
    }
}

