using System;
using System.Collections.Generic;
using System.Linq;
using FunYCon;
using Model.Entities;


namespace Model
{
    public class SolicitudtoPlanilla
    {
        private static IncideEntities incideData = new IncideEntities();
        private static RecursosHumanosEntities rhData = new RecursosHumanosEntities();
        private static ServiciosEntities servData = new ServiciosEntities();

        public SolicitudtoPlanilla()
        {

        }
        public static PlanillaViewModel solicitudToPlanilla (Solicitud solicitud)
        {

            PlanillaViewModel planilla = new PlanillaViewModel();
            planilla.id_solic = solicitud.id;
            IDictionary<int, string> servicios = new Dictionary<int, string>();
            foreach (var item in solicitud.Servicios)
            {
                servicios.Add(item.id, item.nombre);
            }
            planilla.servicios = servicios;
            var persona = incideData.Persona.Where(x => x.ci == solicitud.carneId && x.exp == solicitud.exp_benef).SingleOrDefault();
            int jefe = 0;
            int ExpJefe = 0;
            string carnetJefe = "";
            if (persona != null)
            {
                planilla.area = persona.Area1.descripcion;
                jefe = (int)persona.Area1.Persona_jefe;
                ExpJefe = incideData.Persona.Find(jefe).exp;
                carnetJefe = incideData.Persona.Find(jefe).ci;
            }
            else
            {
                jefe = (int)incideData.Area.First().Persona_jefe;
                ExpJefe = incideData.Persona.Find(jefe).exp;
                carnetJefe = incideData.Persona.Find(jefe).ci;
                planilla.area = incideData.Area.First().descripcion;
            }           

            if (solicitud.suspencion_inicio != null)
                planilla.fechaInicio = (DateTime) solicitud.suspencion_inicio;
            else
                planilla.fechaInicio = solicitud.suspencion_inicio;

            if (solicitud.suspencion_fin != null)
                planilla.fechaFin = (DateTime)solicitud.suspencion_fin;
            else
                planilla.fechaFin = solicitud.suspencion_fin;

            if (solicitud.validez != null)
                planilla.validez = (DateTime)solicitud.validez;
            else
                planilla.validez = solicitud.validez;

            planilla.tipoSolic = solicitud.tsolic;
            planilla.tpersonal = solicitud.tpers;
            planilla.rolpc = solicitud.rolpc;
            planilla.razonDesh = solicitud.razon_suspencion;

            if (solicitud.exp_benef != null)
            {
                planilla.exp =  (int) solicitud.exp_benef;
                var personaRHBeneficiado = rhData.Personal.Where(x => x.Exp == solicitud.exp_benef && x.CarneId == solicitud.carneId).ToList();
                if (!personaRHBeneficiado.Any())
                {

                    var personaBajasBeneficiado = rhData.BajasPers.ToList().Where(x => x.Exp == solicitud.exp_benef && x.CarneId.Equals(solicitud.carneId));
                    if (personaBajasBeneficiado.Any())
                    {
                        var personaBenef = personaBajasBeneficiado.FirstOrDefault();
                        planilla.nombre_benef = TConeccion.Revisar_Ort(personaBenef.Nombre);
                        planilla.apellido1_benef = TConeccion.Revisar_Ort(personaBenef.Apellido1);
                        planilla.apellido2_benef = TConeccion.Revisar_Ort(personaBenef.Apellido2);
                        var plantillaRhBene = rhData.BajaPlantilla.Find(personaBenef.IdPlaza);
                        var plazaRhBene = rhData.Plazas.Find(plantillaRhBene.Ocupacion);
                        planilla.cargo_benef = TConeccion.Revisar_Ort(plazaRhBene.Nom_Ocup);
                    }
                    else
                    {
                        planilla.nombre_benef = "";
                        planilla.apellido1_benef = "";
                        planilla.apellido2_benef = "";
                        planilla.cargo_benef = "";
                    }
                    
                }
                else
                {
                    planilla.nombre_benef = TConeccion.Revisar_Ort(personaRHBeneficiado.First().Nombre);
                    planilla.apellido1_benef = TConeccion.Revisar_Ort(personaRHBeneficiado.First().Apellido1);
                    planilla.apellido2_benef = TConeccion.Revisar_Ort(personaRHBeneficiado.First().Apellido2);
                    var plantillaRhBene = rhData.Plantilla.Find(personaRHBeneficiado.First().IdPlaza);
                    var plazaRhBene = rhData.Plazas.Find(plantillaRhBene.Ocupacion);
                    planilla.cargo_benef = TConeccion.Revisar_Ort(plazaRhBene.Nom_Ocup);
                }

            }

            var personaRHSolicitante = rhData.Personal.Where(x => x.Exp == ExpJefe && x.CarneId.Equals(carnetJefe)).ToList();
            if (!personaRHSolicitante.Any())
            {
                var personaBajasSolicitante = rhData.BajasPers.ToList().Where(x => x.Exp == ExpJefe && x.CarneId.Equals(carnetJefe)).FirstOrDefault();
                planilla.nombre_solic = TConeccion.Revisar_Ort(personaBajasSolicitante.Nombre + ' ' + personaBajasSolicitante.Apellido1 + ' ' + personaBajasSolicitante.Apellido2);
                var plantillaRhSolic = rhData.BajaPlantilla.Find(personaBajasSolicitante.IdPlaza);
                var plazaRHSolic = rhData.Plazas.Find(plantillaRhSolic.Ocupacion);
                planilla.cargo_solic = TConeccion.Revisar_Ort(plazaRHSolic.Nom_Ocup);
            }
            else
            {
                planilla.nombre_solic = TConeccion.Revisar_Ort(personaRHSolicitante.First().Nombre + ' ' + personaRHSolicitante.First().Apellido1 + ' ' + personaRHSolicitante.First().Apellido2);
                var plantillaRhSolic = rhData.Plantilla.Find(personaRHSolicitante.First().IdPlaza);
                var plazaRHSolic = rhData.Plazas.Find(plantillaRhSolic.Ocupacion);
                planilla.cargo_solic = TConeccion.Revisar_Ort(plazaRHSolic.Nom_Ocup);
            }

            planilla.nombre_usuario = solicitud.nombre_usuario;
            planilla.carneId = solicitud.carneId;
            if (solicitud.fecha_aprobacion != null)
            {
                planilla.fechaAprobacion = (DateTime)solicitud.fecha_aprobacion;
            }
            else
                planilla.fechaAprobacion = solicitud.fecha_aprobacion;
            if (solicitud.fecha_ejecucion != null)
            {
                planilla.fechaEjecucion = (DateTime)solicitud.fecha_ejecucion;
            }
            else
                planilla.fechaEjecucion = solicitud.fecha_ejecucion;
            planilla.fechaSolicitud = solicitud.fecha_solicitud;
            planilla.estado = solicitud.estado;

            return planilla;
        }
    }
}
