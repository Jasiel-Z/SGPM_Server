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
    
    public partial class Proyectos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proyectos()
        {
            this.ProyectoPoliticaOtorgamiento = new HashSet<ProyectoPoliticaOtorgamiento>();
            this.Solicitudes = new HashSet<Solicitudes>();
        }
    
        public string Folio { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }
        public string grupoAtencion { get; set; }
        public string modalidad { get; set; }
        public string tipo { get; set; }
        public Nullable<double> montoApoyo { get; set; }
        public Nullable<int> numeroBeneficiarios { get; set; }
        public Nullable<System.DateTime> fechaInicio { get; set; }
        public Nullable<System.DateTime> fechaLimiteSolicitudes { get; set; }
        public Nullable<System.DateTime> fechaFin { get; set; }
        public Nullable<System.DateTime> fechaLimiteEvidencias { get; set; }
        public Nullable<int> IdDependencia { get; set; }
        public Nullable<int> IdOrdenEntrega { get; set; }
    
        public virtual Dependencias Dependencias { get; set; }
        public virtual OrdenesEntrega OrdenesEntrega { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProyectoPoliticaOtorgamiento> ProyectoPoliticaOtorgamiento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Solicitudes> Solicitudes { get; set; }
    }
}