using Demo.Models;
using Demo.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class SoSanhController : Controller
    {
        private ChartEntities db = new ChartEntities();
        // GET: SoSanh
        public ActionResult Index(int? tuan)
        {
            ViewBag.tuan=new SelectList(db.ChiTietDanhMuc.OrderByDescending(m =>m.Tuan), "ID", "Tuan");
            if (tuan==null)
            {
                var model = (from c in db.ChiTietDanhMuc
                             orderby c.Tuan descending
                             select new Chitietbaocao
                             {
                                 Tuan=c.Tuan,
                                 TongCapCTS=c.TongCapCTS,
                                 MoKhoa=c.MoKhoa,
                                 E_Invoice=c.E_Invoice,
                                 Co_van=c.Co_van,
                                 EBH=c.EBH,
                                 CKSDoiSoat=c.CKSDoiSoat,
                                 E_invoiceDoiSoat=c.E_invoiceDoiSoat,
                                 EBHDoiSoat=c.EBHDoiSoat,
                                 Co_vanDoiSoat=c.Co_vanDoiSoat,
                                 MoKhoaDoiSoat=c.MoKhoaDoiSoat,
                                 CKSHeThong=c.CKSHeThong,
                                 E_invoiceHeThong=c.E_invoiceHeThong,
                                 Co_vanHeThong=c.E_invoiceHeThong,
                                 MoKhoaHeThong=c.MoKhoaHeThong,
                                 EBHHeThong=c.EBHHeThong
                             }).Take(1);
                ViewBag.ListCTS = model.ToList();
                return View(model);
            }
            else
            {
                var query = (from c in db.ChiTietDanhMuc
                             where c.ID==tuan
                             select new Chitietbaocao
                             {
                                 Tuan = c.Tuan,
                                 TongCapCTS = c.TongCapCTS,
                                 MoKhoa = c.MoKhoa,
                                 E_Invoice = c.E_Invoice,
                                 Co_van = c.Co_van,
                                 EBH = c.EBH,
                                 CKSDoiSoat = c.CKSDoiSoat,
                                 E_invoiceDoiSoat = c.E_invoiceDoiSoat,
                                 EBHDoiSoat = c.EBHDoiSoat,
                                 Co_vanDoiSoat = c.Co_vanDoiSoat,
                                 MoKhoaDoiSoat = c.MoKhoaDoiSoat,
                                 CKSHeThong = c.CKSHeThong,
                                 E_invoiceHeThong = c.E_invoiceHeThong,
                                 Co_vanHeThong = c.E_invoiceHeThong,
                                 MoKhoaHeThong = c.MoKhoaHeThong,
                                 EBHHeThong = c.EBHHeThong                                
                             }).Take(1);
                
                Session["data"] = query.ToList();
                return View(query);
            }
           
        }
    }
}