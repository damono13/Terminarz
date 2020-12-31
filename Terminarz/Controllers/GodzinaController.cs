using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Terminarz.Models;

namespace Terminarz.Controllers
{
    public class GodzinaController : Controller
    {
        private TerminarzContext db = new TerminarzContext();

        // GET: Godzina
        public ActionResult Index()
        {
            var godziny = db.Godziny.Include(g => g.DzienTygodnia);
            return View(godziny.ToList());
        }

        // GET: Godzina/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Godzina godzina = db.Godziny.Find(id);
            if (godzina == null)
            {
                return HttpNotFound();
            }
            return View(godzina);
        }

        // GET: Godzina/Create
        public ActionResult Create()
        {
            ViewBag.DzienTygodniaId = new SelectList(db.DniTygodnia, "DzienTygodniaId", "Dzien");
            return View();
        }

        // POST: Godzina/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GodzinaId,GodzinaWizyty,DzienTygodniaId")] Godzina godzina)
        {
            if (ModelState.IsValid)
            {
                db.Godziny.Add(godzina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DzienTygodniaId = new SelectList(db.DniTygodnia, "DzienTygodniaId", "Dzien", godzina.DzienTygodniaId);
            return View(godzina);
        }

        // GET: Godzina/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Godzina godzina = db.Godziny.Find(id);
            if (godzina == null)
            {
                return HttpNotFound();
            }
            ViewBag.DzienTygodniaId = new SelectList(db.DniTygodnia, "DzienTygodniaId", "Dzien", godzina.DzienTygodniaId);
            return View(godzina);
        }

        // POST: Godzina/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GodzinaId,GodzinaWizyty,DzienTygodniaId")] Godzina godzina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(godzina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DzienTygodniaId = new SelectList(db.DniTygodnia, "DzienTygodniaId", "Dzien", godzina.DzienTygodniaId);
            return View(godzina);
        }

        // GET: Godzina/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Godzina godzina = db.Godziny.Find(id);
            if (godzina == null)
            {
                return HttpNotFound();
            }
            return View(godzina);
        }

        // POST: Godzina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Godzina godzina = db.Godziny.Find(id);
            db.Godziny.Remove(godzina);
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
