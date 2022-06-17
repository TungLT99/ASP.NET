using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website4.Models;

namespace Website4.Controllers
{
    public class HomeSQLController : Controller
    {
        QlyBanHangEntities dbBanHang = new QlyBanHangEntities();
        // GET: HomeSQL
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult HienThiKhachHang()
        {
            List<KhachHang> DSKH = dbBanHang.KhachHangs.ToList();
            return View(DSKH);
        }
        public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(KhachHang model)
        {
            if (dbBanHang.KhachHangs.Find(model.IDKhachHang)!=null)
            {
                return View(model);
            }    
            else
            {
                dbBanHang.KhachHangs.Add(model);
                dbBanHang.SaveChanges();
                return RedirectToAction("HienThiKhachHang");
            }    
        }
        public ActionResult UpdateCustomer(int idKhachHang)
        {
            KhachHang updateKhachHang= dbBanHang.KhachHangs.Find(idKhachHang);
            return View(updateKhachHang);
        }
        [HttpPost]
        public ActionResult UpdateCustomer(int idKhachHang,KhachHang model)
        {
            KhachHang updateKhachHang = dbBanHang.KhachHangs.Find(idKhachHang);
            updateKhachHang.TenKhachHang = model.TenKhachHang;
            updateKhachHang.DiaChiNhanHang = model.DiaChiNhanHang;
            updateKhachHang.SoDienThoai = model.SoDienThoai;
            updateKhachHang.Email = model.Email;
            updateKhachHang.GioiTinh=model.GioiTinh;
            dbBanHang.SaveChanges();
            return RedirectToAction("HienThiKhachHang");
        }
        public ActionResult DeleteCustomer(int idKhachHang)
        {
            KhachHang deleteKhachHang = dbBanHang.KhachHangs.Find(idKhachHang);
            dbBanHang.KhachHangs.Remove(deleteKhachHang);
            dbBanHang.SaveChanges();
            return RedirectToAction("HienThiKhachHang");
        }


        public ActionResult HienThiMayTinh()
        {
            List<MayTinh> DSMT = dbBanHang.MayTinhs.ToList();
            return View(DSMT);
        }
        public ActionResult AddComputer()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddComputer(MayTinh model)
        {
            if (dbBanHang.MayTinhs.Find(model.MaMay) != null)
            {
                ModelState.AddModelError("", "Đã tồn tại mã máy");
                return View(model);
            }
            else
            {
                dbBanHang.MayTinhs.Add(model);
                dbBanHang.SaveChanges();
                return RedirectToAction("HienThiMayTinh");
            }
        }
        public ActionResult UpdateComputer(string maMay)
        {
            MayTinh updateMayTinh = dbBanHang.MayTinhs.Find(maMay);
            return View(updateMayTinh);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateComputer(string maMay, MayTinh model)
        {
            MayTinh updateMayTinh = dbBanHang.MayTinhs.Find(maMay);
            updateMayTinh.TenDongMay=model.TenDongMay;
            updateMayTinh.NgaySX = model.NgaySX;
            updateMayTinh.BHV = model.BHV;
            updateMayTinh.HangSX = model.HangSX;
            dbBanHang.SaveChanges();
            return RedirectToAction("HienThiMayTinh");
        }
        public ActionResult DeleteComputer(string maMay)
        {
            MayTinh deleteComputer = dbBanHang.MayTinhs.Find(maMay);
            dbBanHang.MayTinhs.Remove(deleteComputer);
            dbBanHang.SaveChanges();
            return RedirectToAction("HienThiMayTinh");
        }
        public ActionResult HienThiDonHang()
        {
            List<DonHang> DSDH = new List<DonHang>();
            DSDH = dbBanHang.DonHangs.ToList();
            return View(DSDH);
        }
        public ActionResult AddOrder()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddOrder(DonHang model,int idKhachHang,string idMayTinh)
        {
            dbBanHang.DonHangs.Add(model);
            dbBanHang.SaveChanges();
            ChiTietDonHang chiTiet = new ChiTietDonHang();
            chiTiet.IDKhachHang = idKhachHang;
            chiTiet.IDDonHang = model.IDDonHang;
            chiTiet.MaMay = idMayTinh;
            dbBanHang.ChiTietDonHangs.Add(chiTiet);
            dbBanHang.SaveChanges();
            //dbBanHang.ChiTietDonHangs.Add(chiTiet)
            // var khachHang = dbBanHang.KhachHangs.SingleOrDefault(m => m.IDKhachHang == chiTiet.IDKhachHang);
            return RedirectToAction("HienThiDonHang");


        }
        public ActionResult EditDonHang(int idDonHang)
        {
            var model = dbBanHang.DonHangs.Find(idDonHang);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditDonHang(int idDonHang,KhachHang model)
        {
            var chiTietDonHang = dbBanHang.ChiTietDonHangs.SingleOrDefault(m=>m.IDDonHang==idDonHang);
            var khachHang= dbBanHang.KhachHangs.SingleOrDefault(m=>m.IDKhachHang==chiTietDonHang.IDKhachHang);
            khachHang.TenKhachHang = model.TenKhachHang;
            khachHang.DiaChiNhanHang = model.DiaChiNhanHang;
         //   khachHang.Email = model.Email;
            khachHang.SoDienThoai = model.SoDienThoai;
            dbBanHang.SaveChanges();
            return RedirectToAction("HienThiDonHang");
        }
        public ActionResult DeleteOrder(int idDonHang)
        {
            DonHang deleteOrder = dbBanHang.DonHangs.Find(idDonHang);
            dbBanHang.DonHangs.Remove(deleteOrder);
            dbBanHang.SaveChanges();
            return RedirectToAction("HienThiDonHang");
        }
        public ActionResult DetailOrder(int idDonHang)
        {
            DonHang order = dbBanHang.DonHangs.Find(idDonHang);
            ViewBag.idDonHang = idDonHang;
            return View(order);
        }
        public ActionResult EditComputer(string idMayTinh)
        {
            MayTinh mayTinh = dbBanHang.MayTinhs.Find(idMayTinh);

            return View(mayTinh);
        }
        [HttpPost]
        public ActionResult EditComputer(string idMayTinh,int idDonHang)
        {
            ViewBag.idDonHang = idDonHang;
            ChiTietDonHang chiTiet = dbBanHang.ChiTietDonHangs.SingleOrDefault(m=>m.IDDonHang==idDonHang);
            chiTiet.MaMay = idMayTinh;
            dbBanHang.SaveChanges();
            return RedirectToAction("HienThiDonHang", new { idDonHang = idDonHang });
        }
        public ActionResult AddNewComputer()
        {
            return View();
        }
    }
}