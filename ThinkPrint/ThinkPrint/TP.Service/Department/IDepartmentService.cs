using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.Department {

    public interface IDepartmentService {
        ORG_Department GetDepartment(int  DepartmentId);
        List<ORG_Department> GetDepartments();
        PagedList<ORG_Department> GetDepartments(int pageIndex, int pageSize, string searchKey = null);
        void InsertDepartment(ORG_Department Department);
        void UpdateDepartment(ORG_Department Department);
        void DeleteDepartment(ORG_Department Department);
    }
}

