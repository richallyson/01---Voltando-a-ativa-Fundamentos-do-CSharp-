using System;
using Blog.Repositories;

namespace Blog.Screens.MenuPostTagScreen
{
    public static class ListPostWithTagsScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("= LISTANDO POSTS E SUAS TAGS =");
            Console.WriteLine("==============================");
            ListPostWithTags();
            Console.WriteLine("==============================");
            Console.WriteLine("");
            Console.WriteLine("Aperter ENTER para voltar para o menu");
            Console.ReadLine();
            MenuPostTagScreen.Load();
        }

        private static void ListPostWithTags()
        {
            var repository = new PostRepository();
            var posts = repository.GetPostWithTags();

            foreach (var post in posts)
            {
                Console.WriteLine($"{post.Title}");
                foreach (var tags in post.Tags)
                {
                    Console.WriteLine($"- {tags.Name}");
                }
            }
        }
    }
}