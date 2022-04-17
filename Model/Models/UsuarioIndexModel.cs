using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UsuarioIndexModel
    {
        public UsuarioIndexModel(string id, string UserName, string email, int exp, string area, string rol, bool activo)
        {
            this.id = id;
            this.UserName = UserName;
            this.email = email;
            this.exp = exp;
            this.area = area;
            this.rol = rol;
            this.activo = activo;

        }
        public string id { get; set; }
        [Display(Name = "Nombre")]
        public string UserName { get; set; }
        [Display(Name = "Correo")]
        public string email { get; set; }
        [Display(Name = "Expediente")]
        public int exp { get; set; }
        [Display(Name = "Área")]
        public string area { get; set; }
        [Display(Name = "Rol")]
        public string rol { get; set; }
        [Display(Name = "Activo")]
        public bool activo { get; set; }
    }
}
