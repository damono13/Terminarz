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
    public class SpecjalistaController : Controller
    {
        private TerminarzContext db = new TerminarzContext();

        // GET: Specjalista
        public ActionResult Index()
        {
            return View(db.Specjalisci.ToList());
        }

        // GET: Specjalista/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specjalista specjalista = db.Specjalisci.Find(id);
            if (specjalista == null)
            {
                return HttpNotFound();
            }
            return View(specjalista);
        }

        // GET: Specjalista/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Specjalista/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SpecjalistaId,NazwaSpecjalisty")] Specjalista specjalista)
        {
            if (ModelState.IsValid)
            {
                db.Specjalisci.Add(specjalista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(specjalista);
        }

        // GET: Specjalista/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specjalista specjalista = db.Specjalisci.Find(id);
            if (specjalista == null)
            {
                return HttpNotFound();
            }
            return View(specjalista);
        }

        // POST: Specjalista/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SpecjalistaId,NazwaSpecjalisty")] Specjalista specjalista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(specjalista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(specjalista);
        }

        // GET: Specjalista/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specjalista specjalista = db.Specjalisci.Find(id);
            if (specjalista == null)
            {
                return HttpNotFound();
            }
            return View(specjalista);
        }

        // POST: Specjalista/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Specjalista specjalista = db.Specjalisci.Find(id);
            db.Specjalisci.Remove(specjalista);
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
