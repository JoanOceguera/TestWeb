//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Personal
    {
        public int Exp { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string CarneId { get; set; }
        public string Direccion { get; set; }
        public short Mpio { get; set; }
        public short Provincia { get; set; }
        public string Pais { get; set; }
        public byte Sucursal { get; set; }
        public string Telefono { get; set; }
        public string Clasificacion { get; set; }
        public Nullable<short> Profesion { get; set; }
        public byte CategOcup { get; set; }
        public Nullable<byte> CategDoc { get; set; }
        public Nullable<byte> CategCient { get; set; }
        public Nullable<byte> CategTecno { get; set; }
        public Nullable<short> GradoCient { get; set; }
        public Nullable<byte> Especialidad { get; set; }
        public Nullable<byte> CategBTecno { get; set; }
        public string Militancia { get; set; }
        public string Curriculum { get; set; }
        public short IdPlaza { get; set; }
        public System.DateTime Alta { get; set; }
        public string Foto { get; set; }
        public string Contrata { get; set; }
        public Nullable<byte> Cargo { get; set; }
        public Nullable<decimal> Antiguedad { get; set; }
        public Nullable<decimal> ContabilidadC { get; set; }
        public Nullable<decimal> Dirigente { get; set; }
        public Nullable<decimal> GCientifico { get; set; }
        public Nullable<decimal> GElectrogeno { get; set; }
        public string Fotolector { get; set; }
        public Nullable<short> EstudiosTerminados { get; set; }
        public string Raza { get; set; }
        public byte[] FotoImg { get; set; }
    
        public virtual Plantilla Plantilla { get; set; }
    }
}
