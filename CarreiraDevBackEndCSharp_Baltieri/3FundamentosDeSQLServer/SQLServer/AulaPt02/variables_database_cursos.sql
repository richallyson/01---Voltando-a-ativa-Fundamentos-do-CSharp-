CREATE PROCEDURE [spListCourses] 
    @Category NVARCHAR(60), -- Parametro de entrada
    @Nome NVARCHAR(80)
AS
    DECLARE @CategoryId INT
    SET @CategoryId = (SELECT TOP 1 [Id] FROM [Categoria] WHERE [Nome] = @Category)

    SELECT * FROM [Curso] WHERE [CategoriaId] = @CategoryId

-- Quando você der o EXEC [NomeDaProcedure] vai dar erro, como ele espera um valor de entrada, vc deve passar ele
-- E para passar o valor de entrada você faz assim: EXEC [spListCourses] 'valor'
-- Aqui eu botei dois parametros, mas o segundo parametro mesmo sem nada ser feito nele, precisa ser recebido quando for fazer o exec da procedure
-- E lembrando que não é interessante deixar as regras de negócio numa procedure, mas sim no código c#, pois ele é testavel

