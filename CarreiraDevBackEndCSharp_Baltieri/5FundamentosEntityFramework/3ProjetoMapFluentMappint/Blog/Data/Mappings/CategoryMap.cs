using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings
{
    // O que iremos fazer aqui dentro, é básicamente todo o mapeamento, como faziamos com as anotações
    // E para que isso aconteça, precisamos implementar a interface IEntityTypeConfiguration
    // O IEntityTypeConfiguration vai pedir um tipo, e no nosso caso, como vamos trabalhar mapeando a categoria, o nosso vai ser o Category
    // Lembrando que uma interface é um contrato, e para cumprir o contrato, você deve importar as funções ou propriedades que ela pede
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Primeira necessidade? Configurar a tabela que queremos mapear

            // TABELA - Ligando a classe a tabela
            // Mesma coisa que o [Table("Category")]. Aqui iremos ligar a tabela Category a o nossa classe Category
            // Lembrando, se não fizermos isso, na hora de rolar um query ou execute, o entity vai plurarizar a busca e procurar por Categories
            builder.ToTable("Category");

            // IDENTITY - Informando a chave primária
            // O entity por padrão já vai saber que o nosso Id, caso seja nomeado de Id na classe, é o Id que a gente deseja
            // Nem precisaria fazer o que vamos fazer, porém, é recomendado sim, mapear o identity, para ficar tudo mais implicito
            // O HasKey espera uma expressão dentro do seu parametro. Ele já entende que o X é uma categoria, pois ele pega o nosso tipo do EntityTypeBuilder<Category>...
            // E subsequentemente o EntityTypeBuilder<Category> vem do IEntityTypeConfiguration<Category>
            // Como no nosso banco, o Id é gerado através de um IDENTITY SEED, é necessário explicitar isso
            // No caso, se você está gerando o seu banco através de instrução sql, o builder.HasKey(x => x.Id); já é suficiente
            // Porém, no nosso caso, estamos pensando em futuramente criar o banco pelo nosso código, através do Migrations
            // Se faz necessário explicitar todos os pontos de forma minuciosa, para quando formos gerar o banco, ficar tudo direitinho, em todos as propriedades mapeadas
            // HasKey é usado APENAS para chave primária
            builder.HasKey(x => x.Id);

            // INFORMANDO o tipo de geração da chave primária
            // Bem, acima a gente definou o Id como a nossa chave primaria, usando o HasKey
            // Agora iremos definir a forma como essa chave primaria vai ser gerada no banco
            // E aqui percebemos uma diferença, acima usamos o HasKey, e aqui abaixo o Property
            // O Property é usado para mapear qualquer propriedade dentro da classe, referenciar uma propriedade. E em cima disso realizar algum comportamento ou não
            // No nosso caso iremos fazer um mapeamento que vai gerar a nossa id usando um identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd() // Essa função serve para que toda vez que eu vá adicionar um novo item, um valor novo seja gerado
                .UseIdentityColumn(); // E essa função faz com que esse parametro gerado no banco seja o PRIMARY KEY IDENTITY(1, 1)

            // PROPRIEDADE - Mapeando propriedades
            // É sempre bom seguir essa ordem de mapeamento, para nunca esquecer nada nas propriedades
            // O que fazemos é basicamente escrever o script sql através da funções do csharp. E basicamente FluentAPI é isso
            builder.Property(x => x.Name)
                .IsRequired() // mesma coisa do NOT NULL
                .HasColumnName("Name") // Aqui damos o nome da coluna do banco. No nosso caso a propriedade já tem o mesmo nome da propriedade do banco, não seria necessário fazer esse mapeamento. Porém fica como exemplo, e eu recomendo fazer pra ficar organizadinho
                .HasColumnType("NVARCHAR") // Define o tipo da coluna
                .HasMaxLength(80); // Define o máximo do tamanho do tipo, no nosso caso, o máximo de caracteres do NVARCHAR. No banco seria NVARCHAR(80)

            builder.Property(x => x.Slug)
                .IsRequired()
                .HasColumnName("Slug")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

            // INDICES (INDEX) - Se tu não sabe o que é isso ou não se lembra, eu explico sobre no curso de sql
            // Lembrando que quando criamos esse banco, criamos um indice pro slug, pois vamos ter bastente procura na categoria pelo slug
            // O HasIndex vai esperar dois parametros. O primeiro é a propriedade que possui o indice. E o segundo é o nome do indice
            // Se você não passar o nome do indice ele vai gerar de forma automática, porém é recomendado colocar o nome para casos futuros de manutenção
            builder.HasIndex(x => x.Slug, "IX_Category_Slug")
                .IsUnique(); //Com isso você garante que esse slug vai ser único. Nunca vai existir duas categorias com o mesmo slug

        }
    }
}