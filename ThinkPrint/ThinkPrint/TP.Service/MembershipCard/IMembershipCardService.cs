using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.MembershipCard {

    public interface IMembershipCardService {
        CRM_MembershipCard GetMembershipCard(int  MembershipCardId);
        List<CRM_MembershipCard> GetMembershipCards();
        PagedList<CRM_MembershipCard> GetMembershipCards(int pageIndex, int pageSize, string searchKey = null);
        void InsertMembershipCard(CRM_MembershipCard MembershipCard);
        void UpdateMembershipCard(CRM_MembershipCard MembershipCard);
        void DeleteMembershipCard(CRM_MembershipCard MembershipCard);
    }
}

