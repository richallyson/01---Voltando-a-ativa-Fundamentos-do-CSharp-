-- Role é perfil. Um User pode ter diversos perfis, assim como também só um. E o Role pode estar presente em diveros usuários
-- A relação entre essas duas entidades é de muitos para muitos

CREATE TABLE [UserRole](
    [UserId] INT NOT NULL,
    [RoleId] INT NOT NULL,

    CONSTRAINT [PK_UserRole] PRIMARY KEY ([UserId], [RoleId])
)