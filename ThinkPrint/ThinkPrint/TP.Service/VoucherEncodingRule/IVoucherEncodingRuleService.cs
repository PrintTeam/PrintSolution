using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.VoucherEncodingRule {

    public interface IVoucherEncodingRuleService {
        SYS_VoucherEncodingRule GetVoucherEncodingRule(int  VoucherEncodingRuleId);
        List<SYS_VoucherEncodingRule> GetVoucherEncodingRules();
        PagedList<SYS_VoucherEncodingRule> GetVoucherEncodingRules(int pageIndex, int pageSize, string searchKey = null);
        void InsertVoucherEncodingRule(SYS_VoucherEncodingRule VoucherEncodingRule);
        void UpdateVoucherEncodingRule(SYS_VoucherEncodingRule VoucherEncodingRule);
        void DeleteVoucherEncodingRule(SYS_VoucherEncodingRule VoucherEncodingRule);
    }
}

