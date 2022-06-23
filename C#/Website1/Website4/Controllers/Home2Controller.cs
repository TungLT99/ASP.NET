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
            var dsMT = DanhSachMayTinh.listMayTinh;
            dsMT.OrderByDescending(m=>m.GiaBan);
            return View(dsMT);
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
        [HttpPost]
        public ActionResult AddNewKhachHang(KhachHang khachHang,HttpPostedFileBase fileAnh)
        {
            if (khachHang.TenKhachHang == null)
            {
                ModelState.AddModelError("","Mời Bạn Nhập tên");
                return View(khachHang);
            }  
            if (fileAnh.ContentLength>0)
            {
                //Xử lý file ảnh
                string rootFolder = Server.MapPath("/Data/");
                string pathImage = rootFolder + fileAnh.FileName; // Lấy Url ảnh
                fileAnh.SaveAs(pathImage); // Lưu ảnh
                khachHang.UrlHinhAnh = "/Data/"+fileAnh.FileName; // Lưu thuộc tính đối tượng 
            }    
           
                DanhSachKhachHang.dSKhachHang.Add(khachHang);
                return RedirectToAction("HienThiKhachHang");        
        }
        public ActionResult UpdateKhachHang (int IDKhachHang)
        {
            var khachHang= DanhSachKhachHang.dSKhachHang.SingleOrDefault(m => m.IDKH == IDKhachHang);
            return View(khachHang);
        }
        [HttpPost]
        public ActionResult UpdateKhachHang(KhachHang model)
        {
            // Xử lý lưu và update dữ liệu
            var khachHang = DanhSachKhachHang.dSKhachHang.SingleOrDefault(m => m.IDKH == model.IDKH);
            khachHang.TenKhachHang=model.TenKhachHang;
            khachHang.DiaChiNhanHang=model.DiaChiNhanHang;
            khachHang.SoDienThoai=model.SoDienThoai;
            khachHang.Email=model.Email;
            khachHang.GioiTinh = model.GioiTinh;
            //return View(khachHang);
            return RedirectToAction("HienThiKhachHang");
        }
        public ActionResult DeleteKhachHang(int IDKhachHang)
        {
            var khachHang = DanhSachKhachHang.dSKhachHang.SingleOrDefault(m => m.IDKH == IDKhachHang);
            DanhSachKhachHang.dSKhachHang.Remove(khachHang);
            return RedirectToAction("HienThiKhachHang");
        }
        public ActionResult HienThiHoaDon()
        {
            return View(DanhSachDonHang.listDonHang);
        }
        public ActionResult AddDonHang()
        {
            return View();
        }
        public ActionResult SaveDonHang(DonHang donHang)
        {
            DanhSachDonHang.listDonHang.Add(donHang);
            return RedirectToAction("HienThiHoaDon");
        }
        public ActionResult UpdateDonHang(int idDonHang)
        {
            var donHang=DanhSachDonHang.listDonHang.SingleOrDefault(m => m.ID == idDonHang);
            return View(donHang);
        }
        [HttpPost]
        public ActionResult UpdateDonHang(DonHang donHang)
        {
            var model = DanhSachDonHang.listDonHang.SingleOrDefault(m => m.ID == donHang.ID);
            model.NgayDatHang = donHang.NgayDatHang;
            model.DiaChiGiaoHang=donHang.DiaChiGiaoHang;
            model.TenKhachHang = donHang.TenKhachHang;
            model.SDT = donHang.SDT;
            return RedirectToAction("HienThiHoaDon");
        }
        public ActionResult DeleteDonHang(int ID)
        {
            var donHang = DanhSachDonHang.listDonHang.SingleOrDefault(m => m.ID == ID);
            DanhSachDonHang.listDonHang.Remove(donHang);
            return RedirectToAction("HienThiHoaDon");
        }
        public ActionResult DetailDonHang(int idDonHang)
        {
            var donHang = DanhSachDonHang.listDonHang.SingleOrDefault(m => m.ID == idDonHang);
            return View(donHang);
        }
        public ActionResult AddMayTinh(int idDonHang)
        {
            MayTinh maytinh = new MayTinh();
            var donHang = DanhSachDonHang.listDonHang.SingleOrDefault(m => m.ID == idDonHang);
            ViewBag.idDonHang = idDonHang;
            return View(maytinh);
        }
        [HttpPost]
        public ActionResult AddMayTinh(int idDonHang,MayTinh mayTinh)
        {
            var donHang = DanhSachDonHang.listDonHang.SingleOrDefault(m => m.ID == idDonHang);
            donHang.DSMayTinh.Add(mayTinh);
            return RedirectToAction("DetailDonHang",new {idDonHang=idDonHang});
        }
        public ActionResult EditMayTinh(int idDonHang,string maMayTinh)
        {
            var donHang = DanhSachDonHang.listDonHang.SingleOrDefault(m => m.ID == idDonHang);
            ViewBag.idDonHang = idDonHang;
            var mayTinh = donHang.DSMayTinh.SingleOrDefault(m=>m.MaMay==maMayTinh);
            return View(mayTinh);
        }
        [HttpPost]
        public ActionResult EditMayTinh(int idDonHang, MayTinh mayTinh)
        {
            var donHang = DanhSachDonHang.listDonHang.SingleOrDefault(m => m.ID == idDonHang);
            ViewBag.idDonHang = idDonHang;
            var mayTinhUpdate = donHang.DSMayTinh.SingleOrDefault(m => m.MaMay == mayTinh.MaMay);
            mayTinhUpdate.HangSX = mayTinh.HangSX;
            mayTinhUpdate.BHV = mayTinh.BHV;
            mayTinhUpdate.GiaBan=mayTinh.GiaBan;
            mayTinhUpdate.TenDongMay = mayTinh.TenDongMay;
            return RedirectToAction("DetailDonHang", new { idDonHang = idDonHang });
        }
        public ActionResult DeleteMayTinh(int idDonHang,string maMayTinh)
        {
            var donHang = DanhSachDonHang.listDonHang.SingleOrDefault(m => m.ID == idDonHang);
            ViewBag.idDonHang = idDonHang;
            var mayTinh = donHang.DSMayTinh.SingleOrDefault(m => m.MaMay == maMayTinh);
            donHang.DSMayTinh.Remove(mayTinh);
            return RedirectToAction("DetailDonHang", new { idDonHang = idDonHang });
        }

    }
}