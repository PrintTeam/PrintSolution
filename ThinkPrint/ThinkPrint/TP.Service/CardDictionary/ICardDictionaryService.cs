using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.CardDictionary {

    public interface ICardDictionaryService {
        CRM_CardDictionary GetCardDictionary(Guid  RowGuid);
        List<CRM_CardDictionary> GetCardDictionarys();
        PagedList<CRM_CardDictionary> GetCardDictionarys(int pageIndex, int pageSize, string searchKey = null);
        void InsertCardDictionary(CRM_CardDictionary CardDictionary);
        void UpdateCardDictionary(CRM_CardDictionary CardDictionary);
        void DeleteCardDictionary(CRM_CardDictionary CardDictionary);
    }
}

