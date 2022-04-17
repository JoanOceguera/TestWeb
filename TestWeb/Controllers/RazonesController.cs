using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestWeb.Controllers
{
    public class RazonesController : Controller
    {
        private ServiciosEntities servData = new ServiciosEntities();

        // GET: Razones
        public ActionResult Index()
        {
            return View(servData.Razones.ToList());
        }

        // GET: Razones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Razones/Create
        [HttpPost]
        public ActionResult Create(Razones model)
        {
            try
            {
                model.activo = true;
                servData.Razones.Add(model);
                servData.Entry(model).State = EntityState.Added;
                servData.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Razones/Edit/5
        public ActionResult Edit(int id)
        {
            return View(servData.Razones.Find(id));
        }

        // POST: Razones/Edit/5
        [HttpPost]
        public ActionResult Edit(Razones model)
        {
            try
            {
                Razones razon = servData.Razones.Find(model.id);
                razon.descripcion = model.descripcion;
                servData.Entry(razon).State = EntityState.Modified;
                servData.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
                Razones razon = servData.Razones.Find(id);
                razon.activo = false;
                servData.Entry(razon).State = EntityState.Modified;
                servData.SaveChanges();
                return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Activar(int id)
        {
                Razones razon = servData.Razones.Find(id);
                razon.activo = true;
                servData.Entry(razon).State = EntityState.Modified;
                servData.SaveChanges();
                return RedirectToAction("Index");
        }
    }
}
