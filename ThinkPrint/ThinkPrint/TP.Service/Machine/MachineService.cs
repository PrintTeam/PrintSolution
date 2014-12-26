using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;
using TP.Service.SysResource;

namespace TP.Service.Machine {

    /// <summary>
    /// 机器设备业务服务对象
    /// </summary>
    public class MachineService:IMachineService {
        private readonly IMachineRepository m_Repository;
        private readonly IMachineCategoryRepository m_CategoryRepository;
        private readonly ISysSettingRepository m_SysSettingRepository;
        private readonly IUnitOfWork m_UnitOfWork;

        public MachineService(IMachineRepository repository, IMachineCategoryRepository CategoryRepository,
            ISysSettingRepository SysSettingRepository, IUnitOfWork unitOfWork) {
            m_CategoryRepository = CategoryRepository;
            m_Repository = repository;
            m_SysSettingRepository = SysSettingRepository;
            m_UnitOfWork = unitOfWork;
        }

        public PMW_Machine GetMachine(int  MachineId) {
            return m_Repository.GetById(MachineId);
        }

        public PMW_Machine GetMachine(String UniqueCode) {
            var q = m_Repository.Table.Where(p => p.UniqueCode == UniqueCode).ToList();           
            return q.Count>0?q.First():null;
        }

        public List<PMW_Machine> GetMachines() {            
            return m_Repository.Table.Where(p => p.IsDelete == false).ToList();
        }

        public PagedList<PMW_Machine> GetMachines(int pageIndex, int pageSize, string searchKey = null) {
            var q = m_Repository.Table.Where(u => u.IsDelete == false);
            if (!String.IsNullOrWhiteSpace(searchKey))
                q = q.Where(p => p.Name.Contains(searchKey));
            q = q.OrderByDescending(p => p.ModifiedDate);
            return q.ToPagedList<PMW_Machine>(pageIndex, pageSize);
        }

        public void InsertMachine(PMW_Machine Machine) {
            if (Machine == null) throw new ArgumentNullException("机器设备实体不能为null值");
            Machine.IsDelete = false;
            Machine.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(Machine);
            m_UnitOfWork.Commint();
        }

        public void UpdateMachine(PMW_Machine Machine) {
            if (Machine == null) throw new ArgumentNullException("机器设备实体不能为null值");           
            Machine.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(Machine);
            m_UnitOfWork.Commint();
        }

        public void DeleteMachine(PMW_Machine Machine) {
            if (Machine == null) throw new ArgumentNullException("机器设备实体不能为null值");
            Machine.IsDelete = true;
            Machine.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(Machine);
            m_UnitOfWork.Commint();
        }    
    }

   
}

