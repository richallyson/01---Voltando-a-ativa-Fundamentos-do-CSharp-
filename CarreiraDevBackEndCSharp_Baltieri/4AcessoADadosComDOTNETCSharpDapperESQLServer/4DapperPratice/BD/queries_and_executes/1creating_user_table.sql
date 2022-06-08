CREATE TABLE [User](
    [Id] INT NOT NULL IDENTITY(1, 1),
    [Name] NVARCHAR(80) NOT NULL, -- O NVARCHAR é usando quando você sabe que vai ter caracteres especiais, como acentos. Algo que foge do padrão unicode
    [Email] VARCHAR(200) NOT NULL, -- O VARCHAR é usando quando você sabe que não vai existir caracteres especiais dentro dele, que está dentro do padrão unicode
    [PasswordHash] VARCHAR(255) NOT NULL, -- Sempre iremos salvar a senha como uma hash, ela vai ser encripitada antes de salvar no banco
    [Bio] TEXT NOT NULL,
    [Image] VARCHAR(2000) NOT NULL,
    [Slug] VARCHAR(80) NOT NULL, -- Slug é a url do blog, tipo: blog.io/teste/fundamentos-csharp (essa parte final fundamentos-csharp é o slug)

    CONSTRAINT [PK_User] PRIMARY KEY ([Id]),
    CONSTRAINT [UQ_User_Email] UNIQUE ([Email]), -- UNIQUE ta implicito, que essas chaves são únicas. Não podem se repetir em nenhuma outra tabela
    CONSTRAINT [UQ_User_Slug] UNIQUE ([Slug])
)

-- Antes de explicar o que é INDEX ou NONCLUSTERED, primeiro precisamos saber o que é CLUSTERED
-- Um índice clusterizado determina a ordem em que as linhas de uma tabela são armazenadas no disco. Se uma tabela tem um índice clusterizado, no momento de um INSERT...
-- as linhas dessa tabela serão armazenadas em disco na ordem exata do mesmo índice.
-- Sendo assim, vale ressaltar que um INDICE CLUSTERIZADO normalmente são as chaves primarias das tabelas e eles ficam salvos de uma forma ordenada
-- No nosso caso, como usamos IDENTITY(1,1), nós teremos 1, 2, 3, 4... 
-- Na hora de realizar uma busca, pela Id de um usuário, que no nosso caso é a chave primaria, ele vai ser achado de forma mais fácil, mais rápida. 
-- O SQL salva dados em páginas, no formato páginado. Vamos supor que temos 10000 usuários, e queremos achar o usuário 500, o SQL vai dar uma busca dentro de um range próximo ao do nosso usuário, por exemplo, entre 400 e 500
-- Isso pode ser aplicado para UNIQUEIDENTIFIER, strings, etc
-- E por fim, uma PRIMARY KEY também é um indice, assim como as UNIQUE e FK

-- E depois de toda essa explicação, o que fazemos aqui abaixo, é apenas pedir para ser criad um indice para o email e pro slug, assim como foi criado para a PRIMARY KEY de forma automatica
-- Isso vai fazer com que seja gerado um novo registro no banco, uma nova "tabela", onde esses emails e slugs serão ordenados
-- E cada um desse aponta para um Id, sendo assim é muito mais fácil de se achar eles, devido a essa ordenação
-- Basicamente funciona como um Depara, que vimos no curso de Dapper. Depara é DE-PARA, no nosso caso DE [Id], PARA o [Email]. Ou seja, o email vai ser associado ao id em uma tabela depara, e a busca vai ficar suave de se realizar
-- DE: Id = 1; PARA: teste@gmail.com; Ou seja, o Id 1 vai ser assemelhado ao teste@gmail.com
CREATE NONCLUSTERED INDEX [IX_User_Email] ON [User]([Email])
CREATE NONCLUSTERED INDEX [IX_User_Slug] ON [User]([Slug])