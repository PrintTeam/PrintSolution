using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.EntityFramework.Models;
using Webdiyer.WebControls.Mvc;

namespace TP.Service.Paper {

    public interface IPaperService {
        BOM_Paper GetPaper(int  PaperId);
        List<BOMPaper> GetPapers();
        PagedList<BOMPaper> GetPapers(int pageIndex, int pageSize, string searchKey = null);
        void InsertPaper(BOM_Paper Paper);
        void UpdatePaper(BOM_Paper Paper);
        void DeletePaper(BOM_Paper Paper);
    }

    public class BOMPaper {

        public int PaperId {
            get;
            set;
        }
        public int PaperCategoryId {
            get;
            set;
        }

        public String PaperCategory {
            get;
            set;
        }
        public int PaperSizeId {
            get;
            set;
        }
        public String PaperSize {
            get;
            set;
        }
        public string Name {
            get;
            set;
        }
        public string PartsAttributeCode {
            get;
            set;
        }
        public string MnemonicCode {
            get;
            set;
        }
        public decimal Weight {
            get;
            set;
        }      
        public string Description {
            get;
            set;
        }
    }
}

