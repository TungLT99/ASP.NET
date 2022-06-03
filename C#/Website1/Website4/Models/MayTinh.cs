using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website4.Models
{
    public class MayTinh
    {
        public string MaMay { get; set; }
        public string TenDongMay { get; set; }
        public double GiaBan { get; set; }
        public DateTime NgaySX { get; set; }
        public string HangSX { get; set; }
        public bool BHV { get; set; }
        public List<MayTinh> KhoiTao5May()
        {
            List<MayTinh> dSMT = new List<MayTinh>();
            MayTinh mt1 = new MayTinh();
            mt1.MaMay = "0000000001";
            mt1.TenDongMay = "Asus Rog 1211";
            mt1.GiaBan = 15000000;
            mt1.NgaySX = new DateTime(2020,04,11);
            mt1.HangSX = "Asus";
            mt1.BHV = true;
            dSMT.Add(mt1);

            MayTinh mt2 = new MayTinh();
            mt2.MaMay = "0000000002";
            mt2.TenDongMay = "Dell Latitude E6520";
            mt2.GiaBan = 9000000;
            mt2.NgaySX = new DateTime(2018,11,15);
            mt2.HangSX = "Dell";
            mt2.BHV = false;
            dSMT.Add(mt2);

            MayTinh mt3 = new MayTinh();
            mt3.MaMay = "0000000003";
            mt3.TenDongMay = "Asus Rog Z590 E-Gaming Wifi";
            mt3.GiaBan = 19000000;
            mt3.NgaySX = new DateTime(2021,01,04);
            mt3.HangSX = "Asus";
            mt3.BHV = true;
            dSMT.Add(mt3);

            MayTinh mt4 = new MayTinh();
            mt4.MaMay = "0000000004";
            mt4.TenDongMay = "Dell 1511";
            mt4.GiaBan = 11000000;
            mt4.NgaySX = new DateTime(2020,02,04);
            mt4.HangSX = "Dell";
            mt4.BHV = true;
            dSMT.Add(mt4);

            MayTinh mt5 = new MayTinh();
            mt5.MaMay = "0000000005";
            mt5.TenDongMay = "Cooller Master MA612 ARGB";
            mt5.GiaBan = 6000000;
            mt5.NgaySX = new DateTime(2020,04,05);
            mt5.HangSX = "Cooller Master";
            mt5.BHV = false;
            dSMT.Add(mt5);
            return (dSMT);
        }
    }
    
}