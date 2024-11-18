using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proyecto._2.Models;

namespace Proyecto._2.Controllers
{
    public class HistorialCalculosController : Controller
    {
        private Model1 db = new Model1();

        // GET: HistorialCalculos
        public ActionResult Index()
        {
            return View(db.HistorialCalculos.ToList());
        }

        // GET: HistorialCalculos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistorialCalculos historialCalculos = db.HistorialCalculos.Find(id);
            if (historialCalculos == null)
            {
                return HttpNotFound();
            }
            return View(historialCalculos);
        }

        // GET: HistorialCalculos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HistorialCalculos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Operacion,Resultado,FechaRegistro,HoraRegistro")] HistorialCalculos historialCalculos)
        {
            if (ModelState.IsValid)
            {
                db.HistorialCalculos.Add(historialCalculos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(historialCalculos);
        }

        // GET: HistorialCalculos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistorialCalculos historialCalculos = db.HistorialCalculos.Find(id);
            if (historialCalculos == null)
            {
                return HttpNotFound();
            }
            return View(historialCalculos);
        }

        // POST: HistorialCalculos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Operacion,Resultado,FechaRegistro,HoraRegistro")] HistorialCalculos historialCalculos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historialCalculos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(historialCalculos);
        }

        // GET: HistorialCalculos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HistorialCalculos historialCalculos = db.HistorialCalculos.Find(id);
            if (historialCalculos == null)
            {
                return HttpNotFound();
            }
            return View(historialCalculos);
        }

        // POST: HistorialCalculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HistorialCalculos historialCalculos = db.HistorialCalculos.Find(id);
            db.HistorialCalculos.Remove(historialCalculos);
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
