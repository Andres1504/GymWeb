//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GymPrimerParcialWeb
{
    using System;
    using System.Collections.Generic;
    
    public partial class membresia
    {
        public int id_mem { get; set; }
        public System.DateTime fecha_pago { get; set; }
        public Nullable<bool> estatus_mem { get; set; }
        public System.DateTime fecha_fin_mem { get; set; }
        public Nullable<int> id_usu { get; set; }
        public Nullable<int> id_mes { get; set; }
        public Nullable<int> id_precio { get; set; }
    
        public virtual meses meses { get; set; }
        public virtual precios precios { get; set; }
        public virtual usuario usuario { get; set; }
    }
}