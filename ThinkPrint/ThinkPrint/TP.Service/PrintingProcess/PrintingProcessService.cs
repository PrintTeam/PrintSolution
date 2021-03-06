﻿using System;
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
        private readonly IMachineRepository m_Machine;
        private readonly ISysSettingRepository m_SysSetting;
        private readonly IPaperRepository m_Paper;
        private readonly IUnitOfWork m_UnitOfWork;

        public PrintingProcessService(IPrintingProcessRepository repository, IMachineRepository machineRepository,
            ISysSettingRepository sysSettingRepository,IPaperRepository paperRepository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_Machine = machineRepository;
            m_SysSetting = sysSettingRepository;
            m_Paper = paperRepository;
            m_UnitOfWork = unitOfWork;
        }

        public PMW_PrintingProcess GetPrintingProcess(int PrintingProcessId) {
            return m_Repository.GetById(PrintingProcessId);
        }

        public List<PMWPrintingProcess> GetPrintingProcesss() {
            var q = from a in m_Repository.Table
                    join b in m_Machine.Table on a.MachineId equals b.MachineId
                    join c in m_Paper.Table on a.PaperId equals c.PaperId
                    join d in m_SysSetting.Table on a.ColorType equals d.ParamValue
                    join e in m_SysSetting.Table on a.SideProperty equals e.ParamValue
                    where a.IsDelete == false
                    orderby a.ModifiedDate descending
                    select new PMWPrintingProcess {
                        PrintingProcessId = a.PrintingProcessId,
                        MachineId = a.MachineId,
                        Machine = b.Name,
                        PaperId = a.PaperId,
                        PaperName = c.Name,
                        Name = a.Name,
                        ShortName = a.ShortName,
                        MnemonicCode = a.MnemonicCode,
                        PartsAttributeCode = a.PartsAttributeCode,
                        SideProperty = a.SideProperty,
                        SideName = e.Name,
                        ColorType = a.ColorType,
                        ColorTypeName = d.Name
                    };
            return q.ToList();           
        }

        public PagedList<PMWPrintingProcess> GetPrintingProcesss(int pageIndex, int pageSize, string searchKey = null) {
            var q = from a in m_Repository.Table
                    join b in m_Machine.Table on a.MachineId equals b.MachineId
                    join c in m_Paper.Table on a.PaperId equals c.PaperId
                    join d in m_SysSetting.Table on a.ColorType equals d.ParamValue
                    join e in m_SysSetting.Table on a.SideProperty equals e.ParamValue
                    where a.IsDelete == false 
                    orderby a.ModifiedDate descending
                    select new PMWPrintingProcess {
                        PrintingProcessId = a.PrintingProcessId,
                        MachineId = a.MachineId,
                        Machine = b.Name,
                        PaperId = a.PaperId,
                        PaperName = c.Name,                        
                        Name = a.Name,
                        ShortName = a.ShortName,
                        MnemonicCode = a.MnemonicCode,
                        PartsAttributeCode = a.PartsAttributeCode,
                        SideProperty = a.SideProperty,
                        SideName = e.Name,
                        ColorType = a.ColorType,
                        ColorTypeName = d.Name
                    };
            if (!string.IsNullOrWhiteSpace(searchKey)) {
                q = from a in m_Repository.Table
                    join b in m_Machine.Table on a.MachineId equals b.MachineId
                    join c in m_Paper.Table on a.PaperId equals c.PaperId
                    join d in m_SysSetting.Table on a.ColorType equals d.ParamValue
                    join e in m_SysSetting.Table on a.SideProperty equals e.ParamValue
                    where a.IsDelete == false && a.Name.Contains(searchKey)
                    orderby a.ModifiedDate descending
                    select new PMWPrintingProcess {
                        PrintingProcessId = a.PrintingProcessId,
                        MachineId = a.MachineId,
                        Machine = b.Name,
                        PaperId = a.PaperId,
                        PaperName = c.Name,                          
                        Name = a.Name,
                        ShortName = a.ShortName,
                        MnemonicCode = a.MnemonicCode,
                        PartsAttributeCode = a.PartsAttributeCode,
                        SideProperty = a.SideProperty,
                        SideName = e.Name,
                        ColorType = a.ColorType,
                        ColorTypeName = d.Name
                    };
            }
            return q.ToPagedList<PMWPrintingProcess>(pageIndex, pageSize);  
        }

        public void InsertPrintingProcess(PMW_PrintingProcess PrintingProcess) {
            if (PrintingProcess == null)
                throw new ArgumentNullException("印刷工序实体不能为null值");
            PrintingProcess.IsDelete = false;
            PrintingProcess.ModifiedDate = DateTime.Now.ToLocalTime();
            String PaperPartCode = m_Paper.GetById(PrintingProcess.PaperId).PartsAttributeCode;
            PrintingProcess.PartsAttributeCode = PaperPartCode + PrintingProcess.ColorType + PrintingProcess.SideProperty;
            m_Repository.Add(PrintingProcess);
            m_UnitOfWork.Commint();
        }

        public void UpdatePrintingProcess(PMW_PrintingProcess PrintingProcess) {
            if (PrintingProcess == null)
                throw new ArgumentNullException("印刷工序实体不能为null值");
            PrintingProcess.ModifiedDate = DateTime.Now.ToLocalTime();
            String PaperPartCode = m_Paper.GetById(PrintingProcess.PaperId).PartsAttributeCode;
            PrintingProcess.PartsAttributeCode = PaperPartCode + PrintingProcess.ColorType + PrintingProcess.SideProperty;
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

