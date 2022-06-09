using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.MenuCategoryScreen
{
    public static class ListPostsOfACategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("= LISTANDO OS POSTS DE CADA CATEGORIA = ");
            Console.WriteLine("=========================");
            ListPostsOfACategory();
            Console.WriteLine("=========================");
            Console.WriteLine("");
            Console.WriteLine("Aperter ENTER para voltar para o menu");
            Console.ReadLine();
            MenuCategoryScreen.Load();
        }

        private static void ListPostsOfACategory()
        {
            var repositoryPost = new Repository<Post>();
            var repositoryCategory = new Repository<Category>();
            var posts = repositoryPost.Get();

            foreach (var post in posts)
            {
                var category = repositoryCategory.Get(post.CategoryId);
                Console.WriteLine($"Categoria: {category.Name} (Post: {post.Title})");
            }
        }
    }
}