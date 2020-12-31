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
    public class UsługaController : Controller
    {
        private TerminarzContext db = new TerminarzContext();

        // GET: Usługa
        public ActionResult Index()
        {
            return View(db.Usługi.ToList());
        }

        // GET: Usługa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usługa usługa = db.Usługi.Find(id);
            if (usługa == null)
            {
                return HttpNotFound();
            }
            return View(usługa);
        }

        // GET: Usługa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usługa/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UsługaId,NazwaUsługi,Opłata")] Usługa usługa)
        {
            if (ModelState.IsValid)
            {
                db.Usługi.Add(usługa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usługa);
        }

        // GET: Usługa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usługa usługa = db.Usługi.Find(id);
            if (usługa == null)
            {
                return HttpNotFound();
            }
            return View(usługa);
        }

        // POST: Usługa/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UsługaId,NazwaUsługi,Opłata")] Usługa usługa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usługa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usługa);
        }

        // GET: Usługa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usługa usługa = db.Usługi.Find(id);
            if (usługa == null)
            {
                return HttpNotFound();
            }
            return View(usługa);
        }

        // POST: Usługa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usługa usługa = db.Usługi.Find(id);
            db.Usługi.Remove(usługa);
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
