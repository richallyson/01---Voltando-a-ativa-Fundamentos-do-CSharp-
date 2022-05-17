SELECT TOP 100
    [Id] AS [Codigo], -- ALIAS bota um apelido em algo
    [Nome],
    COUNT([Id]) AS TOTAL
FROM
    [Curso]

SELECT TOP 100
    COUNT([Id]) AS TOTAL
FROM
    [Curso]

SELECT TOP 100
    [Curso].[Id],
    [Curso].[Nome],
    [Categoria].[Id] AS [Categoria],
    [Categoria].[Nome]
FROM
    [Curso]
    INNER JOIN [Categoria] -- INNER JOIN é a intersecção. É tudo que existe em categoria e tudo que existe em curso
        ON [Curso].[CategoriaId] = [Categoria].[Id] -- Trás todos os cursos que tem uma categoria

SELECT TOP 100
    [Curso].[Id],
    [Curso].[Nome],
    [Categoria].[Id] AS [Categoria],
    [Categoria].[Nome]
FROM
    [Curso]
    LEFT JOIN [Categoria] -- LEFT JOIN retorna todos os cursos, e caso não existir ele retorna null
        ON [Curso].[CategoriaId] = [Categoria].[Id]

SELECT TOP 100
    [Curso].[Id],
    [Curso].[Nome],
    [Categoria].[Id] AS [Categoria],
    [Categoria].[Nome]
FROM
    [Curso]
    RIGHT JOIN [Categoria] -- RIGHT JOIN retorna todas as categorias, e se o curso existir
        ON [Curso].[CategoriaId] = [Categoria].[Id] 

SELECT TOP 100
    [Curso].[Id],
    [Curso].[Nome],
    [Categoria].[Id] AS [Categoria],
    [Categoria].[Nome]
FROM
    [Curso]
    FULL OUTER JOIN [Categoria] -- Vai executar tanto o do left quanto o do right
        ON [Curso].[CategoriaId] = [Categoria].[Id]

