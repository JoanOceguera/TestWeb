using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestWeb.Controllers
{
    public class AdministracionController : Controller
    {
        // GET: Administracion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Servicios()
        {
            return RedirectToAction("Index", "Servicios", null);
        }

        public ActionResult Razones()
        {
            return RedirectToAction("Index", "Razones", null);
        }

    }


}
