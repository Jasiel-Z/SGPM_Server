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
    
    public partial class BeneficiarioSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BeneficiarioSet()
        {
            this.empresaSet = new HashSet<empresaSet>();
            this.PersonaSet = new HashSet<PersonaSet>();
        }
    
        public int idBeneficiario { get; set; }
        public string telefono { get; set; }
        public string ciudad { get; set; }
        public string calle { get; set; }
        public string numero { get; set; }
        public string rfc { get; set; }
        public Nullable<int> Localidad_IdLocalidad { get; set; }
        public Nullable<int> Solicitud_IdSolicitud { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<empresaSet> empresaSet { get; set; }
        public virtual LocalidadSet LocalidadSet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonaSet> PersonaSet { get; set; }
        public virtual SolicitudSet SolicitudSet { get; set; }
    }
}
