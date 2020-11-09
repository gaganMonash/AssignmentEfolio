

CREATE TABLE [dbo].[Consultations] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [PatientId] NVARCHAR (MAX) NOT NULL,
    [DoctorId]  NVARCHAR (MAX) NOT NULL,
    [Date]      Date  NOT NULL,
    [Issue]     NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Consultations] PRIMARY KEY CLUSTERED ([Id] ASC)
);
