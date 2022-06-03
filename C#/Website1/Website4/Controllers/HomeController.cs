using System.Linq;
using System.Web.Mvc;
using Website4.Models;

namespace Website4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var dSMT = new MayTinh().KhoiTao5May();
            return View(dSMT);
        }
        public ActionResult GiaCaoToiThap()
        {
            var dSMT = new MayTinh().KhoiTao5May().OrderByDescending(m => m.GiaBan).ToList();
            return View(dSMT);
        }
        public ActionResult BaMayThapNhat()
        { 
            var dSMT = new MayTinh().KhoiTao5May().OrderBy(m => m.GiaBan).Take(3).ToList();
            return View(dSMT);
        }
        public ActionResult ADenZ()
        {
            var dSMT = new MayTinh().KhoiTao5May().OrderBy(m => m.TenDongMay).ToList();
            return View(dSMT);
        }
        public ActionResult CoBaoHanh()
        {
            var dSMT = new MayTinh().KhoiTao5May().Where(m=>m.BHV==true).ToList();
            return View(dSMT);
        }
        public ActionResult Asus()
        {
            var dSMT = new MayTinh().KhoiTao5May().Where(m => m.HangSX == "Asus").ToList();
            return View(dSMT);
        }
        


    }
}