using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.EmployeeDepartmentHistory {

    public interface IEmployeeDepartmentHistoryService {
        ORG_EmployeeDepartmentHistory GetEmployeeDepartmentHistory(int  ShiftId,int  DepartmentId,int  EmployeeId);
        List<ORG_EmployeeDepartmentHistory> GetEmployeeDepartmentHistorys();
        PagedList<ORG_EmployeeDepartmentHistory> GetEmployeeDepartmentHistorys(int pageIndex, int pageSize);
        void InsertEmployeeDepartmentHistory(ORG_EmployeeDepartmentHistory EmployeeDepartmentHistory);
        void UpdateEmployeeDepartmentHistory(ORG_EmployeeDepartmentHistory EmployeeDepartmentHistory);
        void DeleteEmployeeDepartmentHistory(ORG_EmployeeDepartmentHistory EmployeeDepartmentHistory);
    }
}

