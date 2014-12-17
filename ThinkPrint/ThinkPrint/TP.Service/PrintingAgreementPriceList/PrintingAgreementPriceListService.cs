using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.PrintingAgreementPriceList {

    /// <summary>
    /// 印刷协议价格业务服务对象
    /// </summary>
    public class PrintingAgreementPriceListService:IPrintingAgreementPriceListService {
        private readonly IPrintingAgreementPriceListRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public PrintingAgreementPriceListService(IPrintingAgreementPriceListRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public BPM_PrintingAgreementPriceList GetPrintingAgreementPriceList(int  PrintingAgreementPriceId) {
            return m_Repository.GetById(PrintingAgreementPriceId);
        }

        public List<BPM_PrintingAgreementPriceList> GetPrintingAgreementPriceLists() {
            return m_Repository.Table.ToList();
        }

        public PagedList<BPM_PrintingAgreementPriceList> GetPrintingAgreementPriceLists(int pageIndex, int pageSize, string searchKey = null) {
            var q = m_Repository.Table;
            if (!string.IsNullOrWhiteSpace(searchKey)) {
                q = q.Where(p => p.Name.Contains(searchKey));
            }
            q = q.OrderByDescending(p => p.ModifiedDate);
            PagedList<BPM_PrintingAgreementPriceList> result = q.ToPagedList<BPM_PrintingAgreementPriceList>(pageIndex, pageSize);
            return result;
        }

        public void InsertPrintingAgreementPriceList(BPM_PrintingAgreementPriceList PrintingAgreementPriceList) {
            if (PrintingAgreementPriceList == null) throw new ArgumentNullException("印刷协议价格实体不能为null值");
            
            PrintingAgreementPriceList.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(PrintingAgreementPriceList);
            m_UnitOfWork.Commint();
        }

        public void UpdatePrintingAgreementPriceList(BPM_PrintingAgreementPriceList PrintingAgreementPriceList) {
            if (PrintingAgreementPriceList == null) throw new ArgumentNullException("印刷协议价格实体不能为null值");           
            PrintingAgreementPriceList.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(PrintingAgreementPriceList);
            m_UnitOfWork.Commint();
        }

        public void DeletePrintingAgreementPriceList(BPM_PrintingAgreementPriceList PrintingAgreementPriceList) {
            if (PrintingAgreementPriceList == null) throw new ArgumentNullException("印刷协议价格实体不能为null值");           
            PrintingAgreementPriceList.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(PrintingAgreementPriceList);
            m_UnitOfWork.Commint();
        }    
    }
}

