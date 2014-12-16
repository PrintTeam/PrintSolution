using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.EmployeeDepartmentHistory {

    /// <summary>
    /// 部门员工工作信息业务服务对象
    /// </summary>
    public class EmployeeDepartmentHistoryService:IEmployeeDepartmentHistoryService {
        private readonly IEmployeeDepartmentHistoryRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public EmployeeDepartmentHistoryService(IEmployeeDepartmentHistoryRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public ORG_EmployeeDepartmentHistory GetEmployeeDepartmentHistory(int  ShiftId,int  DepartmentId,int  EmployeeId) {
            var q = m_Repository.Table.Where(p => p.ShiftId == ShiftId && 
                                            p.DepartmentId == DepartmentId && p.EmployeeId == EmployeeId);
            List<ORG_EmployeeDepartmentHistory> list = q.ToList();
            return list.FirstOrDefault();
        }

        public List<ORG_EmployeeDepartmentHistory> GetEmployeeDepartmentHistorys() {
            return m_Repository.Table.ToList();
        }

        public PagedList<ORG_EmployeeDepartmentHistory> GetEmployeeDepartmentHistorys(int pageIndex, int pageSize) {            
            var q = m_Repository.Table.OrderByDescending(p => p.ModifiedDate);
            PagedList<ORG_EmployeeDepartmentHistory> result = q.ToPagedList<ORG_EmployeeDepartmentHistory>(pageIndex, pageSize);
            return result;
        }

        public void InsertEmployeeDepartmentHistory(ORG_EmployeeDepartmentHistory EmployeeDepartmentHistory) {
            if (EmployeeDepartmentHistory == null) throw new ArgumentNullException("部门员工工作信息实体不能为null值");           
            EmployeeDepartmentHistory.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(EmployeeDepartmentHistory);
            m_UnitOfWork.Commint();
        }

        public void UpdateEmployeeDepartmentHistory(ORG_EmployeeDepartmentHistory EmployeeDepartmentHistory) {
            if (EmployeeDepartmentHistory == null) throw new ArgumentNullException("部门员工工作信息实体不能为null值");           
            EmployeeDepartmentHistory.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(EmployeeDepartmentHistory);
            m_UnitOfWork.Commint();
        }

        public void DeleteEmployeeDepartmentHistory(ORG_EmployeeDepartmentHistory EmployeeDepartmentHistory) {
            if (EmployeeDepartmentHistory == null) throw new ArgumentNullException("部门员工工作信息实体不能为null值");            
            EmployeeDepartmentHistory.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(EmployeeDepartmentHistory);
            m_UnitOfWork.Commint();
        }    
    }
}

