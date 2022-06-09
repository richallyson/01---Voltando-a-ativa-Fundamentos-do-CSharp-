using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.MenuPostScreen
{
    public static class ListPostWithCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("= LISTANDO POSTS COM SUA CATEGORIA =");
            Console.WriteLine("====================================");
            ListPostWithCategory();
            Console.WriteLine("====================================");
            Console.WriteLine("");
            Console.WriteLine("Aperter ENTER para voltar para o menu");
            Console.ReadLine();
            MenuPostScreen.Load();
        }

        private static void ListPostWithCategory()
        {
            var repositoryPost = new Repository<Post>();
            var repositoryCategory = new Repository<Category>();
            var posts = repositoryPost.Get();

            foreach (var post in posts)
            {
                var category = repositoryCategory.Get(post.CategoryId);
                Console.WriteLine($"Post: {post.Title} - Categoria: {category.Name}");
            }
        }
    }
}