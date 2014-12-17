using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.Order {

    /// <summary>
    /// 订单信息业务服务对象
    /// </summary>
    public class OrderService:IOrderService {
        private readonly IOrderRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public OrderService(IOrderRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public SAL_Order GetOrder(int  OrderId) {
            return m_Repository.GetById(OrderId);
        }

        public List<SAL_Order> GetOrders() {
            return m_Repository.Table.ToList();
        }

        public PagedList<SAL_Order> GetOrders(int pageIndex, int pageSize, string searchKey = null) {
            var q = m_Repository.Table;
            if (!string.IsNullOrWhiteSpace(searchKey)) {
                q = q.Where(p => p.CustomerName.Contains(searchKey));
            }
            q = q.OrderByDescending(p => p.ModifiedDate);
            PagedList<SAL_Order> result = q.ToPagedList<SAL_Order>(pageIndex, pageSize);
            return result;
        }

        public void InsertOrder(SAL_Order Order) {
            if (Order == null) throw new ArgumentNullException("订单信息实体不能为null值");           
            Order.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(Order);
            m_UnitOfWork.Commint();
        }

        public void UpdateOrder(SAL_Order Order) {
            if (Order == null) throw new ArgumentNullException("订单信息实体不能为null值");           
            Order.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(Order);
            m_UnitOfWork.Commint();
        }

        public void DeleteOrder(SAL_Order Order) {
            if (Order == null) throw new ArgumentNullException("订单信息实体不能为null值");           
            Order.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(Order);
            m_UnitOfWork.Commint();
        }    
    }
}

