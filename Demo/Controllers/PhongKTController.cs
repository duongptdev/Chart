using Demo.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class PhongKTController : Controller
    {
        // GET: PhongKT
        private ChartEntities db = new ChartEntities();
        // GET: ebh
        public ActionResult Index()
        {
            var model = (from t in db.ChiTietDanhMuc
                         //where t.Ngaytao.Value.Year==DateTime.Now.Year
                         orderby t.Tuan descending
                         select new PhongKeToan
                         {
                             Tuan = t.Tuan,
                             DoanhThuHN = t.DoanhThuHN,
                             DoanhThuCNHCM = t.DoanhThuCNHCM,
                             CongNoHN = t.CongNoHN,
                             CongNoCNHCM = t.CongNoCNHCM
                     
                         }).Take(3).OrderBy(r => r.Tuan).ToList();
            ViewBag.ListPKT = model;
            return View();
        }
    }
}