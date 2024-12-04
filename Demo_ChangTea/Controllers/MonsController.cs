using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Demo_ChangTea.Models;

namespace Demo_ChangTea.Controllers
{
    public class MonsController : Controller
    {
        private QL_ChangTeaEntities db = new QL_ChangTeaEntities();
       
        // GET: Mons
        public ActionResult Index()
        {
            return View(db.Mons.ToList());
        }

        // GET: Mons/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mon mon = db.Mons.Find(id);
            if (mon == null)
            {
                return HttpNotFound();
            }
            return View(mon);
        }

        // GET: Mons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Mons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaMon,TenMon,AnhMon,Size,DonVi,DonGia,MoTa")] Mon mon)
        {
            if (ModelState.IsValid)
            {
                db.Mons.Add(mon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mon);
        }

        // GET: Mons/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mon mon = db.Mons.Find(id);
            if (mon == null)
            {
                return HttpNotFound();
            }
            return View(mon);
        }

        // POST: Mons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaMon,TenMon,AnhMon,Size,DonVi,DonGia,MoTa")] Mon mon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mon);
        }

        // GET: Mons/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Mon mon = db.Mons.Find(id);
            if (mon == null)
            {
                return HttpNotFound();
            }
            return View(mon);
        }

        // POST: Mons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Mon mon = db.Mons.Find(id);
            db.Mons.Remove(mon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddToInvoice(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "ID không được để trống");
            }

            var mon = db.Mons.Find(id);
            if (mon == null)
            {
                return HttpNotFound("Không tìm thấy món");
            }

            var invoice = Session["Invoice"] as List<Mon> ?? new List<Mon>();
            invoice.Add(mon);
            Session["Invoice"] = invoice;

            return RedirectToAction("Index");
        }



        public ActionResult Invoice()
        {
            var invoice = Session["Invoice"] as List<Mon> ?? new List<Mon>();
            return View(invoice);
        }

        public ActionResult Checkout()
        {
            var invoice = Session["Invoice"] as List<Mon>;
            if (invoice == null || !invoice.Any())
            {
                return RedirectToAction("Invoice", new { message = "Không có món nào trong hóa đơn để thanh toán." });
            }

            // Thực hiện logic lưu hóa đơn hoặc in biên lai
            // Ví dụ: db.Invoice.Add(new Invoice { Items = invoice });

            Session["Invoice"] = null; // Xóa hóa đơn khỏi session sau khi thanh toán

            return RedirectToAction("InvoiceSuccess");
        }

        public ActionResult InvoiceSuccess()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateHoaDon(HoaDonViewModel model)
        {
            if (ModelState.IsValid)
            {
                var hoaDon = new HoaDon
                {
                    MaHD = model.MaHD,
                    MaDH = model.MaDH,
                    MaKH = model.MaKH,
                    MaNV = model.MaNV,
                    ThoiGianLap = DateTime.Now,
                    GiamGia = model.GiamGia,
                    MaPTTT = model.MaPTTT
                };

                db.HoaDons.Add(hoaDon);
                db.SaveChanges();

                return RedirectToAction("DanhSachHoaDon");
            }
            return View(model);
        }

        public ActionResult DanhSachHoaDon()
        {
            var hoaDons = db.HoaDons
                .Include(hd => hd.KhachHang)
                .Include(hd => hd.NhanVien)
                .Include(hd => hd.PT_ThanhToan)
                .ToList();

            return View(hoaDons);
        }



        public ActionResult RemoveFromInvoice(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "ID không được để trống");
            }

            var invoice = Session["Invoice"] as List<Mon>; // Lấy danh sách hóa đơn từ session
            if (invoice != null)
            {
                var itemToRemove = invoice.FirstOrDefault(m => m.MaMon == id); // Tìm món theo mã món
                if (itemToRemove != null)
                {
                    invoice.Remove(itemToRemove); // Xóa món khỏi danh sách
                    Session["Invoice"] = invoice; // Cập nhật lại session
                }
                else
                {
                    return HttpNotFound("Không tìm thấy món trong hóa đơn");
                }
            }
            else
            {
                return HttpNotFound("Không có hóa đơn trong session");
            }

            return RedirectToAction("Invoice");
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
