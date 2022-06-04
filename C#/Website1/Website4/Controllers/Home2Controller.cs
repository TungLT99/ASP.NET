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

            //DanhSachMayTinh.listMayTinh.Add(new MayTinh()
            //{
            //    MaMay = "1515151515",
            //    TenDongMay = "Cooller Master MWE 750 Brozen",
            //    NgaySX = new DateTime(2021, 11, 05),
            //    BHV = true,
            //    GiaBan = 15000000,
            //    HangSX = "Cooler Master"


            //});
            var dSMT = DanhSachMayTinh.listMayTinh;
           
           
            return View(dSMT);
        }
        public ActionResult AddNew()
        {
            return View();
        }
        public ActionResult SaveNew(string maMay,string tenDongMay, double giaBan,DateTime ngaySanXuat,string hangSanXuat)
        {
            //xử lý lưu
            DanhSachMayTinh.listMayTinh.Add(new MayTinh()
            {
                MaMay = maMay,
                TenDongMay = tenDongMay,
                NgaySX = ngaySanXuat,
                BHV = true,
                GiaBan = giaBan,
                HangSX = hangSanXuat
            });
            return RedirectToAction("Index");

        }
        public ActionResult GiaCaoToiThap()
        {
            DanhSachMayTinh.listMayTinh.OrderByDescending(m=>m.GiaBan);
            return View(DanhSachMayTinh.listMayTinh);
        }
        public ActionResult Asus2()
        {
            DanhSachMayTinh.listMayTinh.Where(m => m.HangSX == "Asus");
            return View(DanhSachMayTinh.listMayTinh);
        }
        public ActionResult AddNew2()
        {
            return View();
        }
        public ActionResult SaveNew2(MayTinh mayTinh)
        {
            //xử lý lưu
            DanhSachMayTinh.listMayTinh.Add(new MayTinh()
            {
                MaMay = mayTinh.MaMay,
                TenDongMay = mayTinh.TenDongMay,
                NgaySX = mayTinh.NgaySX,
                BHV = mayTinh.BHV,
                GiaBan = mayTinh.GiaBan,
                HangSX = mayTinh.HangSX
            });
            //Cách lưu 2
            //DanhSachMayTinh.listMayTinh.Add(mayTinh);

            return RedirectToAction("Index");
        }
        public ActionResult HienThiKhachHang()
        {
            return View(DanhSachKhachHang.dSKhachHang);
        }
        public ActionResult AddNewKhachHang()
        {
            return View();
        }
        public ActionResult SaveNewKhachHang(KhachHang khachHang)
        {
            DanhSachKhachHang.dSKhachHang.Add(khachHang);
            return RedirectToAction("HienThiKhachHang");
        }

    }
}