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
    
    public partial class tarjeta
    {
        public string num_tar { get; set; }
        public string titular { get; set; }
        public string codigo { get; set; }
        public System.DateTime fecha_ven { get; set; }
        public Nullable<int> id_usu { get; set; }
    
        public virtual usuario usuario { get; set; }
    }
}