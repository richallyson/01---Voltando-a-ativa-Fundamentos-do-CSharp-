using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.MenuPostScreen
{
    public static class CreatePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("= CRIANDO UM POST = ");
            Console.WriteLine("====================");
            Create();
            Console.WriteLine("====================");
            Console.WriteLine("");
            Console.WriteLine("Aperter ENTER para voltar para o menu");
            Console.ReadLine();
            MenuPostScreen.Load();
        }

        private static void Create()
        {
            var repository = new Repository<Post>();
            var post = new Post();
            Console.Write("Digite o id da categoria do post: ");
            post.CategoryId = int.Parse(Console.ReadLine());
            Console.Write("Digite o id do autor(a) do post: ");
            post.AuthorId = int.Parse(Console.ReadLine());
            Console.Write("Digite o título do post: ");
            post.Title = Console.ReadLine();
            Console.Write("Digite um sumário do post: ");
            post.Summary = Console.ReadLine();
            Console.Write("Escreva o post: ");
            post.Body = Console.ReadLine();
            Console.Write("Digite o slug da página: ");
            post.Slug = Console.ReadLine();
            post.CreateDate = DateTime.Now;
            post.LastUpdateDate = DateTime.Now;
            repository.Create(post);
            Console.WriteLine($"O Post {post.Title} foi adicionado na data {post.CreateDate}");
        }
    }
}