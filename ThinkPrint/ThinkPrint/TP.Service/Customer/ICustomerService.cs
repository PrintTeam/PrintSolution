using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.Customer {

    public interface ICustomerService {
        SAL_Customer GetCustomer(int  CustomerId);
        SAL_Customer GetCustomer(String UniqueCode);
        List<SAL_Customer> GetCustomers();
        PagedList<SAL_Customer> GetCustomers(int pageIndex, int pageSize, string searchKey = null);
        void InsertCustomer(SAL_Customer Customer);
        void UpdateCustomer(SAL_Customer Customer);
        void DeleteCustomer(SAL_Customer Customer);
    }    
}

