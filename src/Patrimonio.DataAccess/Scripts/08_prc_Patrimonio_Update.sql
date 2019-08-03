USE Desafio
GO

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