using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PersonaModel
    {
        public PersonaModel(int exp, string nombre, string apellido1, string apellido2)
        {
            this.exp = exp;
            this.nombre = nombre;
            this.apellido1 = apellido1;
            this.apellido2 = apellido2;

        }
        public int exp { get; set; }
        public string nombre { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
    }
}
