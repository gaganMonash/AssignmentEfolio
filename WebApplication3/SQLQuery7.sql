CREATE TABLE [dbo].[Patients] (
    [Id]        NVARCHAR (MAX) NOT NULL,
    [FirstName] NVARCHAR (MAX) NOT NULL,
    [LastName]  NVARCHAR (MAX) NOT NULL,
    [EmailId]   NVARCHAR (MAX) NOT NULL,
    [DOB]       DATETIME       NOT NULL,
    [PatientId] INT IDENTITY(1,1) 
);

