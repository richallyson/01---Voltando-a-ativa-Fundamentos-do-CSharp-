using System;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    public class BlogDataContext : DbContext
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        // Criando conexão com o BD
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$");
            // SQLPROFILE = Mostra as queries que estão sendo escritas. o que ta sendo logado, o que ta sendo executado no servidor, etc 
            // O Balta disse que ele falou disso na aula de Dapper, mas não falou não kkkkk Vou mandar um ticket pra ele
            // Basicamente um relatório, um log
            // E bem, o EF da pra gente essa possibilidade da gente logar nossa informações. Usando essa função abaixo
            // Esse log pode ser salvo em diversos lugares, mas no nosso caso, vamos fazer pelo console
            // Recomendo abrir outro terminal por fora, para ficar melhor a visualização do que vamos fazer
            // Descomente essa função e dê um dotnet run. Você vai ver que ele vai trazer pra gente tudo o que eu disse acima
            options.LogTo(Console.WriteLine);
        }

    }
}