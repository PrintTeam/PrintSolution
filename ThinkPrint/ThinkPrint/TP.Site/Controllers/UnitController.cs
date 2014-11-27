using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.Web.Framework.Mvc;

namespace TP.Site.Controllers {
    public class UnitController : BaseController {
        // GET: Unit
        public ActionResult Index() {
            return View();
        }
        public ActionResult Create() {
            return View();
        }

        public ActionResult Edit(int id) {
            return View();
        }
        public ActionResult Delete(int id) {
            return View();
        }
    }
}