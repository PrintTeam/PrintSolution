using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.Department {

    /// <summary>
    /// 部门信息业务服务对象
    /// </summary>
    public class DepartmentService:IDepartmentService {
        private readonly IDepartmentRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public DepartmentService(IDepartmentRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public ORG_Department GetDepartment(int  DepartmentId) {
            return m_Repository.GetById(DepartmentId);
        }

        public List<ORG_Department> GetDepartments() {
            return m_Repository.Table.Where(p => p.IsDelete == false).ToList();
        }

        public PagedList<ORG_Department> GetDepartments(int pageIndex, int pageSize, string searchKey = null) {
            var q = m_Repository.Table.Where(u => u.IsDelete == false);
            if (!string.IsNullOrWhiteSpace(searchKey)) {
                q = q.Where(p => p.Name.Contains(searchKey));
            }
            q = q.OrderByDescending(p => p.ModifiedDate);
            PagedList<ORG_Department> result = q.ToPagedList<ORG_Department>(pageIndex, pageSize);
            return result;
        }

        public void InsertDepartment(ORG_Department Department) {
            if (Department == null) throw new ArgumentNullException("部门信息实体不能为null值");
            Department.IsDelete = false;
            Department.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(Department);
            m_UnitOfWork.Commint();
        }

        public void UpdateDepartment(ORG_Department Department) {
            if (Department == null) throw new ArgumentNullException("部门信息实体不能为null值");           
            Department.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(Department);
            m_UnitOfWork.Commint();
        }

        public void DeleteDepartment(ORG_Department Department) {
            if (Department == null) throw new ArgumentNullException("部门信息实体不能为null值");
            Department.IsDelete = true;
            Department.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(Department);
            m_UnitOfWork.Commint();
        }    
    }
}

