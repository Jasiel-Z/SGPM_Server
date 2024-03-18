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
    
    public partial class Proyecto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proyecto()
        {
            this.Solicitud = new HashSet<Solicitud>();
            this.PoliticaProyecto = new HashSet<PoliticaProyecto>();
        }
    
        public int Folio { get; set; }
        public string modalidad { get; set; }
        public string estado { get; set; }
        public string grupoAtencion { get; set; }
        public System.DateTime fechaFin { get; set; }
        public System.DateTime fechaLimiteEvidencia { get; set; }
        public System.DateTime fechaLimiteSolicitud { get; set; }
        public string tipo { get; set; }
        public int numeroBeneficiarios { get; set; }
        public int LocalidadDependenciaIdLocalidadDependencia { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Solicitud> Solicitud { get; set; }
        public virtual LocalidadDependencia LocalidadDependencia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PoliticaProyecto> PoliticaProyecto { get; set; }
        public virtual OrdenEntrega OrdenEntrega { get; set; }
    }
}
