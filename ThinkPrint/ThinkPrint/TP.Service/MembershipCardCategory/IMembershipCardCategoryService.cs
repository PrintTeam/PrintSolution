using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.MembershipCardCategory {

    public interface IMembershipCardCategoryService {
        CRM_MembershipCardCategory GetMembershipCardCategory(int  MembershipCardCategoryId);
        List<CRM_MembershipCardCategory> GetMembershipCardCategorys();
        PagedList<CRM_MembershipCardCategory> GetMembershipCardCategorys(int pageIndex, int pageSize, string searchKey = null);
        void InsertMembershipCardCategory(CRM_MembershipCardCategory MembershipCardCategory);
        void UpdateMembershipCardCategory(CRM_MembershipCardCategory MembershipCardCategory);
        void DeleteMembershipCardCategory(CRM_MembershipCardCategory MembershipCardCategory);
    }
}

