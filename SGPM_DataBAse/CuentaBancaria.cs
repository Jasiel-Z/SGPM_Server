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
    
    public partial class CuentaBancaria
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CuentaBancaria()
        {
            this.CuentaBancariaSolicitud = new HashSet<CuentaBancariaSolicitud>();
        }
    
        public int numeroCuenta { get; set; }
        public string nombreTitular { get; set; }
        public string apellidoPaternoTitular { get; set; }
        public string apellidoMaternoTitular { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CuentaBancariaSolicitud> CuentaBancariaSolicitud { get; set; }
    }
}
