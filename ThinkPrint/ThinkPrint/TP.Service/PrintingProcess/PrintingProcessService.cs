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
    public class PrintingProcessService : IPrintingProcessService {
        private readonly IPrintingProcessRepository m_Repository;
        private readonly IMachineRepository m_MachineRepository;
        private readonly ISysSettingRepository m_SysSettingRepository;
        private readonly IUnitOfWork m_UnitOfWork;

        public PrintingProcessService(IPrintingProcessRepository repository, IMachineRepository machineRepository,
            ISysSettingRepository sysSettingRepository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_MachineRepository = machineRepository;
            m_SysSettingRepository = sysSettingRepository;
            m_UnitOfWork = unitOfWork;
        }

        public PMW_PrintingProcess GetPrintingProcess(int PrintingProcessId) {
            return m_Repository.GetById(PrintingProcessId);
        }

        public List<PMWPrintingProcess> GetPrintingProcesss() {
            /*var q = from a in m_Repository.Table
                    join b in m_MachineRepository.Table on a.MachineId equals b.MachineId
                  
                    join d in m_SysSettingRepository.Table on a.ColorType equals d.ParamValue
                    where a.IsDelete == false
                    orderby a.ModifiedDate descending
                    select new PMWPrintingProcess {
                        PrintingProcessId = a.PrintingProcessId,
                        MachineId = a.MachineId,
                        
                        Name = a.Name,
                        ShortName = a.ShortName,
                        MnemonicCode = a.MnemonicCode,
                        PartsAttributeCode = a.PartsAttributeCode,
                        SideProperty = a.SideProperty,
                        ColorType = a.ColorType,
                        ColorTypeName = d.Name
                    };
            return q.ToList();*/
            return null;
        }

        public PagedList<PMWPrintingProcess> GetPrintingProcesss(int pageIndex, int pageSize, string searchKey = null) {
            /*var q = from a in m_Repository.Table
                    join b in m_MachineRepository.Table on a.MachineId equals b.MachineId
                   
                    join d in m_SysSettingRepository.Table on a.ColorType equals d.ParamValue
                    where a.IsDelete == false 
                    orderby a.ModifiedDate descending
                    select new PMWPrintingProcess {
                        PrintingProcessId = a.PrintingProcessId,
                        MachineId = a.MachineId,
                        
                        Name = a.Name,
                        ShortName = a.ShortName,
                        MnemonicCode = a.MnemonicCode,
                        PartsAttributeCode = a.PartsAttributeCode,
                        SideProperty = a.SideProperty,
                        ColorType = a.ColorType,
                        ColorTypeName = d.Name
                    };
            if (!string.IsNullOrWhiteSpace(searchKey)) {
                q = from a in m_Repository.Table
                    join b in m_MachineRepository.Table on a.MachineId equals b.MachineId
                   
                    join d in m_SysSettingRepository.Table on a.ColorType equals d.ParamValue
                    where a.IsDelete == false && a.Name.Contains(searchKey)
                    orderby a.ModifiedDate descending
                    select new PMWPrintingProcess {
                        PrintingProcessId = a.PrintingProcessId,
                        MachineId = a.MachineId,
                       
                        Name = a.Name,
                        ShortName = a.ShortName,
                        MnemonicCode = a.MnemonicCode,
                        PartsAttributeCode = a.PartsAttributeCode,
                        SideProperty = a.SideProperty,
                        ColorType = a.ColorType,
                        ColorTypeName = d.Name
                    };
            }
            return q.ToPagedList<PMWPrintingProcess>(pageIndex, pageSize);   */
            return null;
        }

        public void InsertPrintingProcess(PMW_PrintingProcess PrintingProcess) {
            if (PrintingProcess == null)
                throw new ArgumentNullException("印刷工序实体不能为null值");
            PrintingProcess.IsDelete = false;
            PrintingProcess.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(PrintingProcess);
            m_UnitOfWork.Commint();
        }

        public void UpdatePrintingProcess(PMW_PrintingProcess PrintingProcess) {
            if (PrintingProcess == null)
                throw new ArgumentNullException("印刷工序实体不能为null值");
            PrintingProcess.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(PrintingProcess);
            m_UnitOfWork.Commint();
        }

        public void DeletePrintingProcess(PMW_PrintingProcess PrintingProcess) {
            if (PrintingProcess == null)
                throw new ArgumentNullException("印刷工序实体不能为null值");
            PrintingProcess.IsDelete = true;
            PrintingProcess.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(PrintingProcess);
            m_UnitOfWork.Commint();
        }
    }
}

