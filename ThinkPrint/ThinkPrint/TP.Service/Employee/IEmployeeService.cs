
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace NSIS.Service.Employee
{
    public interface IEmployeeService
    {
        /// <summary>
        /// 获取所有的员工信息
        /// </summary>
        /// <returns></returns>
        IList<ORG_Employee> GetEmployeeList();

        /// <summary>
        /// 分页获取员工信息
        /// </summary>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">每页显示数量</param>
        /// <param name="searchKey">可选,名称</param>
        /// <returns>PagedList ORG_Employee</returns>
        PagedList<ORG_Employee> GetEmployeeList(int pageIndex, int pageSize, string searchKey = null);

        /// <summary>
        /// 获取员工信息
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        ORG_Employee GetEmployeeById(int employeeId);

        /// <summary>
        ///  检查员工信息工号唯一性
        /// </summary>
        /// <param name="jobNumber"></param>
        /// <returns></returns>
        ORG_Employee CheckExistEmployeeByJobNumber(string jobNumber);

        /// <summary>
        /// 检查员工信息编码唯一性
        /// </summary>
        /// <param name="id"></param>
        /// <param name="uniqueCode"></param>
        /// <returns>ORG_Employee</returns>
        ORG_Employee CheckExistEmployeeByCode(int id);

        /// <summary>
        /// 检查员工信息工号唯一性
        /// </summary>
        /// <param name="id"></param>
        /// <param name="jobNumber"></param>
        /// <returns></returns>
        ORG_Employee CheckExistEmployeeByJobNumber(int id, string jobNumber);

        /// <summary>
        /// 添加员工信息
        /// </summary>
        /// <param name="employee">ORG_Employee</param>
        void InsertEmployee(ORG_Employee employee);

        /// <summary>
        /// 编辑员工信息
        /// </summary>
        /// <param name="employee">ORG_Employee</param>
        void UpdateEmployee(ORG_Employee employee);

        /// <summary>
        /// 删除员工信息
        /// </summary>
        /// <param name="employee"></param>
        void DeleteEmployee(ORG_Employee employee);
    }
}
