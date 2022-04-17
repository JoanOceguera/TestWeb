using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PlanillaViewModel
    {
        public PlanillaViewModel()
        {

        }

        public PlanillaViewModel(string nombre_benef, string apellido1_benef, string apellido2_benef,
            string area, string cargo_benef, int exp, string tpersonal, string rolpc, IDictionary<int, string> servicios,
            string nombre_usuario, string razonDesh, DateTime fechaInicio, DateTime fechaFin, string tipoSolic,
            string nombre_solic, string cargo_solic)
        {
            this.nombre_benef = nombre_benef;
            this.apellido1_benef = apellido1_benef;
            this.apellido2_benef = apellido2_benef;
            this.area = area;
            this.cargo_benef = cargo_benef;
            this.exp = exp;
            this.tpersonal = tpersonal;
            this.rolpc = rolpc;
            this.servicios = servicios;
            this.nombre_usuario = nombre_usuario;
            this.razonDesh = razonDesh;
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.tipoSolic = tipoSolic;
            this.nombre_solic = nombre_solic;
            this.cargo_solic = cargo_solic;
        }

        public int id_solic { get; set; }
        public string nombre_benef { get; set; }
        public string apellido1_benef { get; set; }
        public string apellido2_benef { get; set; }
        public string area { get; set; }
        public string cargo_benef { get; set; }
        public int exp { get; set; }
        public string tpersonal { get; set; }
        public string rolpc { get; set; }
        public IDictionary<int, string> servicios { get; set; }
        public string nombre_usuario { get; set; }
        public string razonDesh { get; set; }
        public DateTime? fechaInicio { get; set; }
        public DateTime? fechaFin { get; set; }
        public string tipoSolic { get; set; }
        public DateTime? validez { get; set; }
        public string nombre_solic { get; set; }
        public string cargo_solic { get; set; }
        public string carneId { get; set; }
        public DateTime? fechaSolicitud { get; set; }
        public DateTime? fechaAprobacion { get; set; }
        public DateTime? fechaEjecucion { get; set; }
        public string estado { get; set; }
        public string usuario { get; set; }
        public string cargoUsuario { get; set; }

    }
}
