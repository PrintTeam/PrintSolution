using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.UnitOfWork;
using TP.Repository;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.VoucherEncodingRule {

    /// <summary>
    /// 单据编码规则业务服务对象
    /// </summary>
    public class VoucherEncodingRuleService:IVoucherEncodingRuleService {
        private readonly IVoucherEncodingRuleRepository m_Repository;
        private readonly IUnitOfWork m_UnitOfWork;

        public VoucherEncodingRuleService(IVoucherEncodingRuleRepository repository, IUnitOfWork unitOfWork) {
            m_Repository = repository;
            m_UnitOfWork = unitOfWork;
        }

        public SYS_VoucherEncodingRule GetVoucherEncodingRule(int  VoucherEncodingRuleId) {
            return m_Repository.GetById(VoucherEncodingRuleId);
        }

        public List<SYS_VoucherEncodingRule> GetVoucherEncodingRules() {
            return m_Repository.Table.Where(p => p.IsDelete == false).ToList();
        }

        public PagedList<SYS_VoucherEncodingRule> GetVoucherEncodingRules(int pageIndex, int pageSize, string searchKey = null) {
            var q = m_Repository.Table.Where(u => u.IsDelete == false);
            if (!string.IsNullOrWhiteSpace(searchKey)) {
                q = q.Where(p => p.Name.Contains(searchKey));
            }
            q = q.OrderByDescending(p => p.ModifiedDate);
            PagedList<SYS_VoucherEncodingRule> result = q.ToPagedList<SYS_VoucherEncodingRule>(pageIndex, pageSize);
            return result;
        }

        public void InsertVoucherEncodingRule(SYS_VoucherEncodingRule VoucherEncodingRule) {
            if (VoucherEncodingRule == null) throw new ArgumentNullException("单据编码规则实体不能为null值");
            VoucherEncodingRule.IsDelete = false;
            VoucherEncodingRule.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Add(VoucherEncodingRule);
            m_UnitOfWork.Commint();
        }

        public void UpdateVoucherEncodingRule(SYS_VoucherEncodingRule VoucherEncodingRule) {
            if (VoucherEncodingRule == null) throw new ArgumentNullException("单据编码规则实体不能为null值");           
            VoucherEncodingRule.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(VoucherEncodingRule);
            m_UnitOfWork.Commint();
        }

        public void DeleteVoucherEncodingRule(SYS_VoucherEncodingRule VoucherEncodingRule) {
            if (VoucherEncodingRule == null) throw new ArgumentNullException("单据编码规则实体不能为null值");
            VoucherEncodingRule.IsDelete = true;
            VoucherEncodingRule.ModifiedDate = DateTime.Now.ToLocalTime();
            m_Repository.Update(VoucherEncodingRule);
            m_UnitOfWork.Commint();
        }    
    }
}

