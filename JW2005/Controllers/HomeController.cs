using System.Web.Mvc;
using JW2005.DAL;

namespace JW2005.Controllers
{
    public class HomeController : Controller
    {
        private readonly Jw2005Context _db = new Jw2005Context();

        public ActionResult Index()
        {
            return View(_db.Servers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _db.Dispose();
            base.Dispose(disposing);
        }
    }
}