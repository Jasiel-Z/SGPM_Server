﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SGPMEntities : DbContext
    {
        public SGPMEntities()
            : base("name=SGPMEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Beneficiarios> Beneficiarios { get; set; }
        public virtual DbSet<CuentasBancarias> CuentasBancarias { get; set; }
        public virtual DbSet<DependenciaLocalidad> DependenciaLocalidad { get; set; }
        public virtual DbSet<Dependencias> Dependencias { get; set; }
        public virtual DbSet<Devoluciones> Devoluciones { get; set; }
        public virtual DbSet<Dictamenes> Dictamenes { get; set; }
        public virtual DbSet<Documentos> Documentos { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<Empresas> Empresas { get; set; }
        public virtual DbSet<Evidencias> Evidencias { get; set; }
        public virtual DbSet<Localidades> Localidades { get; set; }
        public virtual DbSet<OrdenesEntrega> OrdenesEntrega { get; set; }
        public virtual DbSet<Personas> Personas { get; set; }
        public virtual DbSet<PoliticasOtorgamiento> PoliticasOtorgamiento { get; set; }
        public virtual DbSet<ProyectoPoliticaOtorgamiento> ProyectoPoliticaOtorgamiento { get; set; }
        public virtual DbSet<Proyectos> Proyectos { get; set; }
        public virtual DbSet<Recursos> Recursos { get; set; }
        public virtual DbSet<Solicitudes> Solicitudes { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
    }
}
