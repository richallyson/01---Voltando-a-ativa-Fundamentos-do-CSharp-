using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    // Para uma classe ser um DataContext, ela precisa herdar de DbContext
    // O DataContext representa nosso banco em memória
    public class BlogDataContext : DbContext
    {
        // Os DbSet referênciam quais tabelas queremos trazer do banco pra cá
        // Lembrando que ao ser trazida, vai ser tudo trabalhado em memória, e só quando for necessário, persistido no banco
        // É uma boa prática deixar o nome da propriedade como o nome do modelo no plural
        // O DbSet<> representa a tabela especificada no banco
        // Aqui você especifica o que quer que seja feito no banco. Caso não queira que não seja feito nada na tabela Role, basta tirar ela daqui que ele vai ser impossibilitada de realizar um crud
        // Só é possivel realizar um crud em tabelas que possuem chave primaria. Por esse motivo o PostTag e o UserRole estão comentados por possuirem chaves compostas...
        // se você criar eles aqui, vai ocorrer um erro ao tentar realizar o crud das outras tabelas, pois por padrão o EF não entende isso, para isso é necessário uma configuração especifica
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        //public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }

        // Criando conexão com o BD
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$");

    }
}