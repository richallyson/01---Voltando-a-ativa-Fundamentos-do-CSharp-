using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.MenuPostScreen
{
    public static class ListPostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("= LISTANDO POSTS =");
            Console.WriteLine("=======================");
            List();
            Console.WriteLine("=======================");
            Console.WriteLine("");
            Console.WriteLine("Aperter ENTER para voltar para o menu");
            Console.ReadLine();
            MenuPostScreen.Load();
        }

        private static void List()
        {
            var repository = new Repository<Post>();
            var posts = repository.Get();

            foreach (var post in posts)
            {
                Console.WriteLine($"{post.Title} - {post.Summary} ({post.CreateDate})");
            }
        }
    }
}