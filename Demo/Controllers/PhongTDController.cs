using Demo.Models;
using Demo.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class PhongTDController : Controller
    {
        // GET: PhongTD
        private ChartEntities db = new ChartEntities();
        // GET: ebh
        public ActionResult Index(int? toweek,int? fromweek)
        {
            ViewBag.toweek = new SelectList(db.ChiTietDanhMuc/*.Where(m =>m.Ngaytao.Value.Year==DateTime.Now.Year)*/, "ID", "Tuan");
            ViewBag.fromweek = new SelectList(db.ChiTietDanhMuc/*.Where(m => m.Ngaytao.Value.Year == DateTime.Now.Year)*/, "ID", "Tuan");
            if (toweek==null && fromweek==null)
            {
      
                var model = (from t in db.ChiTietDanhMuc
                             //where t.Ngaytao.Value.Year==DateTime.Now.Year
                             orderby t.Tuan descending
                             select new TongCTS
                             {
                                 Tong = t.TongCapCTS,
                                 CapMoi = t.CapMoi,
                                 GiaHan = t.GiaHan,
                                 CapLai = t.CapLai,
                                 CapLoi = t.CapLoi,
                                 ThuHoi = t.ThuHoi,
                                 CapBu = t.CapBu,
                                 NgoaiGiao = t.NgoaiGiao,
                                 DungThu = t.DungThu,
                                 MoKhoa = t.MoKhoa,
                                 KhoiPhuc = t.KhoiPhuc,
                                 TamDung = t.TamDung,
                                 Tuan = t.Tuan,
                                 CNHCM = t.CNTPCM,
                                 KDTT = t.KTTTTD,
                                 NhomCO = t.NhomCO,
                                 Einvoicetong = t.E_Invoice,
                                 KDHNEinvoice = t.KDHNeinvoice,
                                 NhomHDEinvoice = t.NhomHDeinvoice,
                                 TPHCMEinvoice = t.TPHCM,
                                 Covantong = t.Co_van,
                                 EBHtong = t.EBH,
                                 Nhaphstong = t.NhapHS,
                                 CPNtong = t.CPN,
                                 KDHN = t.KDHN,
                                 KDHCM = t.KDTPHCM,
                                 NhomHD = t.NhomHD
                             }).Take(3).OrderBy(r => r.Tuan);
                #region
      
                ViewBag.ListCTS = model.ToList();
                #endregion
                return View(model);
            }
            else if (toweek != null && fromweek == null)
            {
                var query = from t in db.ChiTietDanhMuc
                            where t.ID == toweek /*&& t.Ngaytao.Value.Year==DateTime.Now.Year*/
                            orderby t.Tuan
                            select t;
                var model = query.ToList();
                Session["baocao"] = model;
                return View(model);
            }
            else if (toweek == null && fromweek != null)
            {
                var query = from t in db.ChiTietDanhMuc
                            where t.ID == fromweek/* && t.Ngaytao.Value.Year == DateTime.Now.Year*/
                            orderby t.Tuan
                            select t;
                var model = query.ToList();
                Session["baocao"] = model;
                return View(model);

            }
            else
            {
                var query = from t in db.ChiTietDanhMuc
                            where t.ID >= toweek && t.ID <= fromweek /*&& t.Ngaytao.Value.Year == DateTime.Now.Year*/
                            orderby t.Tuan
                            select t;
                var model = query.ToList();
                Session["baocao"] = model;
                return View(model);
            }
        }
        public ActionResult Einvoice()
        {

            var model = (from t in db.ChiTietDanhMuc
                         //where t.Ngaytao.Value.Year==DateTime.Now.Year
                         orderby t.Tuan descending
                         select new TongCTS
                         {
                             Tong = t.TongCapCTS,
                             CapMoi = t.CapMoi,
                             GiaHan = t.GiaHan,
                             CapLai = t.CapLai,
                             CapLoi = t.CapLoi,
                             ThuHoi = t.ThuHoi,
                             CapBu = t.CapBu,
                             NgoaiGiao = t.NgoaiGiao,
                             DungThu = t.DungThu,
                             MoKhoa = t.MoKhoa,
                             KhoiPhuc = t.KhoiPhuc,
                             TamDung = t.TamDung,
                             Tuan = t.Tuan,
                             CNHCM = t.CNTPCM,
                             KDTT = t.KTTTTD,
                             NhomCO = t.NhomCO,
                             Einvoicetong = t.E_Invoice,
                             KDHNEinvoice = t.KDHNeinvoice,
                             NhomHDEinvoice = t.NhomHDeinvoice,
                             TPHCMEinvoice = t.TPHCM,
                             Covantong = t.Co_van,
                             EBHtong = t.EBH,
                             Nhaphstong = t.NhapHS,
                             CPNtong = t.CPN,
                             KDHN = t.KDHN,
                             KDHCM = t.KDTPHCM,
                             NhomHD = t.NhomHD
                         }).Take(3).OrderBy(r => r.Tuan);
            #region

            ViewBag.ListCTS = model.ToList();
            #endregion
            return View(model);
        }
        public ActionResult Nhaphs()
        {

            var model = (from t in db.ChiTietDanhMuc
                         //where t.Ngaytao.Value.Year == DateTime.Now.Year
                         orderby t.Tuan descending
                         select new TongCTS
                         {
                             Tong = t.TongCapCTS,
                             CapMoi = t.CapMoi,
                             GiaHan = t.GiaHan,
                             CapLai = t.CapLai,
                             CapLoi = t.CapLoi,
                             ThuHoi = t.ThuHoi,
                             CapBu = t.CapBu,
                             NgoaiGiao = t.NgoaiGiao,
                             DungThu = t.DungThu,
                             MoKhoa = t.MoKhoa,
                             KhoiPhuc = t.KhoiPhuc,
                             TamDung = t.TamDung,
                             Tuan = t.Tuan,
                             CNHCM = t.CNTPCM,
                             KDTT = t.KTTTTD,
                             NhomCO = t.NhomCO,
                             Einvoicetong = t.E_Invoice,
                             KDHNEinvoice = t.KDHNeinvoice,
                             NhomHDEinvoice = t.NhomHDeinvoice,
                             TPHCMEinvoice = t.TPHCM,
                             Covantong = t.Co_van,
                             EBHtong = t.EBH,
                             Nhaphstong = t.NhapHS,
                             CPNtong = t.CPN,
                             KDHN = t.KDHN,
                             KDHCM = t.KDTPHCM,
                             NhomHD = t.NhomHD
                         }).Take(3).OrderBy(r => r.Tuan);
            #region

            ViewBag.ListCTS = model.ToList();
            #endregion
            return View(model);
        }
        public ActionResult Menu()
        {
            return PartialView("_Menu");
        }

    }
}