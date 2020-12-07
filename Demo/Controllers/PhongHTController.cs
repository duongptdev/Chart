using Demo.Models;
using Demo.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class PhongHTController : Controller
    {
        // GET: PhongHT
        private ChartEntities db = new ChartEntities();
        // GET: ebh
        public ActionResult Index()
        {
            var model = (from t in db.ChiTietDanhMuc
                         //where t.Ngaytao.Value.Year==DateTime.Now.Year
                         orderby t.Tuan descending
                         select new PhongHoTro
                         {                           
                             Tuan = t.Tuan,
                             TongHT=t.TongHT,
                             CBCNHT=t.CBCNHT,
                             CBTNHT=t.CBTNHT,
                             ThueHT=t.ThueHT,
                             HoaDonHT=t.HoaDonHT,
                             Co_VanHT=t.Co_VanHT,
                             HaiQuanHT=t.HaiQuanHT,
                             EBHHT=t.EBHHT,
                             GDKHT=t.GDKHT
                         }).Take(3).OrderBy(r => r.Tuan).ToList();
            ViewBag.Listnhapht = model;
            return View();
        }
    }
}