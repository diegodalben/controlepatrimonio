USE Desafio
GO

CREATE OR ALTER PROCEDURE prc_Patrimonio_Delete
(
    @PatrimonioId    BIGINT
)
AS
BEGIN

    DELETE FROM dbo.Patrimonio WHERE PatrimonioId = @PatrimonioId;

END
GO