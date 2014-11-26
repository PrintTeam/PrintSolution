﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP.Web.Framework.Mvc
{
    public class BaseViewModel
    {
        public virtual int Id { get; set; }

        public virtual string PageTitle { get; set; }
        public virtual string PageSubTitle { get; set; }
        public bool IsEdit { get; set; }
    }
}