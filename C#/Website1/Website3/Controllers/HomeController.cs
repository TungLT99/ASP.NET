using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website3.Class;

namespace Website3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var dSMT = new MayTinh().KhoiTao5May();
            return View(dSMT);
        }

        public ActionResult HienThi2May()
        {
            var dSMT = new MayTinh().KhoiTao5May().OrderBy(m => m.GiaBan).Take(2);

            return View(dSMT);
        }
        public ActionResult GiaTuCaoToiThap()
        {
            var dSMT = new MayTinh().KhoiTao5May().OrderByDescending(m => m.GiaBan);
            return View(dSMT);
        }
        public ActionResult HangDell()
        {
            var dSMT = new MayTinh().KhoiTao5May().Where(m => m.HangSX == "Dell").ToList();
            return View(dSMT);
        }
    }
}