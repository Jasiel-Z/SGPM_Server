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
    
    public partial class Archivo
    {
        public int idArchivo { get; set; }
        public string descripcion { get; set; }
        public int SolicitudIdSolicitud { get; set; }
        public string extension { get; set; }
        public byte[] contenido { get; set; }
        public string nombre { get; set; }
    
        public virtual Solicitud Solicitud { get; set; }
    }
}
