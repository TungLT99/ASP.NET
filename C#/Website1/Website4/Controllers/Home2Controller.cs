using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website4.Models;

namespace Website4.Controllers
{
    public class Home2Controller : Controller
    {
        public ActionResult Index()
        {

            DanhSachMayTinh.listMayTinh.Add(new MayTinh()
            {
                MaMay = "1515151515",
                TenDongMay = "Cooller Master MWE 750 Brozen",
                NgaySX = new DateTime(2021, 11, 05),
                BHV = true,
                GiaBan = 15000000,
                HangSX = "Cooler Master"


            });
            var dSMT = DanhSachMayTinh.listMayTinh;
           
            //MayTinh mt1 = new MayTinh();
            //mt1.MaMay = "1515151515";
            //mt1.TenDongMay = "Cooller Master MWE 750 Brozen";
            //mt1.NgaySX = new DateTime(2021, 11, 05);
            //mt1.BHV = true;
            //mt1.GiaBan = 15000000;
            //mt1.HangSX = "Cooller Master";
            //dSMT.Add(mt1);
            return View(dSMT);
        }
    }
}