using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.PrepaymentsSetting {

    /// <summary>
    /// 预收款设置信息业务服务对象
    /// </summary>
    public class PrepaymentsSettingService : IPrepaymentsSettingService {
        private readonly IPrepaymentsSettingRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public PrepaymentsSettingService(IPrepaymentsSettingRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public SYS_PrepaymentsSetting GetPrepaymentsSetting(int PrepaymentsSettingId) {
            return m_Repository.GetById(PrepaymentsSettingId);
        }

        public List<SYS_PrepaymentsSetting> GetPrepaymentsSettings() {
            return m_Repository.Table.Where(p => p.IsDelete == false).ToList();
        }

        public PagedList<SYS_PrepaymentsSetting> GetPrepaymentsSettings(int pageIndex, int pageSize) {
            var q = m_Repository.Table.Where(u => u.IsDelete == false)
                                      .OrderByDescending(p => p.ModifiedDate);
            PagedList<SYS_PrepaymentsSetting> result = q.ToPagedList<SYS_PrepaymentsSetting>(pageIndex, pageSize);
            return result;
        }

        public void InsertPrepaymentsSetting(SYS_PrepaymentsSetting PrepaymentsSetting) {
            if (PrepaymentsSetting == null) throw new ArgumentNullException("预收款设置信息实体不能为null值");
            PrepaymentsSetting.IsDelete = false;
            PrepaymentsSetting.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(PrepaymentsSetting);
            m_UnitOfWork.Commint();
        }

        public void UpdatePrepaymentsSetting(SYS_PrepaymentsSetting PrepaymentsSetting) {
            if (PrepaymentsSetting == null) throw new ArgumentNullException("预收款设置信息实体不能为null值");
            PrepaymentsSetting.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(PrepaymentsSetting);
            m_UnitOfWork.Commint();
        }

        public void DeletePrepaymentsSetting(SYS_PrepaymentsSetting PrepaymentsSetting) {
            if (PrepaymentsSetting == null) throw new ArgumentNullException("预收款设置信息实体不能为null值");
            PrepaymentsSetting.IsDelete = true;
            PrepaymentsSetting.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(PrepaymentsSetting);
            m_UnitOfWork.Commint();
        }
    }
}

