//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Magios.Api.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inscripciones
    {
        public int IdInscripcion { get; set; }
        public string IdCampeonato { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string ClaseBarco { get; set; }
        public string NumeroVela { get; set; }
        public Nullable<System.DateTime> FechaAlta { get; set; }
    }
}
