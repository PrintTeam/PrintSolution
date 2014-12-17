using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.PrintingProcess {

    /// <summary>
    /// 印刷工序业务服务对象
    /// </summary>
    public class PrintingProcessService:IPrintingProcessService {
        private readonly IPrintingProcessRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public PrintingProcessService(IPrintingProcessRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public PMW_PrintingProcess GetPrintingProcess(int  PrintingProcessId) {
            return m_Repository.GetById(PrintingProcessId);
        }

        public List<PMW_PrintingProcess> GetPrintingProcesss() {
            return m_Repository.Table.Where(p => p.IsDelete == false).ToList();
        }

        public PagedList<PMW_PrintingProcess> GetPrintingProcesss(int pageIndex, int pageSize, string searchKey = null) {
            var q = m_Repository.Table.Where(u => u.IsDelete == false);
            if (!string.IsNullOrWhiteSpace(searchKey)) {
                q = q.Where(p => p.Name.Contains(searchKey));
            }
            q = q.OrderByDescending(p => p.ModifiedDate);
            PagedList<PMW_PrintingProcess> result = q.ToPagedList<PMW_PrintingProcess>(pageIndex, pageSize);
            return result;
        }

        public void InsertPrintingProcess(PMW_PrintingProcess PrintingProcess) {
            if (PrintingProcess == null) throw new ArgumentNullException("印刷工序实体不能为null值");
            PrintingProcess.IsDelete = false;
            PrintingProcess.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(PrintingProcess);
            m_UnitOfWork.Commint();
        }

        public void UpdatePrintingProcess(PMW_PrintingProcess PrintingProcess) {
            if (PrintingProcess == null) throw new ArgumentNullException("印刷工序实体不能为null值");           
            PrintingProcess.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(PrintingProcess);
            m_UnitOfWork.Commint();
        }

        public void DeletePrintingProcess(PMW_PrintingProcess PrintingProcess) {
            if (PrintingProcess == null) throw new ArgumentNullException("印刷工序实体不能为null值");
            PrintingProcess.IsDelete = true;
            PrintingProcess.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(PrintingProcess);
            m_UnitOfWork.Commint();
        }    
    }
}

