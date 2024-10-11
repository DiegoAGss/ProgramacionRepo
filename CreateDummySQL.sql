USE [HybridDDDArchitecture]
GO

/****** Objeto: Table [dbo].[DummyEntity] Fecha del script: 1/10/2024 18:51:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[DummyEntity] (
    [Id]                 INT           IDENTITY (1, 1) NOT NULL,
    [DummyPropertyTwo]   VARCHAR (255) NULL,
    [DummyPropertyThree] INT           NULL
);


