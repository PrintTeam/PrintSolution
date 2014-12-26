using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.PostpressProcess {

    /// <summary>
    /// 印后工序业务服务对象
    /// </summary>
    public class PostpressProcessService : IPostpressProcessService {
        private readonly IPostpressProcessRepository m_Repository;
        private readonly IMachineRepository m_MachineRepository;
        private readonly ISysSettingRepository m_SysSettingRepository;
        private readonly IUnitOfWork m_UnitOfWork;

        public PostpressProcessService(IPostpressProcessRepository repository, IMachineRepository machineRepository,
            ISysSettingRepository sysSettingRepository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_MachineRepository = machineRepository;
            m_SysSettingRepository = sysSettingRepository;
            m_UnitOfWork = unitOfWork;
        }

        public PMW_PostpressProcess GetPostpressProcess(int PostpressProcessId) {
            return m_Repository.GetById(PostpressProcessId);
        }

        public PMW_PostpressProcess GetPostpressProcess(String UniqueCode) {
            var q = m_Repository.Table.Where(p => p.UniqueCode == UniqueCode).ToList();
            return q.Count > 0 ? q.First() : null;
            /*var q = from a in m_Repository.Table
                    join b in m_MachineRepository.Table on a.MachineId equals b.MachineId
                   
                    join d in m_SysSettingRepository.Table on a.PricingModels equals d.ParamValue
                    where a.UniqueCode == UniqueCode
                    orderby a.ModifiedDate descending
                    select new PMWPostpressProcess {
                        PostpressProcessId = a.PostpressProcessId,
                        MachineId = a.MachineId,
                        Name = a.Name,
                        UniqueCode = a.UniqueCode,
                        ShortName = a.ShortName,
                        MnemonicCode = a.MnemonicCode,
                        SideProperty = a.SideProperty,
                        PricingModels = a.PricingModels,
                        PricingModelName = d.Name
                    };
            List<PMWPostpressProcess> List = q.ToList();
            if (List.Count > 0)
                return List.First();*/            
        }

        public List<PMW_PostpressProcess> GetPostpressProcesss() {
            return m_Repository.Table.Where(p => p.IsDelete == false)
                .OrderByDescending(p=>p.ModifiedDate)
                .ToList();
            /*var q = from a in m_Repository.Table
                    join b in m_MachineRepository.Table on a.MachineId equals b.MachineId
                 
                    join d in m_SysSettingRepository.Table on a.PricingModels equals d.ParamValue
                    where a.IsDelete == false
                    orderby a.ModifiedDate descending
                    select new PMWPostpressProcess {
                        PostpressProcessId = a.PostpressProcessId,
                        MachineId = a.MachineId,
                       
                        Name = a.Name,
                        UniqueCode = a.UniqueCode,
                        ShortName = a.ShortName,
                        MnemonicCode = a.MnemonicCode,
                        SideProperty = a.SideProperty,
                        PricingModels = a.PricingModels,
                        PricingModelName = d.Name
                    };
            return q.ToList();*/            
        }

        public PagedList<PMW_PostpressProcess> GetPostpressProcesss(int pageIndex, int pageSize, string searchKey = null) {
            var q = m_Repository.Table.Where(p => p.IsDelete == false);
            if (!String.IsNullOrWhiteSpace(searchKey))
                q = q.Where(p => p.Name.Contains(searchKey) || p.ShortName.Contains(searchKey));
            q = q.OrderByDescending(p => p.ModifiedDate);
            return q.ToPagedList<PMW_PostpressProcess>(pageIndex, pageSize);           
        }

        public void InsertPostpressProcess(PMW_PostpressProcess PostpressProcess) {
            if (PostpressProcess == null)
                throw new ArgumentNullException("印后工序实体不能为null值");
            PostpressProcess.IsDelete = false;
            PostpressProcess.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(PostpressProcess);
            m_UnitOfWork.Commint();
        }

        public void UpdatePostpressProcess(PMW_PostpressProcess PostpressProcess) {
            if (PostpressProcess == null)
                throw new ArgumentNullException("印后工序实体不能为null值");
            PostpressProcess.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(PostpressProcess);
            m_UnitOfWork.Commint();
        }

        public void DeletePostpressProcess(PMW_PostpressProcess PostpressProcess) {
            if (PostpressProcess == null)
                throw new ArgumentNullException("印后工序实体不能为null值");
            PostpressProcess.IsDelete = true;
            PostpressProcess.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(PostpressProcess);
            m_UnitOfWork.Commint();
        }
    }
}

