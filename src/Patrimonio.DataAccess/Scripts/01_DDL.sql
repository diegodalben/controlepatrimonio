IF NOT EXISTS(SELECT 1 FROM sys.databases WHERE name = 'Desafio')
    CREATE DATABASE Desafio;

USE Desafio
GO

IF NOT EXISTS(SELECT 1 FROM sys.tables WHERE name = 'Marca')
BEGIN
    CREATE TABLE dbo.Marca (
        MarcaId     INT IDENTITY    NOT NULL,
        Nome        VARCHAR(100)    NOT NULL
    )

    ALTER TABLE dbo.Marca ADD CONSTRAINT pk_MarcaId PRIMARY KEY(MarcaId)
END

IF NOT EXISTS(SELECT 1 FROM sys.tables WHERE name = 'Patrimonio')
BEGIN
    CREATE TABLE dbo.Patrimonio (
        PatrimonioId    BIGINT IDENTITY     NOT NULL,
        Nome            VARCHAR(100)        NOT NULL,
        MarcaId         INT                 NOT NULL,
        Descricao       VARCHAR(200)        NULL,
        NumTombo        INT                 NULL
    )

    ALTER TABLE dbo.Patrimonio ADD CONSTRAINT pk_PatrimonioId PRIMARY KEY(PatrimonioId)
    ALTER TABLE dbo.Patrimonio ADD CONSTRAINT fk_MarcaId FOREIGN KEY(MarcaId) REFERENCES dbo.Marca(MarcaId)
END