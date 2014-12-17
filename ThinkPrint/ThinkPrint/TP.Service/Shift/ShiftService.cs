using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.Shift {

    /// <summary>
    /// 工作轮班信息业务服务对象
    /// </summary>
    public class ShiftService:IShiftService {
        private readonly IShiftRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public ShiftService(IShiftRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public ORG_Shift GetShift(int  ShiftId) {
            return m_Repository.GetById(ShiftId);
        }

        public List<ORG_Shift> GetShifts() {
            return m_Repository.Table.ToList();
        }

        public PagedList<ORG_Shift> GetShifts(int pageIndex, int pageSize, string searchKey = null) {
            var q = m_Repository.Table;
            if (!string.IsNullOrWhiteSpace(searchKey)) {
                q = q.Where(p => p.Name.Contains(searchKey));
            }
            q = q.OrderByDescending(p => p.ModifiedDate);
            PagedList<ORG_Shift> result = q.ToPagedList<ORG_Shift>(pageIndex, pageSize);
            return result;
        }

        public void InsertShift(ORG_Shift Shift) {
            if (Shift == null) throw new ArgumentNullException("工作轮班信息实体不能为null值");           
            Shift.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(Shift);
            m_UnitOfWork.Commint();
        }

        public void UpdateShift(ORG_Shift Shift) {
            if (Shift == null) throw new ArgumentNullException("工作轮班信息实体不能为null值");           
            Shift.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(Shift);
            m_UnitOfWork.Commint();
        }

        public void DeleteShift(ORG_Shift Shift) {
            if (Shift == null) throw new ArgumentNullException("工作轮班信息实体不能为null值");          
            Shift.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(Shift);
            m_UnitOfWork.Commint();
        }    
    }
}

