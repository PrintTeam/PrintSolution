using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.PostRegisterCard {

    public interface IPostRegisterCardService {
        CRM_PostRegisterCard GetPostRegisterCard(int  PostRegisterCardId);
        List<CRM_PostRegisterCard> GetPostRegisterCards();
        PagedList<CRM_PostRegisterCard> GetPostRegisterCards(int pageIndex, int pageSize, string searchKey = null);
        void InsertPostRegisterCard(CRM_PostRegisterCard PostRegisterCard);
        void UpdatePostRegisterCard(CRM_PostRegisterCard PostRegisterCard);
        void DeletePostRegisterCard(CRM_PostRegisterCard PostRegisterCard);
    }
}

