using System;
using System.Collections.Generic;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            // Tabela
            builder.ToTable("Post");

            // Primary Key and Identity
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Props
            builder.Property(x => x.Title)
                .IsRequired()
                .HasColumnName("Title")
                .HasColumnType("VARCHAR")
                .HasMaxLength(160);

            builder.Property(x => x.Summary)
                .IsRequired()
                .HasColumnName("Summary")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.Body)
                .IsRequired()
                .HasColumnName("Body")
                .HasColumnType("TEXT");

            builder.Property(x => x.Slug)
                .IsRequired()
                .HasColumnName("Slug")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);
            builder.HasIndex(x => x.Slug, "IX_Post_Slug")
                .IsUnique();

            // DEFAULT VALUES
            // Tanto o CreateDate quanto o LastUpdateDate tem um valor padrão, que no sql se refere a DATETIME NOT NULL DEFAULT(GETDATE())
            // A constraint SQL DEFAULT é uma constraint que pode ser adicionada às tabelas para especificar um valor padrão para uma coluna. 
            // O valor padrão é usado para o valor da coluna quando um não é especificado (por exemplo, quando você insere uma linha na tabela sem especificar um valor para a coluna).
            // Os valores padrão podem ser NULL ou podem ser um valor que corresponda ao tipo de dados da coluna (número, texto, data, por exemplo). No nosso caso, o tipo é o DATETIME
            // E como a gente faz pra colocar isso aqui no nosso mapeamento? É colocado através do .HasDefaultValueSql("GETDATE()")
            // O .HasDefaultValueSql("GETDATE()") gera o valor no SqLServer. O GETDATE() é uma função do SqlServer e não do Csharp
            // Então, se você quiser usar o GETDATE() do SqlServer ou qualquer função que seja no SqlServer, você usa o .HasDefaultValueSql()
            // Ele basicamente informa que você quer executar a função que você passa como parametro no SqLServer
            // Porém, é mais recomendado você usar o DateTime do dotnet. E para isso usamos o .HasDefaultValue() que basicamente trás esse valor padrão necessário e pedido...
            // do CreateDate e do LastUpdateDate usando funções do Csharp
            // Sendo assim, o HasDefaultValueSql("GETDATE()"), vai realizar a função dentro do SqlServer e o .HasDefaultValue(DateTime.Now.ToUniversalTime()) vai realizar a função dentro do csharp
            builder.Property(x => x.CreateDate)
                .IsRequired()
                .HasColumnName("CreateDate")
                .HasColumnType("SMALLDATETIME")
                //.HasDefaultValueSql("GETDATE()")
                .HasDefaultValue(DateTime.Now.ToUniversalTime());

            // Para carater de teste, vamos deixar o .HasDefaultValueSql("GETDATE()") aqui, pra gente ver como fica no sql depois
            builder.Property(x => x.LastUpdateDate)
                .IsRequired()
                .HasColumnName("LastUpdateDate")
                .HasColumnType("SMALLDATETIME")
                .HasDefaultValueSql("GETDATE()");

            // RELACIONAMENTO UM PARA MUITOS - Como a gente sabe, são relações que uma entidade tem com a outra, que refletem no banco
            // Dessa vez não iremos usar o .Property(), mas sim o .HasOne(), que como o nome já diz, diz que ele tem um, no nosso caso, relacionamento
            // O .HasOne() também espera uma expressão, e dentro dele, você passa a outra tabela/objeto que deseja se relacionar, que já tenha sido referenciado dentro da classe como propriedade
            // Então, básicamente o que queremos dizer é que um Post possui um autor. Mas e o autor, tem quantos posts?
            // O WithMany() resolve isso dizando pra gente que o autor possui muitos posts. O WithMany() também espera uma expressão
            // E quando criamos a expressão dentro do WithMany(), ele já entende que estamos referenciando o autor, então...
            // Automaticamente o EF vai assimilar o x da expressão do WithMany, a propriedade passada dentro do HasOne()
            // Resumindo: primeiro eu digo com o HasOne() que um post possui um autor, e logo em seguida digo com o WithMany() que um autor possui diversos posts
            // Como a gente sabe, quando fazemos uma relação entre duas tabelas, é gerando uma constraint para gente, como já vimos na aula de Sql Server
            // Se não definirmos isso usando as funções do EF, por padrão, ele vai gerar um nome aleatório dessa constraint para gente
            // Sendo assim, é recomendado que você não deixe isso acontecer, e que use o .HasConstraintName() para definir o nome dessa constraint
            // Lembrando que essa constraint gerada é como se fosse um contrato que liga o post ao autor
            // E bem, o que aconteceria caso você deletasse um post? O autor seria deletado junto? E quando você deletasse um autor, os posts desse autor também seriam deletados?
            // Para tratar isso, possuimos uma propriedade chamada de .OnDelete(), onde dentro dela você pode colocar n comportamentos
            // No nosso caso, iremos usar o DeleteBehavior.Cascade, que faz com que toda vez que eu delete um post, o seu autor também seja deletado
            // Porém, temos que ter cuidado, pois esse autor pode possuir diversos posts, e isso seria um problema. Mas para o nosso caso, de exemplo, agora, iremos usar msm o Cascade
            // Olhem a documentação do OnDelete para saber qual tipo de DeleteBehavior é necessário para o seu cenário
            // Curiosidade: para fazer uma relação um para um, ao invés de usar o HasOne(), usariamos o OwsOne(), e no migrations ele vai gerar apenas uma tabela, e não tabelas separadas
            // No caso ele criaria apenas a tabela de post, com as informações do autor, e não duas tabelas, uma com informações do post que é ligada a uma tabela com as informações do autor
            builder.HasOne(x => x.Author)
                .WithMany(x => x.Posts)
                .HasConstraintName("FK_Post_Author")
                .OnDelete(DeleteBehavior.Cascade);

            // Agora vamos fazer o relacionamento um para muitos com categória que é a mesma coisa do acima
            builder.HasOne(x => x.Category)
                .WithMany(x => x.Posts)
                .HasConstraintName("FK_Post_Category")
                .OnDelete(DeleteBehavior.Cascade);

            // RELACIONAMENTO MUITOS PARA MUITOS - Criando entidade associativa virtual
            // Dessa vez, ao invés usaremos o .HasMany() para iniciar o nosso mapeamento. Ele também espera uma expressão
            // Como sabemos, um post possui muitas tags, assim com uma tag possui diversos posts. Primeiro iremos dizer que o post possui muitas tags
            // Não sei se você percebeu, mas na nossa past model não existem mais as tabelas/classes associativas, como a PostTag que vimos no modulo anterior
            // E é necessário existir essa tabela/classe para conseguir relacionar uma tabela com outra em um relacionamento muitos para muitos, no nosso caso, PostTag, 
            // A gente podia criar essa classe que faz esse relacionamento pra gente, que no modulo anterior existia e se chamava PostTag. Mas é bem mais interessante não ter pois a gente economiza uma classe...
            // pois a gente consegue acessar os posts através das tags e as tags através dos posts, então, teoricamente a gente n precisa criar uma classe pra isso (Mas se quiser pode fazer)
            // A gente também usa o WithMany aqui pra dizer que uma tag possui diversos posts
            // E bem, para gente conseguir fazer esse relacionamento, sem precisar criar uma classe/tabela associativa, nós iremos criar uma entidade virtual, que é uma entidade que não existe, que serve apenas para o proposito de fazer esse relaciomaneto
            // E nós fazemos isso através do .UseEntity<>(), que recebe uma classe, porém, a gente pode atingir isso usando um Dictionary de string e objeto
            // Dicionario é uma matrix. No nosso caso, definimos ela com o tamanho 2, onde o primeiro valor tem que receber uma string e o segundo um objeto
            // O primeiro valor é o nome da nossa tabela, que no caso é PostTag. E logo após colocamos o nosso objeto
            // No nosso caso a gente criou uma variavel chamado post através de uma expressão, e logo após, essa variavel já pode receber todos os recursos do fluent mapping
            builder.HasMany(x => x.Tags) // Tags do post
                .WithMany(x => x.Posts) // Posts da tag
                .UsingEntity<Dictionary<string, object>>(
                    "PostTag",
                    post => post.HasOne<Tag>()
                        .WithMany()
                        .HasForeignKey("PostId")
                        .HasConstraintName("Fk_PostTag_PostId")
                        .OnDelete(DeleteBehavior.Cascade),
                    tag => tag.HasOne<Post>()
                        .WithMany()
                        .HasForeignKey("TagId")
                        .HasConstraintName("FK_PostTag_TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                );

        }
    }
}