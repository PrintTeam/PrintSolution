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
    public class PaperService : IPaperService {
        private readonly IPaperRepository m_Repository;
        private readonly IPaperCategoryRepository m_PaperCategory;
        private readonly IPaperSizeRepository m_PaperSize;
        private readonly IUnitOfWork m_UnitOfWork;

        public PaperService(IPaperRepository repository, IPaperCategoryRepository paperCategory,
            IPaperSizeRepository paperSize, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_PaperCategory = paperCategory;
            m_PaperSize = paperSize;
            m_UnitOfWork = unitOfWork;
        }

        public BOM_Paper GetPaper(int PaperId) {
            return m_Repository.GetById(PaperId);
        }

        public List<BOMPaper> GetPapers() {
            var q = from a in m_Repository.Table
                    join b in m_PaperCategory.Table on a.PaperCategoryId equals b.PaperCategoryId
                    join c in m_PaperSize.Table on a.PaperSizeId equals c.PaperSizeId
                    where a.IsDelete == false
                    orderby a.ModifiedDate descending
                    select new BOMPaper {
                        PaperId = a.PaperId,
                        PaperCategoryId = a.PaperCategoryId,
                        PaperCategory = b.Name,
                        PaperSizeId = a.PaperSizeId,
                        PaperSize = c.Name,
                        Name = a.Name,
                        PartsAttributeCode = a.PartsAttributeCode,
                        MnemonicCode = a.MnemonicCode,
                        Weight = a.Weight,
                        Description = a.Description
                    };
            return q.ToList();
        }

        public PagedList<BOMPaper> GetPapers(int pageIndex, int pageSize, string searchKey = null) {
            var q = from a in m_Repository.Table
                    join b in m_PaperCategory.Table on a.PaperCategoryId equals b.PaperCategoryId
                    join c in m_PaperSize.Table on a.PaperSizeId equals c.PaperSizeId
                    where a.IsDelete == false
                    orderby a.ModifiedDate descending
                    select new BOMPaper {
                        PaperId = a.PaperId,
                        PaperCategoryId = a.PaperCategoryId,
                        PaperCategory = b.Name,
                        PaperSizeId = a.PaperSizeId,
                        PaperSize = c.Name,
                        Name = a.Name,
                        PartsAttributeCode = a.PartsAttributeCode,
                        MnemonicCode = a.MnemonicCode,
                        Weight = a.Weight,
                        Description = a.Description
                    };
            if (!String.IsNullOrWhiteSpace(searchKey)) {
                q = from a in m_Repository.Table
                    join b in m_PaperCategory.Table on a.PaperCategoryId equals b.PaperCategoryId
                    join c in m_PaperSize.Table on a.PaperSizeId equals c.PaperSizeId
                    where a.IsDelete == false && a.Name.Contains(searchKey)
                    orderby a.ModifiedDate descending
                    select new BOMPaper {
                        PaperId = a.PaperId,
                        PaperCategoryId = a.PaperCategoryId,
                        PaperCategory = b.Name,
                        PaperSizeId = a.PaperSizeId,
                        PaperSize = c.Name,
                        Name = a.Name,
                        PartsAttributeCode = a.PartsAttributeCode,
                        MnemonicCode = a.MnemonicCode,
                        Weight = a.Weight,
                        Description = a.Description
                    };
            }
            return q.ToPagedList<BOMPaper>(pageIndex, pageSize);
        }

        public void InsertPaper(BOM_Paper Paper) {
            if (Paper == null)
                throw new ArgumentNullException("纸张信息实体不能为null值");
            Paper.IsDelete = false;
            Paper.PartsAttributeCode = m_PaperSize.GetById(Paper.PaperSizeId).UniqueCode +
                    Paper.Weight + m_PaperCategory.GetById(Paper.PaperCategoryId).UniqueCode;
            Paper.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(Paper);
            m_UnitOfWork.Commint();
        }

        public void UpdatePaper(BOM_Paper Paper) {
            if (Paper == null)
                throw new ArgumentNullException("纸张信息实体不能为null值");
            Paper.ModifiedDate = DateTime.Now.ToLocalTime();
            Paper.PartsAttributeCode = m_PaperSize.GetById(Paper.PaperSizeId).UniqueCode +
                    Paper.Weight + m_PaperCategory.GetById(Paper.PaperCategoryId).UniqueCode;
            m_Repository.Update(Paper);
            m_UnitOfWork.Commint();
        }

        public void DeletePaper(BOM_Paper Paper) {
            if (Paper == null)
                throw new ArgumentNullException("纸张信息实体不能为null值");
            Paper.IsDelete = true;
            Paper.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(Paper);
            m_UnitOfWork.Commint();
        }
    }
}

