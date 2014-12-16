using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.PrintingMembershipPriceList {

    /// <summary>
    /// 会员印刷价格业务服务对象
    /// </summary>
    public class PrintingMembershipPriceListService:IPrintingMembershipPriceListService {
        private readonly IPrintingMembershipPriceListRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public PrintingMembershipPriceListService(IPrintingMembershipPriceListRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public BPM_PrintingMembershipPriceList GetPrintingMembershipPriceList(int  PrintingMembershipPriceId) {
            return m_Repository.GetById(PrintingMembershipPriceId);
        }

        public List<BPM_PrintingMembershipPriceList> GetPrintingMembershipPriceLists() {
            return m_Repository.Table.ToList();
        }

        public PagedList<BPM_PrintingMembershipPriceList> GetPrintingMembershipPriceLists(int pageIndex, int pageSize, string searchKey = null) {
            var q = m_Repository.Table;
            if (!string.IsNullOrWhiteSpace(searchKey)) {
                q = q.Where(p => p.Name.Contains(searchKey));
            }
            q = q.OrderByDescending(p => p.ModifiedDate);
            PagedList<BPM_PrintingMembershipPriceList> result = q.ToPagedList<BPM_PrintingMembershipPriceList>(pageIndex, pageSize);
            return result;
        }

        public void InsertPrintingMembershipPriceList(BPM_PrintingMembershipPriceList PrintingMembershipPriceList) {
            if (PrintingMembershipPriceList == null) throw new ArgumentNullException("会员印刷价格实体不能为null值");           
            PrintingMembershipPriceList.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(PrintingMembershipPriceList);
            m_UnitOfWork.Commint();
        }

        public void UpdatePrintingMembershipPriceList(BPM_PrintingMembershipPriceList PrintingMembershipPriceList) {
            if (PrintingMembershipPriceList == null) throw new ArgumentNullException("会员印刷价格实体不能为null值");           
            PrintingMembershipPriceList.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(PrintingMembershipPriceList);
            m_UnitOfWork.Commint();
        }

        public void DeletePrintingMembershipPriceList(BPM_PrintingMembershipPriceList PrintingMembershipPriceList) {
            if (PrintingMembershipPriceList == null) throw new ArgumentNullException("会员印刷价格实体不能为null值");           
            PrintingMembershipPriceList.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(PrintingMembershipPriceList);
            m_UnitOfWork.Commint();
        }    
    }
}

