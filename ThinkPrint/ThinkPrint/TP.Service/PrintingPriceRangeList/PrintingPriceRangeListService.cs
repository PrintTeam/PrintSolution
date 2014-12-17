using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.PrintingPriceRangeList {

    /// <summary>
    /// 印刷价格区间业务服务对象
    /// </summary>
    public class PrintingPriceRangeListService:IPrintingPriceRangeListService {
        private readonly IPrintingPriceRangeListRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public PrintingPriceRangeListService(IPrintingPriceRangeListRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public BPM_PrintingPriceRangeList GetPrintingPriceRangeList(int  PrintingPriceRangeId) {
            return m_Repository.GetById(PrintingPriceRangeId);
        }

        public List<BPM_PrintingPriceRangeList> GetPrintingPriceRangeLists() {
            return m_Repository.Table.ToList();
        }

        public PagedList<BPM_PrintingPriceRangeList> GetPrintingPriceRangeLists(int pageIndex, int pageSize) {
            var q = m_Repository.Table;           
            q = q.OrderByDescending(p => p.ModifiedDate);
            PagedList<BPM_PrintingPriceRangeList> result = q.ToPagedList<BPM_PrintingPriceRangeList>(pageIndex, pageSize);
            return result;
        }

        public void InsertPrintingPriceRangeList(BPM_PrintingPriceRangeList PrintingPriceRangeList) {
            if (PrintingPriceRangeList == null) throw new ArgumentNullException("印刷价格区间实体不能为null值");          
            PrintingPriceRangeList.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(PrintingPriceRangeList);
            m_UnitOfWork.Commint();
        }

        public void UpdatePrintingPriceRangeList(BPM_PrintingPriceRangeList PrintingPriceRangeList) {
            if (PrintingPriceRangeList == null) throw new ArgumentNullException("印刷价格区间实体不能为null值");           
            PrintingPriceRangeList.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(PrintingPriceRangeList);
            m_UnitOfWork.Commint();
        }

        public void DeletePrintingPriceRangeList(BPM_PrintingPriceRangeList PrintingPriceRangeList) {
            if (PrintingPriceRangeList == null) throw new ArgumentNullException("印刷价格区间实体不能为null值");           
            PrintingPriceRangeList.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(PrintingPriceRangeList);
            m_UnitOfWork.Commint();
        }    
    }
}

