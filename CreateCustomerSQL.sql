USE [HybridDDDArchitecture]
GO

/****** Objeto: Table [dbo].[Customers] Fecha del script: 1/10/2024 18:50:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customers] (
    [Id]             NVARCHAR (255) NOT NULL,
    [CuilCuit]       NVARCHAR (11)  NULL,
    [DocumentNumber] NVARCHAR (8)   NULL,
    [Email]          NVARCHAR (256) NULL,
    [EmailConfirmed] BIT            NOT NULL,
    [FirstName]      NVARCHAR (100) NULL,
    [LastName]       NVARCHAR (100) NULL,
    [Status]         NVARCHAR (50)  NULL
);


