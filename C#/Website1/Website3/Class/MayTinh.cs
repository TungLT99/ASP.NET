using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Website3.Class
{
    public class MayTinh
    {
        public int MaMay { get; set; }
        public string TenMay { get; set; }
        public int GiaBan { get; set; }
        public DateTime NgaySX { get; set; }
        public string HangSX { get; set; }
        public List<MayTinh> KhoiTao5May()
        {
            List<MayTinh> dSMT = new List<MayTinh>();
            MayTinh mt1 = new MayTinh();
            mt1.MaMay = 1111111111;
            mt1.HangSX = "Asus";
            mt1.GiaBan = 5000000;
            mt1.NgaySX = new DateTime(1999, 04, 1);
            mt1.TenMay = "Asus 1151";
            dSMT.Add(mt1);

            MayTinh mt2 = new MayTinh();
            mt2.MaMay = 1111111112;
            mt2.HangSX = "Dell";
            mt2.GiaBan = 7000000;
            mt2.NgaySX = new DateTime(1999, 08, 11);
            mt2.TenMay = "Dell Latitude E6520";
            dSMT.Add(mt2);

            MayTinh mt3 = new MayTinh();
            mt3.MaMay = 1111111113;
            mt3.HangSX = "Asus";
            mt3.GiaBan = 5000000;
            mt3.NgaySX = new DateTime(1999, 10, 7);
            mt3.TenMay = "Asus 1199";
            dSMT.Add(mt3);

            MayTinh mt4 = new MayTinh();
            mt4.MaMay = 1111111111;
            mt4.HangSX = "HP";
            mt4.GiaBan = 6000000;
            mt4.NgaySX = new DateTime(2010, 04, 1);
            mt4.TenMay = "HP 1151";
            dSMT.Add(mt4);

            MayTinh mt5 = new MayTinh();
            mt5.MaMay = 1111111111;
            mt5.HangSX = "Dell";
            mt5.GiaBan = 8000000;
            mt5.NgaySX = new DateTime(2005, 01, 11);
            mt5.TenMay = "Dell Latitude E6110";
            dSMT.Add(mt5);
            return dSMT;
        }
       

    }
}