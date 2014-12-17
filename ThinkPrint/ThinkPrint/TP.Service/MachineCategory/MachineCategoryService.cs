using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.MachineCategory {

    /// <summary>
    /// 机器类型业务服务对象
    /// </summary>
    public class MachineCategoryService:IMachineCategoryService {
        private readonly IMachineCategoryRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public MachineCategoryService(IMachineCategoryRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public PMW_MachineCategory GetMachineCategory(int  MachineCategoryId) {
            return m_Repository.GetById(MachineCategoryId);
        }

        public List<PMW_MachineCategory> GetMachineCategorys() {
            return m_Repository.Table.Where(p => p.IsDelete == false).ToList();
        }

        public PagedList<PMW_MachineCategory> GetMachineCategorys(int pageIndex, int pageSize, string searchKey = null) {
            var q = m_Repository.Table.Where(u => u.IsDelete == false);
            if (!string.IsNullOrWhiteSpace(searchKey)) {
                q = q.Where(p => p.Name.Contains(searchKey));
            }
            q = q.OrderByDescending(p => p.ModifiedDate);
            PagedList<PMW_MachineCategory> result = q.ToPagedList<PMW_MachineCategory>(pageIndex, pageSize);
            return result;
        }

        public void InsertMachineCategory(PMW_MachineCategory MachineCategory) {
            if (MachineCategory == null) throw new ArgumentNullException("机器类型实体不能为null值");
            MachineCategory.IsDelete = false;
            MachineCategory.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(MachineCategory);
            m_UnitOfWork.Commint();
        }

        public void UpdateMachineCategory(PMW_MachineCategory MachineCategory) {
            if (MachineCategory == null) throw new ArgumentNullException("机器类型实体不能为null值");           
            MachineCategory.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(MachineCategory);
            m_UnitOfWork.Commint();
        }

        public void DeleteMachineCategory(PMW_MachineCategory MachineCategory) {
            if (MachineCategory == null) throw new ArgumentNullException("机器类型实体不能为null值");
            MachineCategory.IsDelete = true;
            MachineCategory.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(MachineCategory);
            m_UnitOfWork.Commint();
        }    
    }
}

