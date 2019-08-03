USE Desafio
GO

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