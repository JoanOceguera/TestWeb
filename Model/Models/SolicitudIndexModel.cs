using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class SolicitudIndexModel
    {
        public SolicitudIndexModel(int id, string nombre_solic, string nombre_benef, string validez, string area, string estado, DateTime fechaSolicitud, string tipoSolic)
        {
            this.id = id;
            this.nombre_solic = nombre_solic;
            this.nombre_benef = nombre_benef;
            this.validez = validez;
            this.area = area;
            this.estado = estado;
            this.fechaSolicitud = fechaSolicitud.ToString("dd/MM/yyyy");
            this.tipoSolic = tipoSolic;

        }
        [Display(Name = "#")]
        public int id { get; set; }
        [Display(Name = "Solicitante")]
        public string nombre_solic { get; set; }
        [Display(Name = "Beneficiado")]
        public string nombre_benef { get; set; }
        [Display(Name = "Validez")]
        public string validez { get; set; }
        [Display(Name = "Área")]
        public string area { get; set; }
        [Display(Name = "Estado")]
        public string estado { get; set; }
        [Display(Name = "Fecha de Solicitud")]
        public string fechaSolicitud { get; set; }
        [Display(Name = "Tipo de Solicitud")]
        public string tipoSolic { get; set; }


    }
}
