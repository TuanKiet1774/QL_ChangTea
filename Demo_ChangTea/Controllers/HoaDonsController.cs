using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo_ChangTea.Models;

namespace Demo_ChangTea.Controllers
{
    public class HoaDonsController : Controller
    {
        private QL_ChangTeaEntities db = new QL_ChangTeaEntities();

        // GET: HoaDons
        public ActionResult Index()
        {
            var hoaDons = db.HoaDons.Include(h => h.DonHang).Include(h => h.KhachHang).Include(h => h.NhanVien);
            return View(hoaDons.ToList());
        }

        public ActionResult DoanhThu()
        {
            // Gọi stored procedure từ CSDL
            var doanhThu = db.Database.SqlQuery<DoanhThuModel>("EXEC TongDoanhThu").ToList();

            // Trả dữ liệu về View
            return View(doanhThu);
        }

        // GET: HoaDons/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // GET: HoaDons/Create
        public ActionResult Create()
        {
            ViewBag.MaDH = new SelectList(db.DonHangs, "MaDH", "MaKH");
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoKH");
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "HoNV");
            return View();
        }

        // POST: HoaDons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHD,MaDH,MaNV,MaKH,ThoiGianLap,GiamGia")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.HoaDons.Add(hoaDon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDH = new SelectList(db.DonHangs, "MaDH", "MaKH", hoaDon.MaDH);
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoKH", hoaDon.MaKH);
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "HoNV", hoaDon.MaNV);
            return View(hoaDon);
        }

        // GET: HoaDons/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDH = new SelectList(db.DonHangs, "MaDH", "MaKH", hoaDon.MaDH);
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoKH", hoaDon.MaKH);
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "HoNV", hoaDon.MaNV);
            return View(hoaDon);
        }

        // POST: HoaDons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHD,MaDH,MaNV,MaKH,ThoiGianLap,GiamGia")] HoaDon hoaDon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoaDon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDH = new SelectList(db.DonHangs, "MaDH", "MaKH", hoaDon.MaDH);
            ViewBag.MaKH = new SelectList(db.KhachHangs, "MaKH", "HoKH", hoaDon.MaKH);
            ViewBag.MaNV = new SelectList(db.NhanViens, "MaNV", "HoNV", hoaDon.MaNV);
            return View(hoaDon);
        }

        // GET: HoaDons/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return HttpNotFound();
            }
            return View(hoaDon);
        }

        // POST: HoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HoaDon hoaDon = db.HoaDons.Find(id);
            db.HoaDons.Remove(hoaDon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
