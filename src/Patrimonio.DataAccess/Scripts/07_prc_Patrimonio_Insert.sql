USE Desafio
GO

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