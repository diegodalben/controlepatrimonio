USE Desafio
GO

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