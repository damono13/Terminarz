using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Terminarz.Models;

namespace MVC5FullCalandarPlugin.Controllers
{
    public class HomeController : Controller
    {
        TerminarzContext db = new TerminarzContext();
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult StronaGlowna()
        {
            return this.View();
        }

        public ActionResult Test()
        {
            //List<Country> CountryList = db.Countries.ToList();
            //ViewBag.CountryList = new SelectList(CountryList, "CountryId", "CountryName");
            return View();
        }

        //public JsonResult GetStateList(int CountryId)
        //{
        //    db.Configuration.ProxyCreationEnabled = false;
        //    List<State> StateList = db.States.Where(x => x.IdCountry == CountryId).ToList();
        //    return Json(StateList, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult About()
        {
            return this.View();
        }

        public ActionResult Contact()
        {
            return this.View();
        }
    }
}