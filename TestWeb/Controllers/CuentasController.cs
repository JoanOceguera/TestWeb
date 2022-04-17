using Model.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace TestWeb.Controllers
{
    public class CuentasController : Controller
    {
        private ServiciosEntities db = new ServiciosEntities();

        // GET: Cuentas
        public ActionResult Index()
        {
            return View(db.Cuentas.ToList());
        }
        // GET: Cuentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuentas cuentas = db.Cuentas.Find(id);
            if (cuentas == null)
            {
                return HttpNotFound();
            }
            return View(cuentas);
        }

        // POST: Cuentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cuentas cuentas = db.Cuentas.Find(id);
            cuentas.activo = false;
            db.Cuentas_Ausentes.RemoveRange(cuentas.Cuentas_Ausentes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Cuentas/Delete/5
        [HttpGet, ActionName("Activar")]
        public ActionResult Activar(int id)
        {
            Cuentas cuentas = db.Cuentas.Find(id);
            cuentas.activo = true;
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
