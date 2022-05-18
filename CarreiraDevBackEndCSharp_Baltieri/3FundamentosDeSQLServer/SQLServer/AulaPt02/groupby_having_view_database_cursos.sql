-- Depois de criar a view você pode chamar ela em outro canto, usando um select e chamando o nome da view
-- E ele vai rodar exatamente todo esse select abaixo da view. E quando vc chama a view pode executar um where, diferente desse select aqui que criamos
CREATE OR ALTER VIEW vwContagemCursosPorCategoria AS 
    SELECT TOP 100 
        [Categoria].[Id],
        [Categoria].[Nome],
        COUNT([Curso].[CategoriaId]) AS [Cursos]
    FROM 
        [Categoria]
        INNER JOIN [Curso] ON [Curso].[CategoriaId] = [Categoria].[Id]
    GROUP BY 
        [Categoria].[Id],
        [Categoria].[Nome],
        [Curso].[CategoriaId]
    HAVING
        COUNT([Curso].[CategoriaId]) > 1
