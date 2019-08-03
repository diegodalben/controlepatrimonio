USE Desafio
GO

CREATE OR ALTER PROCEDURE prc_Marca_GetAll
AS
BEGIN

    SELECT  MarcaId,
            Nome
    FROM dbo.Marca;

END
GO