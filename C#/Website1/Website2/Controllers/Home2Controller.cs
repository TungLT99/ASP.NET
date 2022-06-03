using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website2.Class;

namespace Website2.Controllers
{
    public class Home2Controller : Controller
    {

        public ActionResult Index()
        {
            var sv = new List<SinhVien>();

            SinhVien sv1 = new SinhVien();
            sv1.ID = 1;
            sv1.Hovaten = "Nguyễn Văn A";
            sv1.GioiTinh = true;
            sv1.Lop = "Lớp 11A1";
            sv.Add(sv1);

            SinhVien sv2 = new SinhVien();
            sv2.ID = 2;
            sv2.Hovaten = "Trần Thị B";
            sv2.GioiTinh = false;
            sv2.Lop = "Lớp 11A2";
            sv.Add(sv2);

            return View(sv);
        }

    }
}