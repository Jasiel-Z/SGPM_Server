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
    
    public partial class CuentaBancariaSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CuentaBancariaSet()
        {
            this.CuentaBancariaSolicitudSet = new HashSet<CuentaBancariaSolicitudSet>();
        }
    
        public int numeroCuenta { get; set; }
        public string nombreTitular { get; set; }
        public string apellidoPaternoTitular { get; set; }
        public string apellidoMaternoTitular { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CuentaBancariaSolicitudSet> CuentaBancariaSolicitudSet { get; set; }
    }
}