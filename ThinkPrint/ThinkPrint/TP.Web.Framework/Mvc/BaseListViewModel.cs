using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webdiyer.WebControls.Mvc;

namespace TP.Web.Framework.Mvc
{
    public class BaseListViewModel<T> where T : class
    {
        public virtual string PageTitle { get; set; }

        public virtual string PageSubTitle { get; set; }

        public virtual PagedList<T> ViewList { get; set; }
        public virtual string searchKey { get; set; }


    }
}