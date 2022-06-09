using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.MenuTagScreen
{
    public static class ListTagWithPostQuantityScreen
    {
        public static void Load()
        {
            Console.WriteLine("= LISTANDO QUANTIDADE DE POSTS POR TAG =");
            Console.WriteLine("========================================");
            ListTagWithPostQuantity();
            Console.WriteLine("========================================");
            Console.WriteLine("");
            Console.WriteLine("Aperter ENTER para voltar para o menu");
            Console.ReadLine();
            MenuTagScreen.Load();
        }

        private static void ListTagWithPostQuantity()
        {
            var repository = new TagRepository();

            var tags = repository.GetTagWithPostQuantity();

            foreach (var tag in tags)
            {
                Console.WriteLine($"A tag {tag.Name} possue {tag.Posts.Count} posts ligados a ela");
            }
        }
    }
}