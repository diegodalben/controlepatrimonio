USE Desafio
GO

CREATE OR ALTER PROCEDURE prc_Marca_Delete
(
    @MarcaId    INT
)
AS
BEGIN

    DELETE FROM dbo.Marca WHERE MarcaId = @MarcaId;

END
GO