﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BTLPMQL.Models;

namespace BTLPMQL.Controllers
{
    public class DonHangsController : Controller
    {
        private QLShopDbContext db = new QLShopDbContext();

        // GET: DonHangs
        public ActionResult Index()
        {
            return View(db.HoaDons.ToList());
        }

        // GET: DonHangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon donHang = db.HoaDons.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            return View(donHang);
        }

        // GET: DonHangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DonHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDonHang,TenSanPham,Gia,ThoiGianMuaHang,TongThanhToan")] HoaDon donHang)
        {
            if (ModelState.IsValid)
            {
                db.HoaDons.Add(donHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(donHang);
        }

        // GET: DonHangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon donHang = db.HoaDons.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            return View(donHang);
        }

        // POST: DonHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDonHang,TenSanPham,Gia,ThoiGianMuaHang,TongThanhToan")] HoaDon donHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(donHang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(donHang);
        }

        // GET: DonHangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoaDon donHang = db.HoaDons.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            return View(donHang);
        }

        // POST: DonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoaDon donHang = db.HoaDons.Find(id);
            db.HoaDons.Remove(donHang);
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
