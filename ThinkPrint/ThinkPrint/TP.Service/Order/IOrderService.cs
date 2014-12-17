using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.Order {

    public interface IOrderService {
        SAL_Order GetOrder(int  OrderId);
        List<SAL_Order> GetOrders();
        PagedList<SAL_Order> GetOrders(int pageIndex, int pageSize, string searchKey = null);
        void InsertOrder(SAL_Order Order);
        void UpdateOrder(SAL_Order Order);
        void DeleteOrder(SAL_Order Order);
    }
}

