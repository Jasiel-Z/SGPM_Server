//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SGPM_DataBAse
{
    using System;
    using System.Collections.Generic;
    
    public partial class Personas
    {
        public int IdPersona { get; set; }
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string curp { get; set; }
        public Nullable<int> IdBeneficiario { get; set; }
    
        public virtual Beneficiarios Beneficiarios { get; set; }
    }
}