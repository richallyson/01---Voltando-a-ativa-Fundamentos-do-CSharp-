using System;
using Blog.Data.Mappings;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data
{
    public class BlogDataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        // Bem se a gente deixar só assim, o Entity framework vai tentar buscar por essa tabela, e vai ver que ela não existe
        // E ela n ta pluralizada, justamente pelo fato e não existir lá, só pra tirar a duvida caso tenha
        // E nesse caso, a gente deve no ModelBuilder colocar uma configuração especial para ele
        public DbSet<PostWithTagsCount> PostWithTagsCount { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new PostMap());
            modelBuilder.ApplyConfiguration(new UserMap());

            modelBuilder.Entity<PostWithTagsCount>(x =>
            {
                // x.ToSqlQuery("SELECT * FROM vwPostWithTags"); // Esse caso aqui também serveria pra gente mapear uma view, só por conhecimento msm kk
                // Logo avisando que o Balta não sabe se essa Query realmente funciona (e não funciona) kkkkk Ele mesmo diz isso na aula, então fica ai pra tu de desafio
                // Eu fiz uma Query aqui que funcionou mas não perfeitamente, no futuro venho corrigir. Mas quando dou run aqui, da um erro, pois pede que essa "tabela" tenha uma PK. 
                // E ele diz pra fazer isso direto duma View, pra evitar que a gente digite muito código
                // Agora pode voltar pra main (que apesar de parecer embaçado, ele sempre explica melhor no próximo curso, então ta safe)
                x.ToSqlQuery(@"
                            SELECT 
                                [Title] AS [Name],    
                                (SELECT COUNT([TagId]) FROM [PostTag])
                                    AS [Count]
                            FROM
                                [Post]");
            });
        }



    }
}