using Demo.Models;
using Demo.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Microsoft.Office.Interop;
using System.Data.OleDb;
using System.Data;
using LinqToExcel;
using System.Data.Entity.Validation;


namespace Demo.Controllers
{
    public class DataController : Controller
    {
        private ChartEntities db = new ChartEntities();
        // GET: Data
        public ActionResult Index(int? page,int? toweek,int? fromweek)
        {
            ViewBag.Toweek =toweek ;

            ViewBag.Fomweek =fromweek;
            if (toweek == null && fromweek == null || toweek == null || fromweek == null)
            {
                if (page == null) page = 1;
                var data = from l in db.ChiTietDanhMuc                      
                           select l;
                var model = data.OrderByDescending(m => m.Tuan);
                int pageSize = 5;
                int pageNumber = (page ?? 1);
                return View(model.ToPagedList(pageNumber, pageSize));
            }else
            {
                if (page == null) page = 1;
                var data = from l in db.ChiTietDanhMuc
                            where l.Tuan >= toweek && l.Tuan <=fromweek
                           select l;
                var model = data.OrderByDescending(m => m.Tuan);
                int pageSize = 5;
                int pageNumber = (page ?? 1);
                return View(model.ToPagedList(pageNumber, pageSize));
            }
         
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            ChiTietDanhMuc ctdm = db.ChiTietDanhMuc.Find(id);
            if (ctdm == null)
            {
                return HttpNotFound();
            }
          
            return View(ctdm);
        }
        [HttpPost]
        public ActionResult Edit(ChiTietDanhMuc ctdm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ctdm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ctdm);

        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
 
        public ActionResult Create(ChiTietDanhMuc ctdm)
        {
            ctdm.Ngaytao = DateTime.Now;
            ctdm.KTTTTD = ctdm.KDHN + ctdm.KDTPHCM + ctdm.NhomCO + ctdm.NhomHD;
                db.ChiTietDanhMuc.Add(ctdm);
                db.SaveChanges();
                return RedirectToAction("Index");
           
        }
        public ActionResult Delete(int? id)
        {
            ChiTietDanhMuc ctdm = db.ChiTietDanhMuc.Find(id);
            db.ChiTietDanhMuc.Remove(ctdm);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
      

    }
}