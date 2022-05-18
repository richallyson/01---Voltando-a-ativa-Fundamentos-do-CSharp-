SELECT TOP 100
    *
FROM
    [Curso]
WHERE
    [Nome] LIKE '%Fundamentos%' -- A palavra entre porcentagem significa contém. A porcentagem no fim significa começa com fundamentos, se ela estiver a esquerda, significa termina com fundamentos

SELECT TOP 100
    *
FROM
    [Curso]
WHERE
    [Id] IN (1 , 2,  3) -- O IN espera um array de valores, e retorna eles

SELECT TOP 100
    *
FROM
    [Curso]
WHERE
    [Id] IN (SELECT [Id] FROM [Categoria])

SELECT TOP 100
    *
FROM
    [Curso]
WHERE
    [Id] BETWEEN 1 AND 3 -- Between é entre. E lembrando que é sempre o tipo de dado, se fosse um DateTime, ao invés do inteiro eu passaria um DateTime [Id] BETWEEN '2020-03-01 00:00:00' AND '2020-03-31 23:59:00'