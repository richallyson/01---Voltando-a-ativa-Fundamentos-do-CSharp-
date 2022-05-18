SELECT * FROM [Categoria]

-- Utilizavel apenas quando se quer executar poucos updates
-- Bom para realizar testes
BEGIN TRANSACTION
    UPDATE
        [Categoria]
    SET 
        [Nome] = 'BackEnd'
    WHERE -- Se não botar o WHERE depois do Set, ele vai alterar todos os campos escolhidos da tabela selecionada
        [Id] = 1
-- ROLLBACK Usar rollback antes do commit, para você analisar quantas linhas foram afetadas, vendo que é exatamente o tanto que você esperava, lasca o commit
COMMIT

UPDATE
    [Categoria]
SET 
    [Nome] = 'Azure'
WHERE 
    [Id] = 4

-- Para dar DELETE em algo que está sendo referênciado, você deve primeiro deletar essa coluna que usa a outra como referência
-- Sempre usar o Id para o DELETE pois como ele é único, evita falhas
DELETE FROM
    [Categoria]
WHERE
    [Id] = 2
