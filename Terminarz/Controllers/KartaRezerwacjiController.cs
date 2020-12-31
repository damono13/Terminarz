using Microsoft.AspNet.Identity;
using PagedList;
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
    public class KartaRezerwacjiController : Controller
    {
        private TerminarzContext db = new TerminarzContext();

        // GET: KartaRezerwacji
        public ActionResult Index()
        {
            var kartyRezerwacji = db.KartyRezerwacji.Include(k => k.Godzina).Include(k => k.Lekarz);
            return View(kartyRezerwacji.ToList());
        }

        // GET: KartaUzytkownika
        public ActionResult KartaUzytkownika(int? strona = 1, int? rozmiar = 5)
        {
            string email = User.Identity.GetUserName();
            IQueryable<Lista> KartaUzytkownika = from lista in db.KartyRezerwacji
                                                 where lista.Email == email
                                                 orderby lista.Telefon
                                                 select new Lista()
                                                 {
                                                     Email = lista.Email,
                                                     DataWizyty = lista.DataWizyty,
                                                     Telefon = lista.Telefon,
                                                     NazwaSpecjalisty = lista.Lekarz.Specjalista.NazwaSpecjalisty,
                                                     Imie = lista.Lekarz.ImieLekarza,
                                                     Nazwisko = lista.Lekarz.NazwiskoLekarza,
                                                     GodzinaWizyty = lista.Godzina.GodzinaWizyty,
                                                 };
            return View(KartaUzytkownika.ToPagedList((int)strona, (int)rozmiar));
        }

        // GET: KartaRezerwacji/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KartaRezerwacji kartaRezerwacji = db.KartyRezerwacji.Find(id);
            if (kartaRezerwacji == null)
            {
                return HttpNotFound();
            }
            return View(kartaRezerwacji);
        }

        // GET: KartaRezerwacji/Create
        public ActionResult Create()
        {
            ViewBag.Email = User.Identity.GetUserName();
            ViewBag.GodzinaId = new SelectList(db.Godziny, "GodzinaId", "GodzinaWizyty");
            //ViewBag.LekarzId = new SelectList(db.Lekarze, "LekarzId", "ImieLekarza");
            return View();
        }

        // POST: KartaRezerwacji/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KartaRezerwacjiId,Email,DataWizyty,Telefon,LekarzId,GodzinaId")] KartaRezerwacji kartaRezerwacji)
        {
            if (ModelState.IsValid)
            {
                db.KartyRezerwacji.Add(kartaRezerwacji);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GodzinaId = new SelectList(db.Godziny, "GodzinaId", "GodzinaWizyty", kartaRezerwacji.GodzinaId);
            //ViewBag.LekarzId = new SelectList(db.Lekarze, "LekarzId", "ImieLekarza", kartaRezerwacji.LekarzId);
            return View(kartaRezerwacji);
        }

        // GET: KartaRezerwacji/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KartaRezerwacji kartaRezerwacji = db.KartyRezerwacji.Find(id);
            if (kartaRezerwacji == null)
            {
                return HttpNotFound();
            }
            ViewBag.GodzinaId = new SelectList(db.Godziny, "GodzinaId", "GodzinaWizyty", kartaRezerwacji.GodzinaId);
            ViewBag.LekarzId = new SelectList(db.Lekarze, "LekarzId", "ImieLekarza", kartaRezerwacji.LekarzId);
            return View(kartaRezerwacji);
        }

        // POST: KartaRezerwacji/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KartaRezerwacjiId,Email,DataWizyty,Telefon,LekarzId,GodzinaId")] KartaRezerwacji kartaRezerwacji)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kartaRezerwacji).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GodzinaId = new SelectList(db.Godziny, "GodzinaId", "GodzinaWizyty", kartaRezerwacji.GodzinaId);
            ViewBag.LekarzId = new SelectList(db.Lekarze, "LekarzId", "ImieLekarza", kartaRezerwacji.LekarzId);
            return View(kartaRezerwacji);
        }

        // GET: KartaRezerwacji/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KartaRezerwacji kartaRezerwacji = db.KartyRezerwacji.Find(id);
            if (kartaRezerwacji == null)
            {
                return HttpNotFound();
            }
            return View(kartaRezerwacji);
        }

        // POST: KartaRezerwacji/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KartaRezerwacji kartaRezerwacji = db.KartyRezerwacji.Find(id);
            db.KartyRezerwacji.Remove(kartaRezerwacji);
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
