using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.PaperSize {

    /// <summary>
    /// 纸张尺寸业务服务对象
    /// </summary>
    public class PaperSizeService:IPaperSizeService {
        private readonly IPaperSizeRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public PaperSizeService(IPaperSizeRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public BOM_PaperSize GetPaperSize(int  PaperSizeId) {
            return m_Repository.GetById(PaperSizeId);
        }

        public List<BOM_PaperSize> GetPaperSizes() {
            return m_Repository.Table.Where(p => p.IsDelete == false).ToList();
        }

        public PagedList<BOM_PaperSize> GetPaperSizes(int pageIndex, int pageSize, string searchKey = null) {
            var q = m_Repository.Table.Where(u => u.IsDelete == false);
            if (!string.IsNullOrWhiteSpace(searchKey)) {
                q = q.Where(p => p.Name.Contains(searchKey));
            }
            q = q.OrderByDescending(p => p.ModifiedDate);
            PagedList<BOM_PaperSize> result = q.ToPagedList<BOM_PaperSize>(pageIndex, pageSize);
            return result;
        }

        public void InsertPaperSize(BOM_PaperSize PaperSize) {
            if (PaperSize == null) throw new ArgumentNullException("纸张尺寸实体不能为null值");
            PaperSize.IsDelete = false;
            PaperSize.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(PaperSize);
            m_UnitOfWork.Commint();
        }

        public void UpdatePaperSize(BOM_PaperSize PaperSize) {
            if (PaperSize == null) throw new ArgumentNullException("纸张尺寸实体不能为null值");           
            PaperSize.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(PaperSize);
            m_UnitOfWork.Commint();
        }

        public void DeletePaperSize(BOM_PaperSize PaperSize) {
            if (PaperSize == null) throw new ArgumentNullException("纸张尺寸实体不能为null值");
            PaperSize.IsDelete = true;
            PaperSize.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(PaperSize);
            m_UnitOfWork.Commint();
        }    
    }
}

