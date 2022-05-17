/* Nunca faça isso, pois isso retorta toda uma tabela. Imagina isso em um contexto gigante onde existem milhões de informações. Psé*/
SELECT * FROM [Curso]

/* Ao invés de fazer como acima, você pode fazer assim. Porém, ainda assim, usar o asterisco não é bom, pois ele acaba com a performance */
SELECT TOP 2 * FROM [Curso]

/* Ao invés de fazer como acima, você pode fazer assim. Essa Querry vai economizar muita performance, além de ficar mais organizada */
/* Se lembre de trazer as coisas que você quer sempre na ordem, pois isso também otimiza muitas coisas a frente */
SELECT TOP 2
    [Id], [Nome] 
FROM 
    [Curso]

/* O Distinct trás dados diferentes. Nessa nossa tabela temos a categoria backend repetidas vezes, porém com Id diferente. Se você passar o Id...*/
/* além no Select, ele vai trazer o outro backend tbm pelo fato da Id não ser igual. Porém, se trouxer apenas nomes, ele não irá trazer coisas repetidas */
SELECT DISTINCT TOP 100
    [Nome] 
FROM 
    [Categoria]

