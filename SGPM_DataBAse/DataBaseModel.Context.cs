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
    
    public partial class DataBaseModelContainer : DbContext
    {
        public DataBaseModelContainer()
            : base("name=DataBaseModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ArchivoSet> ArchivoSet { get; set; }
        public virtual DbSet<BeneficiarioSet> BeneficiarioSet { get; set; }
        public virtual DbSet<CuentaBancariaSet> CuentaBancariaSet { get; set; }
        public virtual DbSet<CuentaBancariaSolicitudSet> CuentaBancariaSolicitudSet { get; set; }
        public virtual DbSet<DependenciaSet> DependenciaSet { get; set; }
        public virtual DbSet<DevolucionesSet> DevolucionesSet { get; set; }
        public virtual DbSet<DictamenSet> DictamenSet { get; set; }
        public virtual DbSet<EmpleadoSet> EmpleadoSet { get; set; }
        public virtual DbSet<empresaSet> empresaSet { get; set; }
        public virtual DbSet<LocalidadDependenciaSet> LocalidadDependenciaSet { get; set; }
        public virtual DbSet<LocalidadSet> LocalidadSet { get; set; }
        public virtual DbSet<OrdenEntregaSet> OrdenEntregaSet { get; set; }
        public virtual DbSet<PersonaSet> PersonaSet { get; set; }
        public virtual DbSet<PoliticaOtorgamientoSet> PoliticaOtorgamientoSet { get; set; }
        public virtual DbSet<PoliticaProyectoSet> PoliticaProyectoSet { get; set; }
        public virtual DbSet<ProyectoSet> ProyectoSet { get; set; }
        public virtual DbSet<RecursoSet> RecursoSet { get; set; }
        public virtual DbSet<SolicitudSet> SolicitudSet { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<UsuarioSet> UsuarioSet { get; set; }
    }
}