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
    
    public partial class PoliticaProyecto
    {
        public int IdPoliticaProyecto { get; set; }
        public int ProyectoFolio { get; set; }
        public int PoliticaOtorgamientoIdPolitica { get; set; }
    
        public virtual Proyecto Proyecto { get; set; }
        public virtual PoliticaOtorgamiento PoliticaOtorgamiento { get; set; }
    }
}
