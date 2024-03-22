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
    
    public partial class ProyectoSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProyectoSet()
        {
            this.PoliticaProyectoSet = new HashSet<PoliticaProyectoSet>();
            this.SolicitudSet = new HashSet<SolicitudSet>();
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
        public Nullable<int> OrdenEntrega_IdOrdenEntrega { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
    
        public virtual LocalidadDependenciaSet LocalidadDependenciaSet { get; set; }
        public virtual OrdenEntregaSet OrdenEntregaSet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PoliticaProyectoSet> PoliticaProyectoSet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SolicitudSet> SolicitudSet { get; set; }
    }
}
