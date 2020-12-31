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
    public class DzienTygodniaController : Controller
    {
        private TerminarzContext db = new TerminarzContext();

        // GET: DzienTygodnia
        public ActionResult Index()
        {
            return View(db.DniTygodnia.ToList());
        }

        // GET: DzienTygodnia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DzienTygodnia dzienTygodnia = db.DniTygodnia.Find(id);
            if (dzienTygodnia == null)
            {
                return HttpNotFound();
            }
            return View(dzienTygodnia);
        }

        // GET: DzienTygodnia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DzienTygodnia/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DzienTygodniaId,Dzien")] DzienTygodnia dzienTygodnia)
        {
            if (ModelState.IsValid)
            {
                db.DniTygodnia.Add(dzienTygodnia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dzienTygodnia);
        }

        // GET: DzienTygodnia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DzienTygodnia dzienTygodnia = db.DniTygodnia.Find(id);
            if (dzienTygodnia == null)
            {
                return HttpNotFound();
            }
            return View(dzienTygodnia);
        }

        // POST: DzienTygodnia/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DzienTygodniaId,Dzien")] DzienTygodnia dzienTygodnia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dzienTygodnia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dzienTygodnia);
        }

        // GET: DzienTygodnia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DzienTygodnia dzienTygodnia = db.DniTygodnia.Find(id);
            if (dzienTygodnia == null)
            {
                return HttpNotFound();
            }
            return View(dzienTygodnia);
        }

        // POST: DzienTygodnia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DzienTygodnia dzienTygodnia = db.DniTygodnia.Find(id);
            db.DniTygodnia.Remove(dzienTygodnia);
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
