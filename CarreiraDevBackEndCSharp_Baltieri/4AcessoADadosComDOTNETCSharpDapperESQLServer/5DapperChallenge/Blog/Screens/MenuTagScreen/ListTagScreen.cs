using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.MenuTagScreen
{
    public static class ListTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("= LISTANDO AS TAGS = ");
            Console.WriteLine("=========================");
            List();
            Console.WriteLine("=========================");
            Console.WriteLine("");
            Console.WriteLine("Aperter ENTER para voltar para o menu");
            Console.ReadLine();
            MenuTagScreen.Load();
        }

        private static void List()
        {
            var repository = new Repository<Tag>();
            var tags = repository.Get();

            foreach (var tag in tags)
            {
                Console.WriteLine($"{tag.Id} - {tag.Name} ({tag.Slug})");
            }
        }
    }
}