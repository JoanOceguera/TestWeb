using Model.Entities;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TestWeb.Controllers
{
    public class ReportesController : Controller
    {
        private ServiciosEntities servData = new ServiciosEntities();
        private RecursosHumanosEntities rhData = new RecursosHumanosEntities();
        private IncideEntities incideData = new IncideEntities();

        // GET: Reportes
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult CuentasActivas(int [] servicios)
        {
            ViewBag.servicios = new SelectList(servData.Servicios.Where(x => x.activo).ToList(), "id", "nombre");
            var model = DataServicioActivo(servicios);
            return View(model);
        }

        [Authorize]
        public ActionResult Cuentas(int[] servicios)
        {
            ViewBag.servicios = new SelectList(servData.Servicios.Where(x => x.activo).ToList(), "id", "nombre");
            var model = DataServicio(servicios);
            return View(model);
        }

        [Authorize]
        public List<ReporteServicioModel> DataServicioActivo(int [] servicios)
        {
            List<Cuentas> cuentas = servData.Cuentas.Where(x => (bool) x.activo).ToList();
            List<ReporteServicioModel> data = new List<ReporteServicioModel>();
            if (servicios != null)
            {
                foreach (var item in servicios)
                {
                    Servicios servicio = servData.Servicios.Find(item);
                    cuentas = cuentas.Where(x => x.Servicios.Contains(servicio)).ToList();
                }
            }
            foreach (var item in cuentas)
            {
                string nombre = "";
                string area = "";
                if (item.exp != null)
                {
                    if (rhData.Personal.Where(x => x.Exp == item.exp && x.CarneId.Equals(item.carneId)).Any())
                    {
                        var personaRh = rhData.Personal.Find(item.exp);
                        nombre = FunYCon.TConeccion.Revisar_Ort(personaRh.Nombre + " " + personaRh.Apellido1 + " " + personaRh.Apellido2);
                    }
                    else
                    {
                        var personaRh = rhData.BajasPers.Where(x => x.Exp == item.exp && x.CarneId.Equals(item.carneId)).FirstOrDefault();
                        nombre = FunYCon.TConeccion.Revisar_Ort(personaRh.Nombre + " " + personaRh.Apellido1 + " " + personaRh.Apellido2);
                    }

                    var persona  = incideData.Persona.Where(x => x.exp == item.exp).ToList();
                    if (persona != null)
                    {
                        int idArea = (int) persona.First().id_area;
                        if (incideData.Area.Find(idArea) != null)
                        {
                            area = incideData.Area.Find(idArea).descripcion;
                        }
                    }
                }
                data.Add(new ReporteServicioModel {

                    exp = item.exp,
                    nombre = nombre,
                    nombre_usuario = item.nombre_usuario,
                    area = area
                }); 
            }
            return data;
        }

        [Authorize]
        public List<ReporteServicioModel> DataServicio(int [] servicios)
        {
            List<Cuentas> cuentas = servData.Cuentas.ToList();
            List<ReporteServicioModel> data = new List<ReporteServicioModel>();
            if (servicios != null)
            {
                foreach (var item in servicios)
                {
                    Servicios servicio = servData.Servicios.Find(item);
                    cuentas = cuentas.Where(x => x.Servicios.Contains(servicio)).ToList();
                }
            }
            foreach (var item in cuentas)
            {
                string nombre = "";
                string area = "";
                if (item.exp != null)
                {
                    if (rhData.Personal.Where(x => x.Exp == item.exp && x.CarneId.Equals(item.carneId)).Any())
                    {
                        var personaRh = rhData.Personal.Find(item.exp);
                        nombre = FunYCon.TConeccion.Revisar_Ort(personaRh.Nombre + " " + personaRh.Apellido1 + " " + personaRh.Apellido2);
                    }
                    else
                    {
                        var personaRh = rhData.BajasPers.Where(x => x.Exp == item.exp && x.CarneId.Equals(item.carneId)).FirstOrDefault();
                        nombre = FunYCon.TConeccion.Revisar_Ort(personaRh.Nombre + " " + personaRh.Apellido1 + " " + personaRh.Apellido2);
                    }

                    int idArea = (int)incideData.Persona.Where(x => x.exp == item.exp).FirstOrDefault().id_area;
                    area = incideData.Area.Find(idArea).descripcion;
                }
                data.Add(new ReporteServicioModel
                {

                    exp = item.exp,
                    nombre = nombre,
                    nombre_usuario = item.nombre_usuario,
                    area = area
                });
            }
            return data;
        }
    }
}
