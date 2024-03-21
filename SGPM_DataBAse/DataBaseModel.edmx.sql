
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/21/2024 03:41:45
-- Generated from EDMX file: C:\Users\yusgu\Documents\UV\6to Semestre\D. Software\SGPM_Server\SGPM_DataBAse\DataBaseModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [master];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Beneficiarioempresa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[empresaSet] DROP CONSTRAINT [FK_Beneficiarioempresa];
GO
IF OBJECT_ID(N'[dbo].[FK_BeneficiarioLocalidad]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BeneficiarioSet] DROP CONSTRAINT [FK_BeneficiarioLocalidad];
GO
IF OBJECT_ID(N'[dbo].[FK_BeneficiarioPersona]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonaSet] DROP CONSTRAINT [FK_BeneficiarioPersona];
GO
IF OBJECT_ID(N'[dbo].[FK_BeneficiarioSolicitud]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BeneficiarioSet] DROP CONSTRAINT [FK_BeneficiarioSolicitud];
GO
IF OBJECT_ID(N'[dbo].[FK_CuentaBancariaSolicitudCuentaBancaria]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CuentaBancariaSolicitudSet] DROP CONSTRAINT [FK_CuentaBancariaSolicitudCuentaBancaria];
GO
IF OBJECT_ID(N'[dbo].[FK_DependenciaLocalidadDependencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LocalidadDependenciaSet] DROP CONSTRAINT [FK_DependenciaLocalidadDependencia];
GO
IF OBJECT_ID(N'[dbo].[FK_DictamenEmpleado]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DictamenSet] DROP CONSTRAINT [FK_DictamenEmpleado];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpleadoLocalidad]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmpleadoSet] DROP CONSTRAINT [FK_EmpleadoLocalidad];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpleadoUsuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmpleadoSet] DROP CONSTRAINT [FK_EmpleadoUsuario];
GO
IF OBJECT_ID(N'[dbo].[FK_LocalidadLocalidadDependencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LocalidadDependenciaSet] DROP CONSTRAINT [FK_LocalidadLocalidadDependencia];
GO
IF OBJECT_ID(N'[dbo].[FK_OrdenEntregaRecurso]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrdenEntregaSet] DROP CONSTRAINT [FK_OrdenEntregaRecurso];
GO
IF OBJECT_ID(N'[dbo].[FK_PoliticaOtorgamientoPoliticaProyecto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PoliticaProyectoSet] DROP CONSTRAINT [FK_PoliticaOtorgamientoPoliticaProyecto];
GO
IF OBJECT_ID(N'[dbo].[FK_PoliticaProyectoProyecto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PoliticaProyectoSet] DROP CONSTRAINT [FK_PoliticaProyectoProyecto];
GO
IF OBJECT_ID(N'[dbo].[FK_ProyectoLocalidadDependencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProyectoSet] DROP CONSTRAINT [FK_ProyectoLocalidadDependencia];
GO
IF OBJECT_ID(N'[dbo].[FK_ProyectoOrdenEntrega]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProyectoSet] DROP CONSTRAINT [FK_ProyectoOrdenEntrega];
GO
IF OBJECT_ID(N'[dbo].[FK_SolicitudArchivo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ArchivoSet] DROP CONSTRAINT [FK_SolicitudArchivo];
GO
IF OBJECT_ID(N'[dbo].[FK_SolicitudCuentaBancariaSolicitud]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CuentaBancariaSolicitudSet] DROP CONSTRAINT [FK_SolicitudCuentaBancariaSolicitud];
GO
IF OBJECT_ID(N'[dbo].[FK_SolicitudDevoluciones]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DevolucionesSet] DROP CONSTRAINT [FK_SolicitudDevoluciones];
GO
IF OBJECT_ID(N'[dbo].[FK_SolicitudDictamen]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SolicitudSet] DROP CONSTRAINT [FK_SolicitudDictamen];
GO
IF OBJECT_ID(N'[dbo].[FK_SolicitudProyecto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SolicitudSet] DROP CONSTRAINT [FK_SolicitudProyecto];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ArchivoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ArchivoSet];
GO
IF OBJECT_ID(N'[dbo].[BeneficiarioSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BeneficiarioSet];
GO
IF OBJECT_ID(N'[dbo].[CuentaBancariaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CuentaBancariaSet];
GO
IF OBJECT_ID(N'[dbo].[CuentaBancariaSolicitudSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CuentaBancariaSolicitudSet];
GO
IF OBJECT_ID(N'[dbo].[DependenciaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DependenciaSet];
GO
IF OBJECT_ID(N'[dbo].[DevolucionesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DevolucionesSet];
GO
IF OBJECT_ID(N'[dbo].[DictamenSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DictamenSet];
GO
IF OBJECT_ID(N'[dbo].[EmpleadoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmpleadoSet];
GO
IF OBJECT_ID(N'[dbo].[empresaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[empresaSet];
GO
IF OBJECT_ID(N'[dbo].[LocalidadDependenciaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LocalidadDependenciaSet];
GO
IF OBJECT_ID(N'[dbo].[LocalidadSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LocalidadSet];
GO
IF OBJECT_ID(N'[dbo].[OrdenEntregaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrdenEntregaSet];
GO
IF OBJECT_ID(N'[dbo].[PersonaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonaSet];
GO
IF OBJECT_ID(N'[dbo].[PoliticaOtorgamientoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PoliticaOtorgamientoSet];
GO
IF OBJECT_ID(N'[dbo].[PoliticaProyectoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PoliticaProyectoSet];
GO
IF OBJECT_ID(N'[dbo].[ProyectoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProyectoSet];
GO
IF OBJECT_ID(N'[dbo].[RecursoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RecursoSet];
GO
IF OBJECT_ID(N'[dbo].[SolicitudSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SolicitudSet];
GO
IF OBJECT_ID(N'[dbo].[UsuarioSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsuarioSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ArchivoSet'
CREATE TABLE [dbo].[ArchivoSet] (
    [idArchivo] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL,
    [SolicitudIdSolicitud] int  NULL,
    [extension] nvarchar(max)  NOT NULL,
    [contenido] varbinary(max)  NOT NULL,
    [nombre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'BeneficiarioSet'
CREATE TABLE [dbo].[BeneficiarioSet] (
    [idBeneficiario] int IDENTITY(1,1) NOT NULL,
    [telefono] nvarchar(max)  NOT NULL,
    [ciudad] nvarchar(max)  NOT NULL,
    [calle] nvarchar(max)  NOT NULL,
    [numero] nvarchar(max)  NOT NULL,
    [rfc] nvarchar(max)  NOT NULL,
    [Localidad_IdLocalidad] int  NULL,
    [Solicitud_IdSolicitud] int  NULL
);
GO

-- Creating table 'CuentaBancariaSet'
CREATE TABLE [dbo].[CuentaBancariaSet] (
    [numeroCuenta] int IDENTITY(1,1) NOT NULL,
    [nombreTitular] nvarchar(max)  NOT NULL,
    [apellidoPaternoTitular] nvarchar(max)  NOT NULL,
    [apellidoMaternoTitular] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CuentaBancariaSolicitudSet'
CREATE TABLE [dbo].[CuentaBancariaSolicitudSet] (
    [IdCuentaBancariaSolicitud] int IDENTITY(1,1) NOT NULL,
    [SolicitudIdSolicitud] int  NOT NULL,
    [CuentaBancaria_numeroCuenta] int  NOT NULL
);
GO

-- Creating table 'DependenciaSet'
CREATE TABLE [dbo].[DependenciaSet] (
    [IdDependencia] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DevolucionesSet'
CREATE TABLE [dbo].[DevolucionesSet] (
    [IdDevolucion] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL,
    [fechaDevolucion] datetime  NOT NULL,
    [fechaLimite] datetime  NOT NULL,
    [montoDeuda] int  NOT NULL,
    [SolicitudIdSolicitud] int  NOT NULL
);
GO

-- Creating table 'DictamenSet'
CREATE TABLE [dbo].[DictamenSet] (
    [IdDictamen] int IDENTITY(1,1) NOT NULL,
    [estado] nvarchar(max)  NOT NULL,
    [comentarios] nvarchar(max)  NOT NULL,
    [fecha] datetime  NOT NULL,
    [EmpleadoNumeroEmpleado] int  NOT NULL
);
GO

-- Creating table 'EmpleadoSet'
CREATE TABLE [dbo].[EmpleadoSet] (
    [NumeroEmpleado] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [apellidoPaterno] nvarchar(max)  NOT NULL,
    [apellidoMaterno] nvarchar(max)  NOT NULL,
    [rol] nvarchar(max)  NOT NULL,
    [telefono] nvarchar(max)  NOT NULL,
    [ciudad] nvarchar(max)  NOT NULL,
    [calle] nvarchar(max)  NOT NULL,
    [numero] int  NOT NULL,
    [LocalidadIdLocalidad] int  NOT NULL,
    [Usuario_IdUsuario] int  NOT NULL
);
GO

-- Creating table 'empresaSet'
CREATE TABLE [dbo].[empresaSet] (
    [idBeneficiario] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [Beneficiario_idBeneficiario] int  NULL
);
GO

-- Creating table 'LocalidadDependenciaSet'
CREATE TABLE [dbo].[LocalidadDependenciaSet] (
    [IdLocalidadDependencia] int IDENTITY(1,1) NOT NULL,
    [LocalidadIdLocalidad] int  NOT NULL,
    [DependenciaIdDependencia] int  NOT NULL
);
GO

-- Creating table 'LocalidadSet'
CREATE TABLE [dbo].[LocalidadSet] (
    [IdLocalidad] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'OrdenEntregaSet'
CREATE TABLE [dbo].[OrdenEntregaSet] (
    [IdOrdenEntrega] int IDENTITY(1,1) NOT NULL,
    [fechaEntrega] datetime  NOT NULL,
    [lugarEntrega] nvarchar(max)  NOT NULL,
    [Recurso_IdRecurso] int  NOT NULL
);
GO

-- Creating table 'PersonaSet'
CREATE TABLE [dbo].[PersonaSet] (
    [idBeneficiario] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [apellidoPaterno] nvarchar(max)  NOT NULL,
    [apellidoMaterno] nvarchar(max)  NOT NULL,
    [curp] nvarchar(max)  NOT NULL,
    [Beneficiario_idBeneficiario] int  NOT NULL
);
GO

-- Creating table 'PoliticaOtorgamientoSet'
CREATE TABLE [dbo].[PoliticaOtorgamientoSet] (
    [IdPolitica] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PoliticaProyectoSet'
CREATE TABLE [dbo].[PoliticaProyectoSet] (
    [IdPoliticaProyecto] int IDENTITY(1,1) NOT NULL,
    [ProyectoFolio] int  NULL,
    [PoliticaOtorgamientoIdPolitica] int  NULL
);
GO

-- Creating table 'ProyectoSet'
CREATE TABLE [dbo].[ProyectoSet] (
    [Folio] int IDENTITY(1,1) NOT NULL,
    [modalidad] nvarchar(max)  NOT NULL,
    [estado] nvarchar(max)  NOT NULL,
    [grupoAtencion] nvarchar(max)  NOT NULL,
    [fechaFin] datetime  NOT NULL,
    [fechaLimiteEvidencia] datetime  NOT NULL,
    [fechaLimiteSolicitud] datetime  NOT NULL,
    [tipo] nvarchar(max)  NOT NULL,
    [numeroBeneficiarios] int  NOT NULL,
    [LocalidadDependenciaIdLocalidadDependencia] int  NOT NULL,
    [OrdenEntrega_IdOrdenEntrega] int  NULL
);
GO

-- Creating table 'RecursoSet'
CREATE TABLE [dbo].[RecursoSet] (
    [IdRecurso] int IDENTITY(1,1) NOT NULL,
    [concepto] nvarchar(max)  NOT NULL,
    [valor] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SolicitudSet'
CREATE TABLE [dbo].[SolicitudSet] (
    [IdSolicitud] int IDENTITY(1,1) NOT NULL,
    [estado] nvarchar(max)  NOT NULL,
    [fechaCreacion] datetime  NOT NULL,
    [ProyectoFolio] int  NOT NULL,
    [Dictamen_IdDictamen] int  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'UsuarioSet'
CREATE TABLE [dbo].[UsuarioSet] (
    [IdUsuario] int IDENTITY(1,1) NOT NULL,
    [correo] nvarchar(max)  NOT NULL,
    [contrasena] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [idArchivo] in table 'ArchivoSet'
ALTER TABLE [dbo].[ArchivoSet]
ADD CONSTRAINT [PK_ArchivoSet]
    PRIMARY KEY CLUSTERED ([idArchivo] ASC);
GO

-- Creating primary key on [idBeneficiario] in table 'BeneficiarioSet'
ALTER TABLE [dbo].[BeneficiarioSet]
ADD CONSTRAINT [PK_BeneficiarioSet]
    PRIMARY KEY CLUSTERED ([idBeneficiario] ASC);
GO

-- Creating primary key on [numeroCuenta] in table 'CuentaBancariaSet'
ALTER TABLE [dbo].[CuentaBancariaSet]
ADD CONSTRAINT [PK_CuentaBancariaSet]
    PRIMARY KEY CLUSTERED ([numeroCuenta] ASC);
GO

-- Creating primary key on [IdCuentaBancariaSolicitud] in table 'CuentaBancariaSolicitudSet'
ALTER TABLE [dbo].[CuentaBancariaSolicitudSet]
ADD CONSTRAINT [PK_CuentaBancariaSolicitudSet]
    PRIMARY KEY CLUSTERED ([IdCuentaBancariaSolicitud] ASC);
GO

-- Creating primary key on [IdDependencia] in table 'DependenciaSet'
ALTER TABLE [dbo].[DependenciaSet]
ADD CONSTRAINT [PK_DependenciaSet]
    PRIMARY KEY CLUSTERED ([IdDependencia] ASC);
GO

-- Creating primary key on [IdDevolucion] in table 'DevolucionesSet'
ALTER TABLE [dbo].[DevolucionesSet]
ADD CONSTRAINT [PK_DevolucionesSet]
    PRIMARY KEY CLUSTERED ([IdDevolucion] ASC);
GO

-- Creating primary key on [IdDictamen] in table 'DictamenSet'
ALTER TABLE [dbo].[DictamenSet]
ADD CONSTRAINT [PK_DictamenSet]
    PRIMARY KEY CLUSTERED ([IdDictamen] ASC);
GO

-- Creating primary key on [NumeroEmpleado] in table 'EmpleadoSet'
ALTER TABLE [dbo].[EmpleadoSet]
ADD CONSTRAINT [PK_EmpleadoSet]
    PRIMARY KEY CLUSTERED ([NumeroEmpleado] ASC);
GO

-- Creating primary key on [idBeneficiario] in table 'empresaSet'
ALTER TABLE [dbo].[empresaSet]
ADD CONSTRAINT [PK_empresaSet]
    PRIMARY KEY CLUSTERED ([idBeneficiario] ASC);
GO

-- Creating primary key on [IdLocalidadDependencia] in table 'LocalidadDependenciaSet'
ALTER TABLE [dbo].[LocalidadDependenciaSet]
ADD CONSTRAINT [PK_LocalidadDependenciaSet]
    PRIMARY KEY CLUSTERED ([IdLocalidadDependencia] ASC);
GO

-- Creating primary key on [IdLocalidad] in table 'LocalidadSet'
ALTER TABLE [dbo].[LocalidadSet]
ADD CONSTRAINT [PK_LocalidadSet]
    PRIMARY KEY CLUSTERED ([IdLocalidad] ASC);
GO

-- Creating primary key on [IdOrdenEntrega] in table 'OrdenEntregaSet'
ALTER TABLE [dbo].[OrdenEntregaSet]
ADD CONSTRAINT [PK_OrdenEntregaSet]
    PRIMARY KEY CLUSTERED ([IdOrdenEntrega] ASC);
GO

-- Creating primary key on [idBeneficiario] in table 'PersonaSet'
ALTER TABLE [dbo].[PersonaSet]
ADD CONSTRAINT [PK_PersonaSet]
    PRIMARY KEY CLUSTERED ([idBeneficiario] ASC);
GO

-- Creating primary key on [IdPolitica] in table 'PoliticaOtorgamientoSet'
ALTER TABLE [dbo].[PoliticaOtorgamientoSet]
ADD CONSTRAINT [PK_PoliticaOtorgamientoSet]
    PRIMARY KEY CLUSTERED ([IdPolitica] ASC);
GO

-- Creating primary key on [IdPoliticaProyecto] in table 'PoliticaProyectoSet'
ALTER TABLE [dbo].[PoliticaProyectoSet]
ADD CONSTRAINT [PK_PoliticaProyectoSet]
    PRIMARY KEY CLUSTERED ([IdPoliticaProyecto] ASC);
GO

-- Creating primary key on [Folio] in table 'ProyectoSet'
ALTER TABLE [dbo].[ProyectoSet]
ADD CONSTRAINT [PK_ProyectoSet]
    PRIMARY KEY CLUSTERED ([Folio] ASC);
GO

-- Creating primary key on [IdRecurso] in table 'RecursoSet'
ALTER TABLE [dbo].[RecursoSet]
ADD CONSTRAINT [PK_RecursoSet]
    PRIMARY KEY CLUSTERED ([IdRecurso] ASC);
GO

-- Creating primary key on [IdSolicitud] in table 'SolicitudSet'
ALTER TABLE [dbo].[SolicitudSet]
ADD CONSTRAINT [PK_SolicitudSet]
    PRIMARY KEY CLUSTERED ([IdSolicitud] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [IdUsuario] in table 'UsuarioSet'
ALTER TABLE [dbo].[UsuarioSet]
ADD CONSTRAINT [PK_UsuarioSet]
    PRIMARY KEY CLUSTERED ([IdUsuario] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [SolicitudIdSolicitud] in table 'ArchivoSet'
ALTER TABLE [dbo].[ArchivoSet]
ADD CONSTRAINT [FK_SolicitudArchivo]
    FOREIGN KEY ([SolicitudIdSolicitud])
    REFERENCES [dbo].[SolicitudSet]
        ([IdSolicitud])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SolicitudArchivo'
CREATE INDEX [IX_FK_SolicitudArchivo]
ON [dbo].[ArchivoSet]
    ([SolicitudIdSolicitud]);
GO

-- Creating foreign key on [Beneficiario_idBeneficiario] in table 'empresaSet'
ALTER TABLE [dbo].[empresaSet]
ADD CONSTRAINT [FK_Beneficiarioempresa]
    FOREIGN KEY ([Beneficiario_idBeneficiario])
    REFERENCES [dbo].[BeneficiarioSet]
        ([idBeneficiario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Beneficiarioempresa'
CREATE INDEX [IX_FK_Beneficiarioempresa]
ON [dbo].[empresaSet]
    ([Beneficiario_idBeneficiario]);
GO

-- Creating foreign key on [Localidad_IdLocalidad] in table 'BeneficiarioSet'
ALTER TABLE [dbo].[BeneficiarioSet]
ADD CONSTRAINT [FK_BeneficiarioLocalidad]
    FOREIGN KEY ([Localidad_IdLocalidad])
    REFERENCES [dbo].[LocalidadSet]
        ([IdLocalidad])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BeneficiarioLocalidad'
CREATE INDEX [IX_FK_BeneficiarioLocalidad]
ON [dbo].[BeneficiarioSet]
    ([Localidad_IdLocalidad]);
GO

-- Creating foreign key on [Beneficiario_idBeneficiario] in table 'PersonaSet'
ALTER TABLE [dbo].[PersonaSet]
ADD CONSTRAINT [FK_BeneficiarioPersona]
    FOREIGN KEY ([Beneficiario_idBeneficiario])
    REFERENCES [dbo].[BeneficiarioSet]
        ([idBeneficiario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BeneficiarioPersona'
CREATE INDEX [IX_FK_BeneficiarioPersona]
ON [dbo].[PersonaSet]
    ([Beneficiario_idBeneficiario]);
GO

-- Creating foreign key on [Solicitud_IdSolicitud] in table 'BeneficiarioSet'
ALTER TABLE [dbo].[BeneficiarioSet]
ADD CONSTRAINT [FK_BeneficiarioSolicitud]
    FOREIGN KEY ([Solicitud_IdSolicitud])
    REFERENCES [dbo].[SolicitudSet]
        ([IdSolicitud])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BeneficiarioSolicitud'
CREATE INDEX [IX_FK_BeneficiarioSolicitud]
ON [dbo].[BeneficiarioSet]
    ([Solicitud_IdSolicitud]);
GO

-- Creating foreign key on [CuentaBancaria_numeroCuenta] in table 'CuentaBancariaSolicitudSet'
ALTER TABLE [dbo].[CuentaBancariaSolicitudSet]
ADD CONSTRAINT [FK_CuentaBancariaSolicitudCuentaBancaria]
    FOREIGN KEY ([CuentaBancaria_numeroCuenta])
    REFERENCES [dbo].[CuentaBancariaSet]
        ([numeroCuenta])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CuentaBancariaSolicitudCuentaBancaria'
CREATE INDEX [IX_FK_CuentaBancariaSolicitudCuentaBancaria]
ON [dbo].[CuentaBancariaSolicitudSet]
    ([CuentaBancaria_numeroCuenta]);
GO

-- Creating foreign key on [SolicitudIdSolicitud] in table 'CuentaBancariaSolicitudSet'
ALTER TABLE [dbo].[CuentaBancariaSolicitudSet]
ADD CONSTRAINT [FK_SolicitudCuentaBancariaSolicitud]
    FOREIGN KEY ([SolicitudIdSolicitud])
    REFERENCES [dbo].[SolicitudSet]
        ([IdSolicitud])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SolicitudCuentaBancariaSolicitud'
CREATE INDEX [IX_FK_SolicitudCuentaBancariaSolicitud]
ON [dbo].[CuentaBancariaSolicitudSet]
    ([SolicitudIdSolicitud]);
GO

-- Creating foreign key on [DependenciaIdDependencia] in table 'LocalidadDependenciaSet'
ALTER TABLE [dbo].[LocalidadDependenciaSet]
ADD CONSTRAINT [FK_DependenciaLocalidadDependencia]
    FOREIGN KEY ([DependenciaIdDependencia])
    REFERENCES [dbo].[DependenciaSet]
        ([IdDependencia])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DependenciaLocalidadDependencia'
CREATE INDEX [IX_FK_DependenciaLocalidadDependencia]
ON [dbo].[LocalidadDependenciaSet]
    ([DependenciaIdDependencia]);
GO

-- Creating foreign key on [SolicitudIdSolicitud] in table 'DevolucionesSet'
ALTER TABLE [dbo].[DevolucionesSet]
ADD CONSTRAINT [FK_SolicitudDevoluciones]
    FOREIGN KEY ([SolicitudIdSolicitud])
    REFERENCES [dbo].[SolicitudSet]
        ([IdSolicitud])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SolicitudDevoluciones'
CREATE INDEX [IX_FK_SolicitudDevoluciones]
ON [dbo].[DevolucionesSet]
    ([SolicitudIdSolicitud]);
GO

-- Creating foreign key on [EmpleadoNumeroEmpleado] in table 'DictamenSet'
ALTER TABLE [dbo].[DictamenSet]
ADD CONSTRAINT [FK_DictamenEmpleado]
    FOREIGN KEY ([EmpleadoNumeroEmpleado])
    REFERENCES [dbo].[EmpleadoSet]
        ([NumeroEmpleado])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DictamenEmpleado'
CREATE INDEX [IX_FK_DictamenEmpleado]
ON [dbo].[DictamenSet]
    ([EmpleadoNumeroEmpleado]);
GO

-- Creating foreign key on [Dictamen_IdDictamen] in table 'SolicitudSet'
ALTER TABLE [dbo].[SolicitudSet]
ADD CONSTRAINT [FK_SolicitudDictamen]
    FOREIGN KEY ([Dictamen_IdDictamen])
    REFERENCES [dbo].[DictamenSet]
        ([IdDictamen])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SolicitudDictamen'
CREATE INDEX [IX_FK_SolicitudDictamen]
ON [dbo].[SolicitudSet]
    ([Dictamen_IdDictamen]);
GO

-- Creating foreign key on [LocalidadIdLocalidad] in table 'EmpleadoSet'
ALTER TABLE [dbo].[EmpleadoSet]
ADD CONSTRAINT [FK_EmpleadoLocalidad]
    FOREIGN KEY ([LocalidadIdLocalidad])
    REFERENCES [dbo].[LocalidadSet]
        ([IdLocalidad])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpleadoLocalidad'
CREATE INDEX [IX_FK_EmpleadoLocalidad]
ON [dbo].[EmpleadoSet]
    ([LocalidadIdLocalidad]);
GO

-- Creating foreign key on [Usuario_IdUsuario] in table 'EmpleadoSet'
ALTER TABLE [dbo].[EmpleadoSet]
ADD CONSTRAINT [FK_EmpleadoUsuario]
    FOREIGN KEY ([Usuario_IdUsuario])
    REFERENCES [dbo].[UsuarioSet]
        ([IdUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpleadoUsuario'
CREATE INDEX [IX_FK_EmpleadoUsuario]
ON [dbo].[EmpleadoSet]
    ([Usuario_IdUsuario]);
GO

-- Creating foreign key on [LocalidadIdLocalidad] in table 'LocalidadDependenciaSet'
ALTER TABLE [dbo].[LocalidadDependenciaSet]
ADD CONSTRAINT [FK_LocalidadLocalidadDependencia]
    FOREIGN KEY ([LocalidadIdLocalidad])
    REFERENCES [dbo].[LocalidadSet]
        ([IdLocalidad])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LocalidadLocalidadDependencia'
CREATE INDEX [IX_FK_LocalidadLocalidadDependencia]
ON [dbo].[LocalidadDependenciaSet]
    ([LocalidadIdLocalidad]);
GO

-- Creating foreign key on [LocalidadDependenciaIdLocalidadDependencia] in table 'ProyectoSet'
ALTER TABLE [dbo].[ProyectoSet]
ADD CONSTRAINT [FK_ProyectoLocalidadDependencia]
    FOREIGN KEY ([LocalidadDependenciaIdLocalidadDependencia])
    REFERENCES [dbo].[LocalidadDependenciaSet]
        ([IdLocalidadDependencia])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProyectoLocalidadDependencia'
CREATE INDEX [IX_FK_ProyectoLocalidadDependencia]
ON [dbo].[ProyectoSet]
    ([LocalidadDependenciaIdLocalidadDependencia]);
GO

-- Creating foreign key on [Recurso_IdRecurso] in table 'OrdenEntregaSet'
ALTER TABLE [dbo].[OrdenEntregaSet]
ADD CONSTRAINT [FK_OrdenEntregaRecurso]
    FOREIGN KEY ([Recurso_IdRecurso])
    REFERENCES [dbo].[RecursoSet]
        ([IdRecurso])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrdenEntregaRecurso'
CREATE INDEX [IX_FK_OrdenEntregaRecurso]
ON [dbo].[OrdenEntregaSet]
    ([Recurso_IdRecurso]);
GO

-- Creating foreign key on [OrdenEntrega_IdOrdenEntrega] in table 'ProyectoSet'
ALTER TABLE [dbo].[ProyectoSet]
ADD CONSTRAINT [FK_ProyectoOrdenEntrega]
    FOREIGN KEY ([OrdenEntrega_IdOrdenEntrega])
    REFERENCES [dbo].[OrdenEntregaSet]
        ([IdOrdenEntrega])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProyectoOrdenEntrega'
CREATE INDEX [IX_FK_ProyectoOrdenEntrega]
ON [dbo].[ProyectoSet]
    ([OrdenEntrega_IdOrdenEntrega]);
GO

-- Creating foreign key on [PoliticaOtorgamientoIdPolitica] in table 'PoliticaProyectoSet'
ALTER TABLE [dbo].[PoliticaProyectoSet]
ADD CONSTRAINT [FK_PoliticaOtorgamientoPoliticaProyecto]
    FOREIGN KEY ([PoliticaOtorgamientoIdPolitica])
    REFERENCES [dbo].[PoliticaOtorgamientoSet]
        ([IdPolitica])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PoliticaOtorgamientoPoliticaProyecto'
CREATE INDEX [IX_FK_PoliticaOtorgamientoPoliticaProyecto]
ON [dbo].[PoliticaProyectoSet]
    ([PoliticaOtorgamientoIdPolitica]);
GO

-- Creating foreign key on [ProyectoFolio] in table 'PoliticaProyectoSet'
ALTER TABLE [dbo].[PoliticaProyectoSet]
ADD CONSTRAINT [FK_PoliticaProyectoProyecto]
    FOREIGN KEY ([ProyectoFolio])
    REFERENCES [dbo].[ProyectoSet]
        ([Folio])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PoliticaProyectoProyecto'
CREATE INDEX [IX_FK_PoliticaProyectoProyecto]
ON [dbo].[PoliticaProyectoSet]
    ([ProyectoFolio]);
GO

-- Creating foreign key on [ProyectoFolio] in table 'SolicitudSet'
ALTER TABLE [dbo].[SolicitudSet]
ADD CONSTRAINT [FK_SolicitudProyecto]
    FOREIGN KEY ([ProyectoFolio])
    REFERENCES [dbo].[ProyectoSet]
        ([Folio])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SolicitudProyecto'
CREATE INDEX [IX_FK_SolicitudProyecto]
ON [dbo].[SolicitudSet]
    ([ProyectoFolio]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------