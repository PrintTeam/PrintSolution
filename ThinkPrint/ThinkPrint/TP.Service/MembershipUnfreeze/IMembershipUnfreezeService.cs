using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.MembershipUnfreeze {

    public interface IMembershipUnfreezeService {
        CRM_MembershipUnfreeze GetMembershipUnfreeze(int  MembershipUnfreezeId);
        List<CRM_MembershipUnfreeze> GetMembershipUnfreezes();
        PagedList<CRM_MembershipUnfreeze> GetMembershipUnfreezes(int pageIndex, int pageSize, string searchKey = null);
        void InsertMembershipUnfreeze(CRM_MembershipUnfreeze MembershipUnfreeze);
        void UpdateMembershipUnfreeze(CRM_MembershipUnfreeze MembershipUnfreeze);
        void DeleteMembershipUnfreeze(CRM_MembershipUnfreeze MembershipUnfreeze);
    }
}

