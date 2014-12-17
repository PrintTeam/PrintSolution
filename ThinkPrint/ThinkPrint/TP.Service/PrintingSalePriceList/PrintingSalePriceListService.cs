using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.PrintingSalePriceList {

    /// <summary>
    /// 印刷销售价格业务服务对象
    /// </summary>
    public class PrintingSalePriceListService:IPrintingSalePriceListService {
        private readonly IPrintingSalePriceListRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public PrintingSalePriceListService(IPrintingSalePriceListRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public BPM_PrintingSalePriceList GetPrintingSalePriceList(int  PrintingSalePriceId) {
            return m_Repository.GetById(PrintingSalePriceId);
        }

        public List<BPM_PrintingSalePriceList> GetPrintingSalePriceLists() {
            return m_Repository.Table.ToList();
        }

        public PagedList<BPM_PrintingSalePriceList> GetPrintingSalePriceLists(int pageIndex, int pageSize, string searchKey = null) {
            var q = m_Repository.Table;
            if (!string.IsNullOrWhiteSpace(searchKey)) {
                q = q.Where(p => p.Name.Contains(searchKey));
            }
            q = q.OrderByDescending(p => p.ModifiedDate);
            PagedList<BPM_PrintingSalePriceList> result = q.ToPagedList<BPM_PrintingSalePriceList>(pageIndex, pageSize);
            return result;
        }

        public void InsertPrintingSalePriceList(BPM_PrintingSalePriceList PrintingSalePriceList) {
            if (PrintingSalePriceList == null) throw new ArgumentNullException("印刷销售价格实体不能为null值");           
            PrintingSalePriceList.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(PrintingSalePriceList);
            m_UnitOfWork.Commint();
        }

        public void UpdatePrintingSalePriceList(BPM_PrintingSalePriceList PrintingSalePriceList) {
            if (PrintingSalePriceList == null) throw new ArgumentNullException("印刷销售价格实体不能为null值");           
            PrintingSalePriceList.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(PrintingSalePriceList);
            m_UnitOfWork.Commint();
        }

        public void DeletePrintingSalePriceList(BPM_PrintingSalePriceList PrintingSalePriceList) {
            if (PrintingSalePriceList == null) throw new ArgumentNullException("印刷销售价格实体不能为null值");          
            PrintingSalePriceList.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(PrintingSalePriceList);
            m_UnitOfWork.Commint();
        }    
    }
}

