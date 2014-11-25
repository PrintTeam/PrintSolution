
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.EntityFramework.Models;
using TP.Repository;
using Webdiyer.WebControls.Mvc;

namespace NSIS.Service.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeService(IEmployeeRepository employeeRepository, IUnitOfWork unitOfWork)
        {
            _employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;

        }
        public IList<ORG_Employee> GetEmployeeList()
        {
            var query = _employeeRepository.Table;
            IList<ORG_Employee> employeeList = query.OrderByDescending(u => u.ModifiedDate).ToList();
            return employeeList;
        }

        public PagedList<ORG_Employee> GetEmployeeList(int pageIndex, int pageSize, string searchKey = null)
        {
            //var query = _employeeRepository.Table;
            //if (!string.IsNullOrWhiteSpace(searchKey))
            //{
            //    query = query.Where(u => u.Name.Contains(searchKey) || u.JobNumber.Contains(searchKey));
            //}

            //query = query.OrderByDescending(u => u.ModifiedDate);
            var query = new List<ORG_Employee>();
            //PagedList<ORG_Employee> employeeList = query.ToPagedList(pageIndex, pageSize);

            PagedList<ORG_Employee> employeeList = new PagedList<ORG_Employee>(query, pageIndex, pageSize);
            return employeeList;
        }

        public ORG_Employee GetEmployeeById(int employeeId)
        {
            return _employeeRepository.GetById(employeeId);
        }

        public ORG_Employee CheckExistEmployeeByCode(int id)
        {
         
            var query = _employeeRepository.Filter(u => u.EmployeeId != id ).FirstOrDefault();
            return query;
        }

        public void InsertEmployee(ORG_Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException("Insert ORG_Employee entity is Null");

            try
            {
                _employeeRepository.Add(employee);
                _unitOfWork.Commint();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateEmployee(ORG_Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException("Update ORG_Employee entity is Null");
            try
            {

                _employeeRepository.Update(employee);
                _unitOfWork.Commint();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteEmployee(ORG_Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException("Update ORG_Employee entity is Null");
            try
            {

                _employeeRepository.Delete(employee);
                _unitOfWork.Commint();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public ORG_Employee CheckExistEmployeeByJobNumber(string jobNumber)
        {
            if (string.IsNullOrWhiteSpace(jobNumber))
                return null;
            var query = _employeeRepository.Filter(u => u.JobNumber == jobNumber).FirstOrDefault();
            return query;
        }

        public ORG_Employee CheckExistEmployeeByJobNumber(int id, string jobNumber)
        {
            if (string.IsNullOrWhiteSpace(jobNumber))
                return null;
            var query = _employeeRepository.Filter(u => u.EmployeeId != id && u.JobNumber == jobNumber).FirstOrDefault();
            return query;
        }
    }
}
