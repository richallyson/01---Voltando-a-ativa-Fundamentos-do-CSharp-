-- Um STORE PROCEDURE é um trecho de código que pode ser chamado depois para ser executado
CREATE PROCEDURE [spListCourses] AS
    SELECT [Nome] FROM [Curso]

-- Para chamar uma procedure em outro .sql você deve usar o EXEC [NomeDaProcedure]
-- Não é interessante deixar regras de negócio em uma procedure

-- E caso queira dropar uma procedure é só fazer como abaixo
DROP PROCEDURE [spListCourses]