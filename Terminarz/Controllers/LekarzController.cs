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
    public class LekarzController : Controller
    {
        private TerminarzContext db = new TerminarzContext();

        // GET: Lekarz
        public ActionResult Index()
        {
            var lekarze = db.Lekarze.Include(l => l.Specjalista).Include(l => l.Usługa);
            return View(lekarze.ToList());
        }

        public ActionResult WyborLekarza(int specjalistaId)
        {
            var specjalista = from lekarz in db.Lekarze where lekarz.SpecjalistaId == specjalistaId select lekarz;
            //List<Lekarz> LekarzList = db.Lekarze.Where(x => x.IdSpecjalista == idspecjalista).ToList();

            return View(specjalista);
        }

        // GET: Lekarz/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lekarz lekarz = db.Lekarze.Find(id);
            if (lekarz == null)
            {
                return HttpNotFound();
            }
            return View(lekarz);
        }

        // GET: Lekarz/Create
        public ActionResult Create()
        {
            ViewBag.SpecjalistaId = new SelectList(db.Specjalisci, "SpecjalistaId", "NazwaSpecjalisty");
            ViewBag.UsługaId = new SelectList(db.Usługi, "UsługaId", "NazwaUsługi");
            return View();
        }

        // POST: Lekarz/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LekarzId,ImieLekarza,NazwiskoLekarza,Miasto,Ulica,Telefon,Email,SpecjalistaId,UsługaId")] Lekarz lekarz)
        {
            if (ModelState.IsValid)
            {
                db.Lekarze.Add(lekarz);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SpecjalistaId = new SelectList(db.Specjalisci, "SpecjalistaId", "NazwaSpecjalisty", lekarz.SpecjalistaId);
            ViewBag.UsługaId = new SelectList(db.Usługi, "UsługaId", "NazwaUsługi", lekarz.UsługaId);
            return View(lekarz);
        }

        // GET: Lekarz/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lekarz lekarz = db.Lekarze.Find(id);
            if (lekarz == null)
            {
                return HttpNotFound();
            }
            ViewBag.SpecjalistaId = new SelectList(db.Specjalisci, "SpecjalistaId", "NazwaSpecjalisty", lekarz.SpecjalistaId);
            ViewBag.UsługaId = new SelectList(db.Usługi, "UsługaId", "NazwaUsługi", lekarz.UsługaId);
            return View(lekarz);
        }

        // POST: Lekarz/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LekarzId,ImieLekarza,NazwiskoLekarza,Miasto,Ulica,Telefon,Email,SpecjalistaId,UsługaId")] Lekarz lekarz)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lekarz).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SpecjalistaId = new SelectList(db.Specjalisci, "SpecjalistaId", "NazwaSpecjalisty", lekarz.SpecjalistaId);
            ViewBag.UsługaId = new SelectList(db.Usługi, "UsługaId", "NazwaUsługi", lekarz.UsługaId);
            return View(lekarz);
        }

        // GET: Lekarz/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lekarz lekarz = db.Lekarze.Find(id);
            if (lekarz == null)
            {
                return HttpNotFound();
            }
            return View(lekarz);
        }

        // POST: Lekarz/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lekarz lekarz = db.Lekarze.Find(id);
            db.Lekarze.Remove(lekarz);
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
