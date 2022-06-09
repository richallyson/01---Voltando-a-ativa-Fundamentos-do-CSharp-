using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.MenuCategoryScreen
{
    public static class ListCategoriesWithPostQuantityScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("= QUANTIDADE DE POSTS POR CATEGORIA =");
            Console.WriteLine("=====================================");
            ListCategoriesWithPostQuantity();
            Console.WriteLine("=====================================");
            Console.WriteLine("");
            Console.WriteLine("Aperter ENTER para voltar para o menu");
            Console.ReadLine();
            MenuCategoryScreen.Load();

        }

        private static void ListCategoriesWithPostQuantity()
        {
            var repository = new Repository<Category>();
            var categoryWithPosts = repository.Get();

            foreach (var category in categoryWithPosts)
            {
                Console.WriteLine($"{category.Name} - quantidade de posts dessa categoria: {category.Posts.Count}");
            }
        }
    }
}