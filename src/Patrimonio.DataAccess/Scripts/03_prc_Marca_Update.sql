USE Desafio
GO

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