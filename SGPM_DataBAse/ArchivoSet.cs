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
    
    public partial class ArchivoSet
    {
        public int idArchivo { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> SolicitudIdSolicitud { get; set; }
        public string extension { get; set; }
        public byte[] contenido { get; set; }
        public string nombre { get; set; }
    
        public virtual SolicitudSet SolicitudSet { get; set; }
    }
}
