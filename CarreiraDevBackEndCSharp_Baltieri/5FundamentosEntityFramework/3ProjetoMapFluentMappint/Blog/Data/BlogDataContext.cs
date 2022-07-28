using System;
using Blog.Data.Mappings;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    public class BlogDataContext : DbContext
    {
        // Abaixo segue tudo o que precisamos para rodar a nossa aplicação em um banco desejado, quanto tb para criar um banco de dados a partir dela

        // Como não iremos trabalhar com tag e role diretamente, não criamos um dbset pra eles. Porém, eles serão chamados ainda sim
        // pelo fato de estarem dentro de post e users. Caso queira trabalhar apenas com eles, crie um dbset pra cada um
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        // Criando conexão com o BD
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$");

        // É necessiario informar para o nosso DataContext que a gente tem arquivos de mapeamento. E isso é feito no metodo OnModelCreating()
        // Ele tbm é sobrescrito como o OnConfiguring que faz a conexão com o bd
        // O ModelCreating vai passar pra gente um ModelBuilder, e esse modelBuilder é o item que a gente vai utilizar aqui para aplicar as configurações
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // E aqui a gente usa a função ApplyConfiguration do modelBuilder para informar que temos um mapeamento passando o classe mapeada como instancia
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new PostMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }



    }
}