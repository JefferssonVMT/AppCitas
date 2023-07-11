
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/08/2023 21:08:18
-- Generated from EDMX file: C:\Users\Jeffersson V\Desktop\CitasSalonApp - copia - copia - copia\CitasSalonApp\Models\CitasModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CitasApp];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ClienteEstadoCliente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Clientes] DROP CONSTRAINT [FK_ClienteEstadoCliente];
GO
IF OBJECT_ID(N'[dbo].[FK_CitaEstadoCita]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Citas] DROP CONSTRAINT [FK_CitaEstadoCita];
GO
IF OBJECT_ID(N'[dbo].[FK_ServicioTipoServicio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Servicios] DROP CONSTRAINT [FK_ServicioTipoServicio];
GO
IF OBJECT_ID(N'[dbo].[FK_CitaServicio]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Citas] DROP CONSTRAINT [FK_CitaServicio];
GO
IF OBJECT_ID(N'[dbo].[FK_CitaCliente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Citas] DROP CONSTRAINT [FK_CitaCliente];
GO
IF OBJECT_ID(N'[dbo].[FK_HoraDetalleFechaBloque]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleFechaBloques] DROP CONSTRAINT [FK_HoraDetalleFechaBloque];
GO
IF OBJECT_ID(N'[dbo].[FK_FechaDetalleFechaBloque]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleFechaBloques] DROP CONSTRAINT [FK_FechaDetalleFechaBloque];
GO
IF OBJECT_ID(N'[dbo].[FK_CitaDetalleFechaBloque]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Citas] DROP CONSTRAINT [FK_CitaDetalleFechaBloque];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalleFechaBloqueEstadoHorario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalleFechaBloques] DROP CONSTRAINT [FK_DetalleFechaBloqueEstadoHorario];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Clientes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clientes];
GO
IF OBJECT_ID(N'[dbo].[Citas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Citas];
GO
IF OBJECT_ID(N'[dbo].[TipoServicios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TipoServicios];
GO
IF OBJECT_ID(N'[dbo].[Servicios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Servicios];
GO
IF OBJECT_ID(N'[dbo].[EstadoCitas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EstadoCitas];
GO
IF OBJECT_ID(N'[dbo].[EstadoClientes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EstadoClientes];
GO
IF OBJECT_ID(N'[dbo].[Fechas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Fechas];
GO
IF OBJECT_ID(N'[dbo].[EstadoHorarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EstadoHorarios];
GO
IF OBJECT_ID(N'[dbo].[Horas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Horas];
GO
IF OBJECT_ID(N'[dbo].[DetalleFechaBloques]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalleFechaBloques];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Clientes'
CREATE TABLE [dbo].[Clientes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [apellido] nvarchar(max)  NOT NULL,
    [correo] nvarchar(max)  NOT NULL,
    [telefono] nvarchar(max)  NOT NULL,
    [edad] smallint  NOT NULL,
    [EstadoCliente_Id] int  NOT NULL
);
GO

-- Creating table 'Citas'
CREATE TABLE [dbo].[Citas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL,
    [numero_deposito] nvarchar(max)  NOT NULL,
    [EstadoCita_Id] int  NOT NULL,
    [Servicio_Id] int  NOT NULL,
    [Cliente_Id] int  NOT NULL,
    [DetalleFechaBloque_Id] int  NOT NULL
);
GO

-- Creating table 'TipoServicios'
CREATE TABLE [dbo].[TipoServicios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Servicios'
CREATE TABLE [dbo].[Servicios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [TipoServicio_Id] int  NOT NULL
);
GO

-- Creating table 'EstadoCitas'
CREATE TABLE [dbo].[EstadoCitas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EstadoClientes'
CREATE TABLE [dbo].[EstadoClientes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Fechas'
CREATE TABLE [dbo].[Fechas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [año] smallint  NOT NULL,
    [mes] smallint  NOT NULL,
    [dia] smallint  NOT NULL
);
GO

-- Creating table 'EstadoHorarios'
CREATE TABLE [dbo].[EstadoHorarios] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Horas'
CREATE TABLE [dbo].[Horas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [bloque] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DetalleFechaBloques'
CREATE TABLE [dbo].[DetalleFechaBloques] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [HoraId] int  NOT NULL,
    [FechaId] int  NOT NULL,
    [EstadoHorario_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Clientes'
ALTER TABLE [dbo].[Clientes]
ADD CONSTRAINT [PK_Clientes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Citas'
ALTER TABLE [dbo].[Citas]
ADD CONSTRAINT [PK_Citas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TipoServicios'
ALTER TABLE [dbo].[TipoServicios]
ADD CONSTRAINT [PK_TipoServicios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Servicios'
ALTER TABLE [dbo].[Servicios]
ADD CONSTRAINT [PK_Servicios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EstadoCitas'
ALTER TABLE [dbo].[EstadoCitas]
ADD CONSTRAINT [PK_EstadoCitas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EstadoClientes'
ALTER TABLE [dbo].[EstadoClientes]
ADD CONSTRAINT [PK_EstadoClientes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Fechas'
ALTER TABLE [dbo].[Fechas]
ADD CONSTRAINT [PK_Fechas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EstadoHorarios'
ALTER TABLE [dbo].[EstadoHorarios]
ADD CONSTRAINT [PK_EstadoHorarios]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Horas'
ALTER TABLE [dbo].[Horas]
ADD CONSTRAINT [PK_Horas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DetalleFechaBloques'
ALTER TABLE [dbo].[DetalleFechaBloques]
ADD CONSTRAINT [PK_DetalleFechaBloques]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EstadoCliente_Id] in table 'Clientes'
ALTER TABLE [dbo].[Clientes]
ADD CONSTRAINT [FK_ClienteEstadoCliente]
    FOREIGN KEY ([EstadoCliente_Id])
    REFERENCES [dbo].[EstadoClientes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteEstadoCliente'
CREATE INDEX [IX_FK_ClienteEstadoCliente]
ON [dbo].[Clientes]
    ([EstadoCliente_Id]);
GO

-- Creating foreign key on [EstadoCita_Id] in table 'Citas'
ALTER TABLE [dbo].[Citas]
ADD CONSTRAINT [FK_CitaEstadoCita]
    FOREIGN KEY ([EstadoCita_Id])
    REFERENCES [dbo].[EstadoCitas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CitaEstadoCita'
CREATE INDEX [IX_FK_CitaEstadoCita]
ON [dbo].[Citas]
    ([EstadoCita_Id]);
GO

-- Creating foreign key on [TipoServicio_Id] in table 'Servicios'
ALTER TABLE [dbo].[Servicios]
ADD CONSTRAINT [FK_ServicioTipoServicio]
    FOREIGN KEY ([TipoServicio_Id])
    REFERENCES [dbo].[TipoServicios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ServicioTipoServicio'
CREATE INDEX [IX_FK_ServicioTipoServicio]
ON [dbo].[Servicios]
    ([TipoServicio_Id]);
GO

-- Creating foreign key on [Servicio_Id] in table 'Citas'
ALTER TABLE [dbo].[Citas]
ADD CONSTRAINT [FK_CitaServicio]
    FOREIGN KEY ([Servicio_Id])
    REFERENCES [dbo].[Servicios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CitaServicio'
CREATE INDEX [IX_FK_CitaServicio]
ON [dbo].[Citas]
    ([Servicio_Id]);
GO

-- Creating foreign key on [Cliente_Id] in table 'Citas'
ALTER TABLE [dbo].[Citas]
ADD CONSTRAINT [FK_CitaCliente]
    FOREIGN KEY ([Cliente_Id])
    REFERENCES [dbo].[Clientes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CitaCliente'
CREATE INDEX [IX_FK_CitaCliente]
ON [dbo].[Citas]
    ([Cliente_Id]);
GO

-- Creating foreign key on [HoraId] in table 'DetalleFechaBloques'
ALTER TABLE [dbo].[DetalleFechaBloques]
ADD CONSTRAINT [FK_HoraDetalleFechaBloque]
    FOREIGN KEY ([HoraId])
    REFERENCES [dbo].[Horas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HoraDetalleFechaBloque'
CREATE INDEX [IX_FK_HoraDetalleFechaBloque]
ON [dbo].[DetalleFechaBloques]
    ([HoraId]);
GO

-- Creating foreign key on [FechaId] in table 'DetalleFechaBloques'
ALTER TABLE [dbo].[DetalleFechaBloques]
ADD CONSTRAINT [FK_FechaDetalleFechaBloque]
    FOREIGN KEY ([FechaId])
    REFERENCES [dbo].[Fechas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FechaDetalleFechaBloque'
CREATE INDEX [IX_FK_FechaDetalleFechaBloque]
ON [dbo].[DetalleFechaBloques]
    ([FechaId]);
GO

-- Creating foreign key on [EstadoHorario_Id] in table 'DetalleFechaBloques'
ALTER TABLE [dbo].[DetalleFechaBloques]
ADD CONSTRAINT [FK_DetalleFechaBloqueEstadoHorario]
    FOREIGN KEY ([EstadoHorario_Id])
    REFERENCES [dbo].[EstadoHorarios]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalleFechaBloqueEstadoHorario'
CREATE INDEX [IX_FK_DetalleFechaBloqueEstadoHorario]
ON [dbo].[DetalleFechaBloques]
    ([EstadoHorario_Id]);
GO

-- Creating foreign key on [DetalleFechaBloque_Id] in table 'Citas'
ALTER TABLE [dbo].[Citas]
ADD CONSTRAINT [FK_CitaDetalleFechaBloque]
    FOREIGN KEY ([DetalleFechaBloque_Id])
    REFERENCES [dbo].[DetalleFechaBloques]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CitaDetalleFechaBloque'
CREATE INDEX [IX_FK_CitaDetalleFechaBloque]
ON [dbo].[Citas]
    ([DetalleFechaBloque_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------