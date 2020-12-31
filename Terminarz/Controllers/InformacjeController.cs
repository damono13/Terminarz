using PagedList;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Terminarz.Models;

namespace Terminarz.Controllers
{
    public class InformacjeController : Controller
    {
        private TerminarzContext db = new TerminarzContext();

        // GET: Informacje
        //public ActionResult Index()
        //{
        //    return View(db.Informacje.ToList());
        //}

        // GET: Informacje
        public ActionResult Index(int? strona = 1, int? rozmiar = 1)
        {
            IQueryable<Lista> lista = from informacje in db.Informacje
                                          orderby informacje.Nazwa descending
                                          select new Lista()
                                          {
                                              Nazwa = informacje.Nazwa,
                                              Wojewodztwo = informacje.Wojewódźtwo,
                                              Miasto = informacje.Miasto,
                                              TelefonPrzychodni = informacje.Telefon,
                                              Email = informacje.Email
                                          };
            return View(lista.ToPagedList((int)strona, (int)rozmiar));
        }

        // GET: Kontakt
        public ActionResult Kontakt(int? strona = 1, int? rozmiar = 1)
        {
            IQueryable<Lista> lista = from informacje in db.Informacje
                                          orderby informacje.Telefon descending
                                          select new Lista()
                                          {
                                              TelefonPrzychodni = informacje.Telefon,
                                              Email = informacje.Email
                                          };
            return View(lista.ToPagedList((int)strona, (int)rozmiar));
        }

        // GET: Informacje/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Informacje informacje = db.Informacje.Find(id);
            if (informacje == null)
            {
                return HttpNotFound();
            }
            return View(informacje);
        }

        // GET: Informacje/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Informacje/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdInformacje,Nazwa,Wojewódźtwo,Miasto,Ulica,Telefon,Email")] Informacje informacje)
        {
            if (ModelState.IsValid)
            {
                db.Informacje.Add(informacje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(informacje);
        }

        // GET: Informacje/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Informacje informacje = db.Informacje.Find(id);
            if (informacje == null)
            {
                return HttpNotFound();
            }
            return View(informacje);
        }

        // POST: Informacje/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdInformacje,Nazwa,Wojewódźtwo,Miasto,Ulica,Telefon,Email")] Informacje informacje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(informacje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(informacje);
        }

        // GET: Informacje/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Informacje informacje = db.Informacje.Find(id);
            if (informacje == null)
            {
                return HttpNotFound();
            }
            return View(informacje);
        }

        // POST: Informacje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Informacje informacje = db.Informacje.Find(id);
            db.Informacje.Remove(informacje);
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
