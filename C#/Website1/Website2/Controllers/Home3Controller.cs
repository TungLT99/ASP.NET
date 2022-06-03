using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website2.Class;

namespace Website2.Controllers
{
    public class Home3Controller : Controller
    {
        // GET: Home3
        public ActionResult Index()
        {
            Math2 math = new Math2();
            ViewBag.tong= math.TinhTong(5, 9);
            ViewBag.tich = math.TinhTich(5, 9);
            ViewBag.hieu = math.TinhHieu(5, 9);
            ViewBag.thuong = math.TinhThuong(5,9);
            return View();
        }
    }
}