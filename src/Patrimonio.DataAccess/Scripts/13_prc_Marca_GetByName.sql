USE Desafio
GO

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
