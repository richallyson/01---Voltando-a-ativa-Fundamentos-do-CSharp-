using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.MenuPostScreen
{
    public static class UpdatePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("= ATUALIZANDO POST =");
            Console.WriteLine("====================");
            Update();
            Console.WriteLine("====================");
            Console.WriteLine("");
            Console.WriteLine("Aperter ENTER para voltar para o menu");
            Console.ReadLine();
            MenuPostScreen.Load();
        }

        private static void Update()
        {
            var repository = new Repository<Post>();
            var post = new Post();

            Console.Write("Digite o id do Post que deseja atualizar: ");
            post.Id = int.Parse(Console.ReadLine());
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

            // Pegando a data da criação desse post
            var postTakeCreateDate = repository.Get(post.Id);
            post.CreateDate = postTakeCreateDate.CreateDate;
            post.LastUpdateDate = DateTime.Now;
            repository.Update(post);

            Console.WriteLine("");
            Console.WriteLine($"O Post {post.Title} foi atualizado com sucesso na data {post.LastUpdateDate}");
        }
    }
}