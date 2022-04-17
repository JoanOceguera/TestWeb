using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ReporteServicioModel
    {

        public ReporteServicioModel()
        {
        }

        public ReporteServicioModel(int? exp, string nombre, string nombre_usuario, string area)
        {
            this.exp = exp;
            this.nombre = nombre;
            this.nombre_usuario = nombre_usuario;
            this.area = area;

        }

        [Display(Name = "Expediente")]
        public int? exp { get; set; }
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Usuario")]
        public string nombre_usuario { get; set; }
        [Display(Name = "Área")]
        public string area { get; set; }
    }
}
