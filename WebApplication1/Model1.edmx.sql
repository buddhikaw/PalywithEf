
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/22/2018 10:29:24
-- Generated from EDMX file: D:\dotnet\ef\WebApplication1\WebApplication1\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BuddhikasBattleField];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AppsEntityParticipants]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Participants] DROP CONSTRAINT [FK_AppsEntityParticipants];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AppsEntities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AppsEntities];
GO
IF OBJECT_ID(N'[dbo].[Participants]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Participants];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AppsEntities'
CREATE TABLE [dbo].[AppsEntities] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Status] nvarchar(max)  NOT NULL,
    [IsActive] bit  NULL,
    [AddedDate] datetime  NULL,
    [UdatedDate] datetime  NULL
);
GO

-- Creating table 'Participants'
CREATE TABLE [dbo].[Participants] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ParticipantName] nvarchar(max)  NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [IsActive] bit  NULL,
    [AddedDate] datetime  NULL,
    [UpdatedDate] datetime  NULL,
    [AppsEntity_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AppsEntities'
ALTER TABLE [dbo].[AppsEntities]
ADD CONSTRAINT [PK_AppsEntities]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Participants'
ALTER TABLE [dbo].[Participants]
ADD CONSTRAINT [PK_Participants]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AppsEntity_Id] in table 'Participants'
ALTER TABLE [dbo].[Participants]
ADD CONSTRAINT [FK_AppsEntityParticipants]
    FOREIGN KEY ([AppsEntity_Id])
    REFERENCES [dbo].[AppsEntities]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AppsEntityParticipants'
CREATE INDEX [IX_FK_AppsEntityParticipants]
ON [dbo].[Participants]
    ([AppsEntity_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------