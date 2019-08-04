IF NOT EXISTS(SELECT 1 FROM sys.databases WHERE name = 'Desafio')
BEGIN
    CREATE DATABASE Desafio;
END
GO

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
GO

-- ==========================================================================================================================================

CREATE OR ALTER PROCEDURE prc_Marca_Insert
(
    @Nome       VARCHAR(100),
    @MarcaId    INT OUTPUT
)
AS
BEGIN

    INSERT INTO dbo.Marca VALUES(@Nome);

    SET @MarcaId = SCOPE_IDENTITY();

END
GO

-- ==========================================================================================================================================

CREATE OR ALTER PROCEDURE prc_Marca_Update
(
    @MarcaId    INT,
    @Nome       VARCHAR(100)
)
AS
BEGIN

    UPDATE dbo.Marca 
        SET Nome = @Nome 
    WHERE MarcaId = @MarcaId;

END
GO

-- ==========================================================================================================================================

CREATE OR ALTER PROCEDURE prc_Marca_Delete
(
    @MarcaId    INT
)
AS
BEGIN

    DELETE FROM dbo.Marca WHERE MarcaId = @MarcaId;

END
GO

-- ==========================================================================================================================================

CREATE OR ALTER PROCEDURE prc_Marca_GetAll
AS
BEGIN

    SELECT  MarcaId,
            Nome
    FROM dbo.Marca;

END
GO

-- ==========================================================================================================================================

CREATE OR ALTER PROCEDURE prc_Marca_GetById
(
    @MarcaId    INT
)
AS
BEGIN

    SELECT  MarcaId,
            Nome
    FROM dbo.Marca
    WHERE MarcaId = @MarcaId;

END
GO

-- ==========================================================================================================================================

CREATE OR ALTER PROCEDURE prc_Patrimonio_Insert
(
    @Nome            VARCHAR(100),
    @MarcaId         INT,
    @Descricao       VARCHAR(200) = NULL,
    @NumTombo        INT = NULL,
    @PatrimonioId    BIGINT OUTPUT
)
AS
BEGIN

    INSERT INTO dbo.Patrimonio VALUES
    (
        @Nome,
        @MarcaId,
        @Descricao,
        @NumTombo
    );

    SET @PatrimonioId = SCOPE_IDENTITY();

END
GO

-- ==========================================================================================================================================

CREATE OR ALTER PROCEDURE prc_Patrimonio_Update
(
    @PatrimonioId    BIGINT,
    @Nome            VARCHAR(100),
    @MarcaId         INT,
    @Descricao       VARCHAR(200) = NULL
)
AS
BEGIN

    UPDATE dbo.Patrimonio
        SET Nome = @Nome,
            MarcaId = @MarcaId,
            Descricao = @Descricao
    WHERE PatrimonioId = @PatrimonioId;

END
GO

-- ==========================================================================================================================================

CREATE OR ALTER PROCEDURE prc_Patrimonio_Delete
(
    @PatrimonioId    BIGINT
)
AS
BEGIN

    DELETE FROM dbo.Patrimonio WHERE PatrimonioId = @PatrimonioId;

END
GO

-- ==========================================================================================================================================

CREATE OR ALTER PROCEDURE prc_Patrimonio_GetAll
AS
BEGIN

    SELECT  p.PatrimonioId,
            p.Nome,
            p.MarcaId,
            m.Nome AS 'MarcaNome',
            p.Descricao,
            p.NumTombo 
    FROM dbo.Patrimonio p
    INNER JOIN dbo.Marca m ON m.MarcaId = p.MarcaId;

END
GO

-- ==========================================================================================================================================

CREATE OR ALTER PROCEDURE prc_Patrimonio_GetById
(
    @PatrimonioId   BIGINT
)
AS
BEGIN

    SELECT  p.PatrimonioId,
            p.Nome,
            p.MarcaId,
            m.Nome AS 'MarcaNome',
            p.Descricao,
            p.NumTombo 
    FROM dbo.Patrimonio p
    INNER JOIN dbo.Marca m ON m.MarcaId = p.MarcaId
    WHERE p.PatrimonioId = @PatrimonioId;

END
GO

-- ==========================================================================================================================================

CREATE OR ALTER PROCEDURE prc_Patrimonio_GetByMarca
(
    @MarcaId   INT
)
AS
BEGIN

    SELECT  p.PatrimonioId,
            p.Nome,
            p.MarcaId,
            m.Nome AS 'MarcaNome',
            p.Descricao,
            p.NumTombo 
    FROM dbo.Patrimonio p
    INNER JOIN dbo.Marca m ON m.MarcaId = p.MarcaId
    WHERE p.MarcaId = @MarcaId;

END
GO

-- ==========================================================================================================================================

CREATE OR ALTER PROCEDURE dbo.prc_Marca_GetByName
(
    @Nome    VARCHAR(100)
)
AS
BEGIN

    SELECT  MarcaId,
            Nome
    FROM dbo.Marca
    WHERE Nome = @Nome;

END
GO