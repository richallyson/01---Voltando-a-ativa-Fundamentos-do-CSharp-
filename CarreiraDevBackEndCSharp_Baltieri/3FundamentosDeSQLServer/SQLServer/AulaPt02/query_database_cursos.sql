-- Os comparadores são iguas os do C#, tirando o =, pois aqui ele compara e no C# ele atribui. Assim como o AND e o OR
-- SELECT TOP 100 
--    [Id], [Nome], [CategoriaId]
-- FROM
--    [Curso]
-- WHERE
--    [Id] = 1 AND
--    [CategoriaId] IS NOT NULL

SELECT TOP 100 
    [Id], [Nome], [CategoriaId]
FROM
    [Curso]
-- WHERE
--     [CategoriaId] = 1
ORDER BY
    --[Nome], [Id], [CategoriaId]
    [Nome] ASC -- ASCENDENTE ASC e DESCENTENDE DESC