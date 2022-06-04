using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website4.Models
{
    public class KhachHang
    {
        public int ID { get; set; }
        public string TenKhachHang { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChiNhanHang { get; set; }
        public string Email { get; set; }
        public string GioiTinh { get; set; }
    }
}