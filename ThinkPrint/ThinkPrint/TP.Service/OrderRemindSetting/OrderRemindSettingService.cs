using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.OrderRemindSetting {

    /// <summary>
    /// 订单消息设置业务服务对象
    /// </summary>
    public class OrderRemindSettingService:IOrderRemindSettingService {
        private readonly IOrderRemindSettingRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public OrderRemindSettingService(IOrderRemindSettingRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public SYS_OrderRemindSetting GetOrderRemindSetting(int  OrderRemindId) {
            return m_Repository.GetById(OrderRemindId);
        }

        public List<SYS_OrderRemindSetting> GetOrderRemindSettings() {
            return m_Repository.Table.Where(p => p.IsDelete == false).ToList();
        }

        public PagedList<SYS_OrderRemindSetting> GetOrderRemindSettings(int pageIndex, int pageSize) {           
            var q = m_Repository.Table.OrderByDescending(p => p.OrderRemindId);
            PagedList<SYS_OrderRemindSetting> result = q.ToPagedList<SYS_OrderRemindSetting>(pageIndex, pageSize);
            return result;
        }

        public void InsertOrderRemindSetting(SYS_OrderRemindSetting OrderRemindSetting) {
            if (OrderRemindSetting == null) throw new ArgumentNullException("订单消息设置实体不能为null值");
            OrderRemindSetting.IsDelete = false;           
            m_Repository.Add(OrderRemindSetting);
            m_UnitOfWork.Commint();
        }

        public void UpdateOrderRemindSetting(SYS_OrderRemindSetting OrderRemindSetting) {
            if (OrderRemindSetting == null) throw new ArgumentNullException("订单消息设置实体不能为null值");    
            m_Repository.Update(OrderRemindSetting);
            m_UnitOfWork.Commint();
        }

        public void DeleteOrderRemindSetting(SYS_OrderRemindSetting OrderRemindSetting) {
            if (OrderRemindSetting == null) throw new ArgumentNullException("订单消息设置实体不能为null值");
            OrderRemindSetting.IsDelete = true;           
            m_Repository.Update(OrderRemindSetting);
            m_UnitOfWork.Commint();
        }    
    }
}

