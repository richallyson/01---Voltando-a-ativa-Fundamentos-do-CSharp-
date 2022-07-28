using System;
using System.Linq;
using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new BlogDataContext();

            // context.Users.Add(new User
            // {
            //     Name = "Vegeta",
            //     Email = "vetega@sayajin.vg",
            //     PasswordHash = "malditoKakaroto",
            //     Bio = "Eu sou o principe dos Sayajins!",
            //     Image = "http://",
            //     Slug = "principe-sayajin"
            // });
            // context.SaveChanges();

            var user = context.Users.FirstOrDefault(x => x.Id == 1005);
            //var category = context.Categories.FirstOrDefault(x => x.Id == 3);
            context.Posts.Add(new Post
            {
                // Testando a criação dentro de uma categoria dentro de um post
                Category = new Category { Name = "Sayajins", Slug = "sayajins" },
                Author = user,
                Title = "Como ser um guerreiro Sayajin!",
                Summary = "Hoje iremos aprender...",
                Body = "Para se tornar um...",
                Slug = "como-ser-um-guerreiro-sayajin",
                CreateDate = DateTime.Now,
                //LastUpdateDate = DateTime.Now
                //Tags = null
            });

            // No exemplo do Balta ele criou uma variavel que recebia um novo post com as infos acima, e dps ele adicionava esse post ao banco usando um context.Posts.Add(post)
            context.SaveChanges();
        }
    }
}
