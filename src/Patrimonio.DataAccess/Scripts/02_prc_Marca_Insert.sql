USE Desafio
GO

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