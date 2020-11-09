
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/06/2020 20:48:32
-- Generated from EDMX file: C:\Users\gagan\source\repos\test2\test2\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Database1];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Patients'
CREATE TABLE [dbo].[Patients] (
    [Id] int  NOT NULL,
    [FirsttName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [DOB] datetime  NOT NULL,
    [PId] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Doctors'
CREATE TABLE [dbo].[Doctors] (
    [Id] int  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [DOB] datetime  NOT NULL,
    [DoctorId] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Consultations'
CREATE TABLE [dbo].[Consultations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PatientId] nvarchar(max)  NOT NULL,
    [DoctorId] nvarchar(max)  NOT NULL,
    [PatientId1] int  NOT NULL,
    [DoctorId1] int  NOT NULL
);
GO

-- Creating table 'Reviews'
CREATE TABLE [dbo].[Reviews] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PatientId] nvarchar(max)  NOT NULL,
    [DoctorId] nvarchar(max)  NOT NULL,
    [PatientId1] int  NOT NULL,
    [DoctorId1] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Patients'
ALTER TABLE [dbo].[Patients]
ADD CONSTRAINT [PK_Patients]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Doctors'
ALTER TABLE [dbo].[Doctors]
ADD CONSTRAINT [PK_Doctors]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Consultations'
ALTER TABLE [dbo].[Consultations]
ADD CONSTRAINT [PK_Consultations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Reviews'
ALTER TABLE [dbo].[Reviews]
ADD CONSTRAINT [PK_Reviews]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PatientId1] in table 'Consultations'
ALTER TABLE [dbo].[Consultations]
ADD CONSTRAINT [FK_PatientConsultation]
    FOREIGN KEY ([PatientId1])
    REFERENCES [dbo].[Patients]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PatientConsultation'
CREATE INDEX [IX_FK_PatientConsultation]
ON [dbo].[Consultations]
    ([PatientId1]);
GO

-- Creating foreign key on [PatientId1] in table 'Reviews'
ALTER TABLE [dbo].[Reviews]
ADD CONSTRAINT [FK_PatientReview]
    FOREIGN KEY ([PatientId1])
    REFERENCES [dbo].[Patients]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PatientReview'
CREATE INDEX [IX_FK_PatientReview]
ON [dbo].[Reviews]
    ([PatientId1]);
GO

-- Creating foreign key on [DoctorId1] in table 'Consultations'
ALTER TABLE [dbo].[Consultations]
ADD CONSTRAINT [FK_DoctorConsultation]
    FOREIGN KEY ([DoctorId1])
    REFERENCES [dbo].[Doctors]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DoctorConsultation'
CREATE INDEX [IX_FK_DoctorConsultation]
ON [dbo].[Consultations]
    ([DoctorId1]);
GO

-- Creating foreign key on [DoctorId1] in table 'Reviews'
ALTER TABLE [dbo].[Reviews]
ADD CONSTRAINT [FK_DoctorReview]
    FOREIGN KEY ([DoctorId1])
    REFERENCES [dbo].[Doctors]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DoctorReview'
CREATE INDEX [IX_FK_DoctorReview]
ON [dbo].[Reviews]
    ([DoctorId1]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------