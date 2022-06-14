CREATE TABLE [PostCategory](
    [PostId] INT NOT NULL,
    [CategoryId] INT NOT NULL,

    CONSTRAINT [PK_PostCategory] PRIMARY KEY([PostId], [CategoryId])
)

INSERT INTO
    [User]
VALUES(
    'Guts from Berserk', 
    'guts@berserk.jp', 
    'easypass', 
    'Sou o protagonista do melhor seinen que existe', 
    'https://', 
    'guts-from-berserk'
) 

INSERT INTO
    [User]
VALUES(
    'Como usar o Azure Cloud', 
    'gutsss@berserk.jp', 
    'teste1', 
    'Sou o protagonista do melhor seinen que existe', 
    'https', 
    'comousar'
) 

SELECT * FROM [Category]

SELECT * FROM [Post]

INSERT INTO [Role] VALUES('Gerente do blog', 'gerente')

INSERT INTO [Tag] VALUES('VSCode', 'vscode')

INSERT INTO [UserRole] VALUES (1 , 1)

SELECT
    [Post].*,
    [Tag].*
FROM
    [Post]
    LEFT JOIN [PostTag] ON [PostTag].[PostId] = [Post].[Id]
    LEFT JOIN [Tag] ON [PostTag].[TagId] = [Tag].[Id]

SELECT
    [Tag].[Name],
    [Post].[Title]
FROM
    [Tag]
    INNER JOIN [PostTag] ON [PostTag].[TagId] = [Tag].[Id] 
    INNER JOIN [Post] ON [PostTag].[PostId] = [Post].[Id]

SELECT
    [Category].*,
    [Post].*
FROM
    [Category]
    LEFT JOIN [PostTag] ON [PostTag].[PostId] = [Post].[Id]
    LEFT JOIN [Tag] ON [PostTag].[TagId] = [Tag].[Id]
