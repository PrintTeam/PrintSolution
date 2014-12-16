using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.MembershipFreeze {

    public interface IMembershipFreezeService {
        CRM_MembershipFreeze GetMembershipFreeze(int  MembershipFreezeId);
        List<CRM_MembershipFreeze> GetMembershipFreezes();
        PagedList<CRM_MembershipFreeze> GetMembershipFreezes(int pageIndex, int pageSize, string searchKey = null);
        void InsertMembershipFreeze(CRM_MembershipFreeze MembershipFreeze);
        void UpdateMembershipFreeze(CRM_MembershipFreeze MembershipFreeze);
        void DeleteMembershipFreeze(CRM_MembershipFreeze MembershipFreeze);
    }
}

