//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
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
