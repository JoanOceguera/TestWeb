using Model.Entities;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DevExpress.XtraReports.UI;
using System.Text.RegularExpressions;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using TestWeb.Models;
using System.IO;
using System.Configuration;
using FunYCon;

namespace TestWeb.Controllers
{
    public class SolicitudController : Controller
    {
        private ServiciosEntities servData = new ServiciosEntities();
        private RecursosHumanosEntities rhData = new RecursosHumanosEntities();
        private IncideEntities incideData = new IncideEntities();
        private ApplicationRoleManager _roleManager
        {
            get
            {
                return HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
        }

        private ApplicationUserManager _userManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        [Authorize]
        public ActionResult Index(int area = 0)
        {
            
            var solicitudesModelView = new List<SolicitudIndexModel>();
            List<Solicitud> solicitudes = new List<Solicitud> ();
            if (area == 0)
                solicitudes = servData.Solicitud.OrderByDescending(x => x.fecha_solicitud).ToList();
            else
            {
                var personasArea = incideData.Persona.Where(x => x.id_area == area).ToList();
                var solicitudesOriginales = servData.Solicitud.OrderByDescending(x => x.fecha_solicitud).ToList();
                foreach (var solicitud in solicitudesOriginales)
                {
                    if (personasArea.Where(x => x.exp == solicitud.exp_benef && x.ci.Equals(solicitud.carneId)).Any())
                    {
                        solicitudes.Add(solicitud);
                    }
                }
            }

            foreach (var item in solicitudes)
            {
                var areaDescripcion = incideData.Area.First().descripcion;
                int jefe = (int)incideData.Area.First().Persona_jefe;
                int ExpJefe = incideData.Persona.Find(jefe).exp;
                string carnetJefe = incideData.Persona.Find(jefe).ci;

                var personaIncide = incideData.Persona.Where(x => x.ci == item.carneId && x.exp == item.exp_benef).SingleOrDefault();
                if (personaIncide != null)
                {
                    areaDescripcion = incideData.Area.Find(personaIncide.id_area).descripcion;
                    jefe = (int)incideData.Area.Find(personaIncide.id_area).Persona_jefe;
                    ExpJefe = incideData.Persona.Find(jefe).exp;
                    carnetJefe = incideData.Persona.Find(jefe).ci;
                }

                var validez = "";
                var solicitante = "";
                var beneficiado = "";
                if (item.exp_benef != null)
                {
                    var personaRHBeneficiado = rhData.Personal.Where(x => x.Exp == item.exp_benef && x.CarneId == item.carneId).ToList();
                    if (!personaRHBeneficiado.Any())
                    {
                        var personaBajasBeneficiado = rhData.BajasPers.ToList().Where(x => x.Exp == item.exp_benef && x.CarneId.Equals(item.carneId));
                        if (personaBajasBeneficiado.Any())
                        {
                            var persona = personaBajasBeneficiado.FirstOrDefault();
                            beneficiado = persona.Nombre + ' ' + persona.Apellido1 + ' ' + persona.Apellido2;
                        }

                    }
                    else
                    {
                        beneficiado = personaRHBeneficiado.First().Nombre + ' ' + personaRHBeneficiado.First().Apellido1 + ' ' + personaRHBeneficiado.First().Apellido2;
                    }
                }
               
                var personaRHSolicitante = rhData.Personal.Where(x => x.Exp == ExpJefe && x.CarneId.Equals(carnetJefe)).ToList();

                if (!personaRHSolicitante.Any())
                {
                    var personaBajasSolicitante = rhData.BajasPers.ToList().Where(x => x.Exp == ExpJefe && x.CarneId.Equals(carnetJefe)).FirstOrDefault();
                    solicitante = TConeccion.Revisar_Ort(personaBajasSolicitante.Nombre + ' ' + personaBajasSolicitante.Apellido1 + ' ' + personaBajasSolicitante.Apellido2);
                }
                else
                {
                    solicitante = TConeccion.Revisar_Ort(personaRHSolicitante.First().Nombre + ' ' + personaRHSolicitante.First().Apellido1 + ' ' + personaRHSolicitante.First().Apellido2);
                }
                solicitante = FunYCon.TConeccion.Revisar_Ort(solicitante);
                beneficiado = FunYCon.TConeccion.Revisar_Ort(beneficiado);
                if (item.validez != null)
                    validez = ((DateTime)item.validez).ToShortDateString();
                else
                    validez = "Mientras mantenga vinculo laboral";
                
                var estado = item.estado;
                var fechaSolicitud = item.fecha_solicitud;
                var tipoSolic = "";
                switch (item.tsolic)
                {
                    case ("c"):
                        tipoSolic = "Creación de usuario";
                        break;
                    case ("m"):
                        tipoSolic = "Modificación de usuario";
                        break;
                    case ("r"):
                        tipoSolic = "Renovacion de usuario";
                        break;


                }
                solicitudesModelView.Add(new SolicitudIndexModel(item.id, solicitante, beneficiado, validez, areaDescripcion, estado, ((DateTime)fechaSolicitud), tipoSolic));
            }
            return View(solicitudesModelView);
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            return RedirectToAction("Planilla", new { id = id, detalle = true});
        }

        [Authorize]
        public ActionResult Create()
        {
            Solicitud solicitud = new Solicitud();
            Dictionary<string, string> personal = new Dictionary < string, string> ();
            Dictionary<string, string> rol = new Dictionary<string, string>();
            personal.Add("d","Dirigente");
            personal.Add("e", "Especialista");
            personal.Add("t", "Técnico");
            personal.Add("o", "Otros");
            rol.Add("u", "Usuario");
            rol.Add("ua", "Usuario Avanzado");
            rol.Add("a", "Administrador");
            ViewBag.Personal = new SelectList(personal, "Key", "Value");
            ViewBag.Rol = new SelectList(rol, "Key", "Value");
            ViewBag.Servicios = new SelectList(servData.Servicios.Where(x => x.activo).ToList(), "id", "nombre");
            ViewBag.area = new SelectList(incideData.Area.OrderBy(x=> x.descripcion).ToList(), "id_area", "descripcion");
            ViewBag.cuentasActivas = servData.Cuentas.Where(x => (bool)x.activo).ToList().Any();
            ViewBag.cuentasInactivas = servData.Cuentas.Where(x => !(bool)x.activo).ToList().Any();
            return View(solicitud);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(FormCollection collection,  Solicitud model, int [] servicios)
        {

            var personaIncide = incideData.Persona.Where(x => x.exp == model.exp_benef && x.activo == 1).SingleOrDefault();
            int jefe = 0;
            int ExpJefe = 0;
            if (personaIncide != null)
            {
                jefe = (int)incideData.Area.Find(personaIncide.id_area).Persona_jefe;
                ExpJefe = incideData.Persona.Find(jefe).exp;
            }
            else
            {
                jefe = (int)incideData.Area.First().Persona_jefe;
                ExpJefe = incideData.Persona.Find(jefe).exp;
            }
            
            model.estado = "Solicitada";
            model.fecha_solicitud = DateTime.Now;
            model.usuario = CurrentUser.Get.UserId;
            model.carneId = rhData.Personal.Find(model.exp_benef).CarneId;
            if (servicios != null)
            {
                foreach (var item in servicios)
                {
                    Servicios servicio = servData.Servicios.Find(item);
                    model.Servicios.Add(servicio);
                }
            }
            if (model.tsolic.Equals("m"))
            {                    
                model.nombre_usuario = servData.Cuentas.Where(x => x.exp == model.exp_benef && (bool)x.activo).FirstOrDefault().nombre_usuario;
            }
            servData.Entry(model).State = EntityState.Added;
            servData.SaveChanges();
            return RedirectToAction("NotificarEsp", new { message = "Su solicitud se ha relizado correctamente y esta pendiente de aprobación", area = personaIncide.id_area, exp_benef = model.exp_benef, exp_solic = ExpJefe });
            
            
        }

        [HttpGet]
        [Authorize]
        public ActionResult Aprobar(int id)
        {
            var solicitud = servData.Solicitud.Find(id);
            solicitud.estado = "Aprobada";
            solicitud.fecha_aprobacion = DateTime.Now;
            servData.Entry(solicitud).State = EntityState.Modified;
            servData.SaveChanges();
            return RedirectToAction("NotificarAdm", new {  message = "La solicitud fue aprobada correctamente y está a la espera de ejecución", idSolicitud = id });
        }

        [HttpGet]
        public ActionResult Rechazar(int id)
        {
            ViewBag.id = id;
            ViewBag.razones = servData.Razones.Where(x => x.activo).ToList();
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Rechazar(int id, int [] razones)
        {
            var solicitud = servData.Solicitud.Find(id);
            var persona = incideData.Persona.Where(x => x.ci == solicitud.carneId && x.exp == solicitud.exp_benef).SingleOrDefault();
            solicitud.estado = "Rechazada";
            if (razones != null)
            {
                foreach (var item in razones)
                {
                    solicitud.Razones.Add(servData.Razones.Find(item));
                }
                
            }
            servData.Entry(solicitud).State = EntityState.Modified;
            servData.SaveChanges();
            var user = _userManager.FindById(solicitud.usuario);
            var personaRH = rhData.Personal.Find(solicitud.exp_benef);
            var nombreBenf = FunYCon.TConeccion.Revisar_Ort(personaRH.Nombre + " " + personaRH.Apellido1 + " " + personaRH.Apellido2);
            string subject = "Notificación Solicitud Rechazada";
            string body = "Su solicitud de servicios hecha el " + ((DateTime)solicitud.fecha_solicitud).ToShortDateString() + " a nombre de " + nombreBenf + " a sido rechazada por " + CurrentUser.Get.FullName + " debido a las siguientes razones:\n";
            foreach (var item in razones)
            {
                string razon = " • " + servData.Razones.Find(item).descripcion;
                body = body + razon + ".\n";
            }
            body = body + "Atentamente,\nDepartamento de Informática.";
            EmailSender.Sender(user.Email, subject, body, "");

            if (CurrentUser.Get.Role.Equals(ConfigurationManager.AppSettings.Get("11843472-ae59-423a-9ec4-6bca52a29b02")) || CurrentUser.Get.Role.Equals(ConfigurationManager.AppSettings.Get("8834006e-f16c-4f30-a924-ee00c2992b71")))
            {
                return RedirectToAction("Index");
            }
            else
            {
                if (persona != null)
                return RedirectToAction("Index", new { area = persona.id_area });
                else
                    return RedirectToAction("Index", new { area = incideData.Area.First().id_area });
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Planilla(int id, bool detalle = false)
        {
            PlanillaViewModel model = new PlanillaViewModel();
            Solicitud solicitud = servData.Solicitud.Find(id);
            model = SolicitudtoPlanilla.solicitudToPlanilla(solicitud);
            ViewBag.Servicios = servData.Servicios.Where(x => x.activo).ToList();
            ViewBag.id = id;
            ViewBag.detalle = detalle;
            var userApp = _userManager.FindById(solicitud.usuario);
            var usuario = rhData.Personal.Where(x => x.Exp == (userApp.exp) && x.CarneId.Equals(userApp.carneId));
            if (usuario.Any())
            {
                var user = usuario.FirstOrDefault();
                model.usuario = FunYCon.TConeccion.Revisar_Ort(user.Nombre + " " + user.Apellido1 + " " + user.Apellido2);
                model.cargoUsuario = FunYCon.TConeccion.Revisar_Ort(rhData.Plazas.Find(rhData.Plantilla.Where(x => x.Cod_Plaza == user.IdPlaza).FirstOrDefault().Ocupacion).Nom_Ocup);
            }
            else
            {
                var usuarioBaja = rhData.BajasPers.Where(x => x.Exp == (userApp.exp) && x.CarneId.Equals(userApp.carneId));
                if (usuarioBaja.Any())
                {
                    var user = usuario.FirstOrDefault();
                    model.usuario = FunYCon.TConeccion.Revisar_Ort(user.Nombre + " " + user.Apellido1 + " " + user.Apellido2);
                    model.cargoUsuario = FunYCon.TConeccion.Revisar_Ort(rhData.Plazas.Find(rhData.BajaPlantilla.Where(x => x.Cod_Plaza == user.IdPlaza).FirstOrDefault().Ocupacion).Nom_Ocup);
                }
            }
            return View(model);
        }

        [Authorize]
        public JsonResult Datos(int exp)
        {
            var datos = new Object[4];
            var personaRH = rhData.Personal.Find(exp);
            var plantillaRH = rhData.Plantilla.Find(personaRH.IdPlaza);
            var plazaRH = rhData.Plazas.Find(plantillaRH.Ocupacion);
            datos[0] = TConeccion.Revisar_Ort(rhData.Plazas.Find(rhData.Plantilla.Find(rhData.Personal.Find(exp).IdPlaza).Ocupacion).Nom_Ocup);
            datos[1] = incideData.Area.Find(incideData.Persona.ToList().Where((x => x.exp == exp && x.activo == 1)).First().id_area).id_area;
            datos[2] = incideData.Area.Find(incideData.Persona.ToList().Where((x => x.exp == exp && x.activo == 1)).First().id_area).descripcion;

            if (personaRH.FotoImg != null)
                datos[3] = 1;
            else
                datos[3] = 0;
            var json = Json(datos, JsonRequestBehavior.AllowGet);
            return json;
        }

        [Authorize]
        public JsonResult Nombres(string nombre, string apellido1, string apellido2)
        {
            var datos = new string [5];
            if (nombre != "")
            {
                var nombres = nombre.Split(' ');
                var apellidos1 = apellido1.Split(' ');
                var apellidos2 = apellido2.Split(' ');
                datos[0] = QuitarAcentos((nombres[0] + '.' + apellidos1[0]).ToLower() + "@cie.cu");
                datos[1] = QuitarAcentos((nombres[0] + '.' + apellidos2[0]).ToLower() + "@cie.cu");
                datos[2] = QuitarAcentos((nombres[0] + '.' + apellidos1[0] + '.' + apellidos2[0]).ToLower() + "@cie.cu");
                datos[3] = QuitarAcentos(((nombres[0].ToCharArray()[0]).ToString() + '.' + apellidos1[0]).ToLower() + "@cie.cu");
                if (nombres.Length > 1)
                {
                    datos[4] = QuitarAcentos((nombres[0] + '.' + nombres[1] + '.' + apellido1[0]).ToLower() + "@cie.cu");
                }
                else
                    if (apellidos1.Length > 1)
                {
                    datos[4] = QuitarAcentos((nombres[0] + '.' + apellidos1[0] + '.' + apellidos1[1]).ToLower() + "@cie.cu");
                }
                else
                        if (apellidos2.Length > 1)
                {
                    datos[4] = QuitarAcentos((nombres[0] + '.' + apellidos2[0] + '.' + apellidos2[1]).ToLower() + "@cie.cu");
                }
                else
                    datos[4] = QuitarAcentos(((nombres[0].ToCharArray()[0]).ToString() + '.' + apellidos1[0] + '.' + apellidos2[0]).ToLower() + "@cie.cu");
            }
            var json = Json(datos, JsonRequestBehavior.AllowGet);
            return json;
        }

        [Authorize]
        public JsonResult comprobar_Nombre(string nombre)
        {
            var data = servData.Cuentas.ToList().Where(x => x.nombre_usuario.Equals(nombre));
            bool existe = false;
            if (data.Any())
            {
                existe = true;
            }                
            var json = Json(existe, JsonRequestBehavior.AllowGet);
            return json;
        }

        [Authorize]
        public ActionResult GetImage(int Exp)
        {
            var personaRH = rhData.Personal.Find(Exp);
            byte[] byteArray = personaRH.FotoImg;
            if (byteArray != null)
            {
                return new FileContentResult(byteArray, "image/jpeg");
            }
            else
            {
                return null;
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult PrintViewToPdf(int id)
        {
            Solicitud solicitud = servData.Solicitud.Find(id);
            PlanillaViewModel planilla = SolicitudtoPlanilla.solicitudToPlanilla(solicitud);
            Planilla rep = new Planilla(planilla);
            string direccionSave = System.Configuration.ConfigurationManager.AppSettings["direccion"];         
            string tipoSolic = "";
            switch (solicitud.tsolic)
            {
                case ("c"):
                    tipoSolic = "Creación de usuario";
                    break;
                case ("m"):
                    tipoSolic = "Modificación de usuario";
                    break;
                case ("r"):
                    tipoSolic = "Renovacion de usuario";
                    break;


            }
            string nombre = "Planilla " + planilla.id_solic + " - " + tipoSolic + " " + planilla.nombre_benef + ' ' + planilla.apellido1_benef + ' ' + planilla.apellido2_benef + ".pdf";
            string direccion = direccionSave + nombre;
            rep.ExportToPdf(direccion);

            var path = direccionSave;
            var file = Path.Combine(direccionSave, nombre);
            file = Path.GetFullPath(file);
            string mimeType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "inline; filename=\"" +  nombre + "\"");
            return File(file, mimeType);
            
        }

        [HttpPost]
        [Authorize]
        public ActionResult PrintViewToPdf(int [] servicios, string tpers, string rolpc, string nombre_usuario, int id_solic)
        {
            Solicitud solicitud = servData.Solicitud.Find(id_solic);
            solicitud.tpers = tpers;
            solicitud.rolpc = rolpc;
            solicitud.nombre_usuario = nombre_usuario;
            solicitud.estado = "Ejecutada";
            servData.Entry(solicitud).State = EntityState.Modified;
            servData.SaveChanges();
            solicitud.Servicios.Clear();
            foreach (var item in servicios)
            {
                Servicios serv = servData.Servicios.Find(item);
                solicitud.Servicios.Add(serv);
            }
            servData.SaveChanges();

            PlanillaViewModel planilla = SolicitudtoPlanilla.solicitudToPlanilla(solicitud);
            Planilla rep = new Planilla(planilla);
            ReportPrintTool tool = new ReportPrintTool(rep);
            string direccionSave = System.Configuration.ConfigurationManager.AppSettings["direccion"];
            string tipoSolic = "";
            switch (solicitud.tsolic)
            {
                case ("c"):
                    tipoSolic = "Creación de usuario";
                    break;
                case ("m"):
                    tipoSolic = "Modificación de usuario";
                    break;
                case ("r"):
                    tipoSolic = "Renovacion de usuario";
                    break;


            }
            string nombre = "Planilla " + planilla.id_solic + " - " + tipoSolic + " " + planilla.nombre_benef + ' ' + planilla.apellido1_benef + ' ' + planilla.apellido2_benef + ".pdf";
            string direccion = direccionSave + nombre;
            rep.ExportToPdf(direccion);
            if (solicitud.tsolic.Equals("c"))
            {
                return RedirectToAction("CreateCuenta", new { id = id_solic, direccion = direccion});
            }
            else if (solicitud.tsolic.Equals("m"))
            {
                return RedirectToAction("ModifCuenta", new { id = id_solic, direccion = direccion });
            }
            else
            {
                return RedirectToAction("RenovCuenta", new { id = id_solic, direccion = direccion});
            }
        }

        [Authorize]
        public string QuitarAcentos(string inputString)
        {
            Regex a = new Regex("[á|à|ä|â]", RegexOptions.Compiled);
            Regex e = new Regex("[é|è|ë|ê]", RegexOptions.Compiled);
            Regex i = new Regex("[í|ì|ï|î]", RegexOptions.Compiled);
            Regex o = new Regex("[ó|ò|ö|ô]", RegexOptions.Compiled);
            Regex u = new Regex("[ú|ù|ü|û]", RegexOptions.Compiled);
            Regex n = new Regex("[ñ|Ñ]", RegexOptions.Compiled);
            inputString = a.Replace(inputString, "a");
            inputString = e.Replace(inputString, "e");
            inputString = i.Replace(inputString, "i");
            inputString = o.Replace(inputString, "o");
            inputString = u.Replace(inputString, "u");
            inputString = n.Replace(inputString, "n");
            return inputString;
        }

        [Authorize]
        public ActionResult CreateCuenta(int id, string direccion)
        {
            Solicitud solicitud = servData.Solicitud.Find(id);
            solicitud.fecha_ejecucion = DateTime.Now;
            Cuentas cuenta = new Cuentas()
            {
                nombre_usuario = solicitud.nombre_usuario,
                tpers = solicitud.tpers,
                activo = true,
                rolpc = solicitud.rolpc,
                validez = solicitud.validez,
                exp = solicitud.exp_benef,
                carneId = solicitud.carneId,
                marca = true
            };
            foreach (var item in solicitud.Servicios)
                {

                    cuenta.Servicios.Add(item);
                }
            servData.Entry(cuenta).State = EntityState.Added;
            servData.Entry(solicitud).State = EntityState.Modified;
            servData.SaveChanges();
            return RedirectToAction("NotificarEspServ", new { message = "La cuenta ha sido creada con éxito", idSolicitud = id, direccion = direccion });
        }

        [Authorize]
        public ActionResult ModifCuenta(int id, string direccion)
        {
            Solicitud solicitud = servData.Solicitud.Find(id);
            solicitud.fecha_ejecucion = DateTime.Now;
            Cuentas cuenta = servData.Cuentas.ToList().Where(x => (bool)x.activo && x.exp == solicitud.exp_benef).FirstOrDefault();
            cuenta.tpers = solicitud.tpers;
            cuenta.rolpc = solicitud.rolpc;
            cuenta.validez = solicitud.validez;
            cuenta.carneId = solicitud.carneId;
            cuenta.Servicios.Clear();
            foreach (var item in solicitud.Servicios)
            {

                cuenta.Servicios.Add(item);
            }
            if (solicitud.razon_suspencion != null )
            {
                cuenta.activo = false;
                Deshabilitar deshab = new Deshabilitar()
                {
                    idCuenta = cuenta.id,
                    fecha_inicio = (DateTime)solicitud.suspencion_inicio,
                    fecha_fin = (DateTime)solicitud.suspencion_fin,
                    activa = true
                };
                switch (solicitud.razon_suspencion)
                {
                    case "cm":
                        deshab.observacion = "Certificado Médico";
                        break;
                    case "se":
                        deshab.observacion = "Salida al Exterior";
                        break;
                    case "lm":
                        deshab.observacion = "Licencia de Maternidad";
                        break;
                    case "m":
                        deshab.observacion = "Movilización";
                        break;
                    case "lss":
                        deshab.observacion = "Licencia sin Sueldo";
                        break;
                    case "md":
                        deshab.observacion = "Medida Disciplinaria";
                        break;
                    case "o":
                        deshab.observacion = "Otros";
                        break;
                    default:
                        deshab.observacion = "Baja de la Entidad";
                        break;
                }
                servData.Entry(deshab).State = EntityState.Added;
            }
            servData.Entry(cuenta).State = EntityState.Modified;
            servData.Entry(solicitud).State = EntityState.Modified;
            servData.SaveChanges();
            return RedirectToAction("NotificarEspServ", new { message = "La cuenta ha sido modificada con éxito", idSolicitud = id, direccion = direccion });
        }

        [Authorize]
        public ActionResult RenovCuenta(int id, string direccion)
        {
            Solicitud solicitud = servData.Solicitud.Find(id);
            solicitud.fecha_ejecucion = DateTime.Now;
            Cuentas cuenta = servData.Cuentas.ToList().Where(x => !(bool)x.activo && x.nombre_usuario.Equals(solicitud.nombre_usuario)).FirstOrDefault();
            cuenta.exp = solicitud.exp_benef;
            cuenta.rolpc = solicitud.rolpc;
            cuenta.tpers = solicitud.tpers;
            cuenta.validez = solicitud.validez;
            cuenta.carneId = solicitud.carneId;
            if (solicitud.Servicios.Any())
            {
                cuenta.Servicios.Clear();
                foreach (var item in solicitud.Servicios)
                {
                    cuenta.Servicios.Add(item);
                }
            }
            Deshabilitar deshab = cuenta.Deshabilitar.ToList().Where(x => x.activa).FirstOrDefault();
            deshab.activa = false;
            cuenta.activo = true;
            servData.Entry(deshab).State = EntityState.Modified;
            servData.Entry(cuenta).State = EntityState.Modified;
            servData.Entry(solicitud).State = EntityState.Modified;
            servData.SaveChanges();
            return RedirectToAction("NotificarEspServ", new { message = "La cuenta ha sido renovada con éxito", idSolicitud = id, direccion = direccion});
        }

        [Authorize]
        public JsonResult Personas(int area, string tsolic)
        {
            var data = incideData.Persona.ToList().Where(x => x.id_area == area && x.activo == 1);
            var cuentas = servData.Cuentas.Where(x => (bool)x.activo);
            var personasArea = incideData.Persona.Where(x => x.id_area == area).ToList();
            var solicitudes = new List<Solicitud>();
            var solicitudesOriginales = servData.Solicitud.OrderByDescending(x => x.fecha_solicitud).ToList();
            foreach (var solicitud in solicitudesOriginales)
            {
                if (personasArea.Where(x => x.exp == solicitud.exp_benef && x.ci.Equals(solicitud.carneId)).Any() && ((solicitud.estado.Equals("Solicitada") || solicitud.estado.Equals("Aprobada"))))
                {
                    solicitudes.Add(solicitud);
                }
            }
            var personas = new List<PersonaModel>();
            foreach (var item in data)
            {
                if (tsolic.Equals("c") || tsolic.Equals("r"))
                {
                    if (!cuentas.Where(x => x.exp == item.exp).Any() && !solicitudes.Where(x => x.exp_benef == item.exp).Any())
                    {
                        var personaRH = rhData.Personal.Find(item.exp);
                        if (personaRH != null)
                        {

                            var nombre = personaRH.Nombre;
                            var apellido1 = personaRH.Apellido1;
                            var apellido2 = personaRH.Apellido2;
                            nombre = FunYCon.TConeccion.Revisar_Ort(nombre);
                            apellido1 = FunYCon.TConeccion.Revisar_Ort(apellido1);
                            apellido2 = FunYCon.TConeccion.Revisar_Ort(apellido2);
                            var persona = new PersonaModel(personaRH.Exp, nombre, apellido1, apellido2);
                            personas.Add(persona);
                        }
                    }
                }
                else
                {
                    if (cuentas.Where(x => x.exp == item.exp && x.carneId.Equals(item.ci)).Any())
                    {
                        var personaRH = rhData.Personal.Find(item.exp);
                        if (personaRH != null)
                        {

                            var nombre = personaRH.Nombre;
                            var apellido1 = personaRH.Apellido1;
                            var apellido2 = personaRH.Apellido2;
                            nombre = FunYCon.TConeccion.Revisar_Ort(nombre);
                            apellido1 = FunYCon.TConeccion.Revisar_Ort(apellido1);
                            apellido2 = FunYCon.TConeccion.Revisar_Ort(apellido2);
                            var persona = new PersonaModel(personaRH.Exp, nombre, apellido1, apellido2);
                            personas.Add(persona);
                        }
                    }
                }

            }
            personas = personas.OrderBy(x => x.nombre).ToList();
            var json = Json(personas, JsonRequestBehavior.AllowGet);
            return json;
        }

        [Authorize]
        public JsonResult CuentasInactivas()
        {
            servData.Cuentas.Where(x => !(bool)x.activo).ToList();
            var cuentas = servData.Cuentas.Select(
                x => new
                {
                    nombre_usuario = x.nombre_usuario,
                    activo =x.activo

                }).Where(x => !(bool)x.activo).ToList();
            
            var json = Json(cuentas, JsonRequestBehavior.AllowGet);
            return json;
        }

        public JsonResult ExpArea(int area)
        {
            var exp = incideData.Persona.Select(
                x => new
                {
                    exp = x.exp,
                    area = x.id_area,
                    activo = x.activo

                }).Where(x => x.area == area && x.activo == 1).ToList().OrderBy(x => x.exp);
            var json = Json(exp, JsonRequestBehavior.AllowGet);
            return json;
        }

        [Authorize]
        [HttpGet]
        public ActionResult NotificarEsp(string message, int area, int exp_benef, int exp_solic)
        {
            List<CurrentUser> data = new List<CurrentUser>();
            var users = _roleManager.FindById("8834006e-f16c-4f30-a924-ee00c2992b71").Users.ToList();
            foreach (var item in users)
            {
                var user = _userManager.FindById(item.UserId);
                var personaRH = rhData.Personal.Find(user.exp);
                data.Add(new CurrentUser
                {
                    Email = user.Email,
                    FullName = FunYCon.TConeccion.Revisar_Ort(personaRH.Nombre + " " + personaRH.Apellido1 + " " + personaRH.Apellido2)
                });
            }
            ViewBag.datos = data;
            ViewBag.message = message;
            ViewBag.area = area;
            ViewBag.exp_benef = exp_benef;
            ViewBag.exp_solic = exp_solic;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult NotificarEsp(string [] correos, int area, int exp_benef, int exp_solic)
        {
            var personaRHBef = rhData.Personal.Find(exp_benef);
            var personaRHSolic = rhData.Personal.Find(exp_solic);
            var nombreBenf = FunYCon.TConeccion.Revisar_Ort(personaRHBef.Nombre + " " + personaRHBef.Apellido1 + " " + personaRHBef.Apellido2);
            var nombreSolic = FunYCon.TConeccion.Revisar_Ort(personaRHSolic.Nombre + " " + personaRHSolic.Apellido1 + " " + personaRHSolic.Apellido2);
            foreach (var item in correos)
            {
                string subject = "Notificación Nueva Solicitud";
                string body = "Buenos Días:\nEl presente correo le llega de parte de la aplicación Servired con el objetivo de informar de que existe una solicitud del área " + incideData.Area.Find(area).descripcion + " a nombre de " + nombreBenf + " hecha por " + nombreSolic + " pendiente de aprobación.\nAtentamente,\nDepartamento de Informática.";
                EmailSender.Sender(item, subject, body, "");
            }
            if (CurrentUser.Get.Role.Equals(ConfigurationManager.AppSettings.Get("11843472-ae59-423a-9ec4-6bca52a29b02")) || CurrentUser.Get.Role.Equals(ConfigurationManager.AppSettings.Get("8834006e-f16c-4f30-a924-ee00c2992b71")))
                return RedirectToAction("Index");
            else
                return RedirectToAction("Index", new { area = area });
        }

        [Authorize]
        [HttpGet]
        public ActionResult NotificarAdm(string message, int idSolicitud)
        {
            List<CurrentUser> data = new List<CurrentUser>();
            var users = _roleManager.FindById("11843472-ae59-423a-9ec4-6bca52a29b02").Users.ToList();
            var solicitud = servData.Solicitud.Find(idSolicitud);
            foreach (var item in users)
            {
                var user = _userManager.FindById(item.UserId);
                var personaRH = rhData.Personal.Find(user.exp);
                data.Add(new CurrentUser
                {
                    Email = user.Email,
                    FullName = FunYCon.TConeccion.Revisar_Ort(personaRH.Nombre + " " + personaRH.Apellido1 + " " + personaRH.Apellido2)
                });
            }
            ViewBag.datos = data;
            ViewBag.message = message;
            ViewBag.solicitud = solicitud.id;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult NotificarAdm(string[] correos, int idSolicitud)
        {
            var solicitud = servData.Solicitud.Find(idSolicitud);
            var personaIncide = incideData.Persona.Where(x => x.ci == solicitud.carneId && x.exp == solicitud.exp_benef).SingleOrDefault();
            int jefe = 0;
            int ExpJefe = 0;
            if (personaIncide != null)
            {
                jefe = (int)incideData.Area.Find(personaIncide.id_area).Persona_jefe;
                ExpJefe = incideData.Persona.Find(jefe).exp;
            }
            else
            {
                jefe = (int)incideData.Area.First().Persona_jefe;
                ExpJefe = incideData.Persona.Find(jefe).exp;
            }
                                   
            var personaRHBef = rhData.Personal.Find(solicitud.exp_benef);
            var personaRHSolic = rhData.Personal.Find(ExpJefe);
            var nombreBenf = FunYCon.TConeccion.Revisar_Ort(personaRHBef.Nombre + " " + personaRHBef.Apellido1 + " " + personaRHBef.Apellido2);
            var nombreSolic = FunYCon.TConeccion.Revisar_Ort(personaRHSolic.Nombre + " " + personaRHSolic.Apellido1 + " " + personaRHSolic.Apellido2);
            foreach (var item in correos)
            {
                string subject = "Notificación de Solicitud Pendiente de Ejecución"; 
                string body = "";
                if (personaIncide != null)
                {
                    body = "Buenos Días:\nEl presente correo le llega de parte de la aplicación Servired con el objetivo de informar de que existe una solicitud del área " + incideData.Area.Find(personaIncide.id_area).descripcion + " a nombre de " + nombreBenf + " hecha por " + nombreSolic + " pendiente de ejecución.\nAtentamente,\nDepartamento de Informática.";
                }
                else
                {
                    body = "Buenos Días:\nEl presente correo le llega de parte de la aplicación Servired con el objetivo de informar de que existe una solicitud del área " + incideData.Area.First().descripcion + " a nombre de " + nombreBenf + " hecha por " + nombreSolic + " pendiente de ejecución.\nAtentamente,\nDepartamento de Informática.";
                }
                EmailSender.Sender(item, subject, body, "");
            }
            if (CurrentUser.Get.Role.Equals(ConfigurationManager.AppSettings.Get("11843472-ae59-423a-9ec4-6bca52a29b02")) || CurrentUser.Get.Role.Equals(ConfigurationManager.AppSettings.Get("8834006e-f16c-4f30-a924-ee00c2992b71")))
                return RedirectToAction("Index");
            else
                if (personaIncide != null)
                    return RedirectToAction("Index", new { area = personaIncide.id_area });
                else
                    return RedirectToAction("Index", new { CurrentUser.Get.area });

        }

        public ActionResult NotificarEspServ(string message, int idSolicitud, string direccion)
        {
            List<CurrentUser> data = new List<CurrentUser>();
            var users = _roleManager.FindById("e0d3e5f8-cc4e-4b76-9131-764e34e88158").Users.ToList();
            var solicitud = servData.Solicitud.Find(idSolicitud);
            foreach (var item in users)
            {
                var user = _userManager.FindById(item.UserId);
                var personaRH = rhData.Personal.Find(user.exp);
                data.Add(new CurrentUser
                {
                    Email = user.Email,
                    FullName = FunYCon.TConeccion.Revisar_Ort(personaRH.Nombre + " " + personaRH.Apellido1 + " " + personaRH.Apellido2)
                });
            }
            ViewBag.datos = data;
            ViewBag.message = message;
            ViewBag.solicitud = solicitud.id;
            ViewBag.direccion = direccion;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult NotificarEspServ(string[] correos, int idSolicitud, string direccion)
        {
            var solicitud = servData.Solicitud.Find(idSolicitud);
            var personaIncide = incideData.Persona.Where(x => x.ci == solicitud.carneId && x.exp == solicitud.exp_benef).SingleOrDefault();
            foreach (var item in correos)
            {
                 
                string subject = "Notificación de Solicitud Pendiente de Ejecución";
                string body = "";
                if (personaIncide != null)
                {
                    body = "Nueva solicitud de servicios del área " + incideData.Area.Find(personaIncide.id_area).descripcion + ". Revisar Adjunto.\nAtentamente,\nDepartamento de Informática.";
                }
                else
                {
                    body = "Nueva solicitud de servicios del área " + incideData.Area.First().descripcion + ". Revisar Adjunto.\nAtentamente,\nDepartamento de Informática.";
                }
                EmailSender.Sender(item, subject, body, direccion);
            }
            if (CurrentUser.Get.Role.Equals(ConfigurationManager.AppSettings.Get("11843472-ae59-423a-9ec4-6bca52a29b02")) || CurrentUser.Get.Role.Equals(ConfigurationManager.AppSettings.Get("8834006e-f16c-4f30-a924-ee00c2992b71")))
                return RedirectToAction("Index");
            else
                return RedirectToAction("Index", new { CurrentUser.Get.area });
        }
    }
}
