using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.MenuCategoryScreen
{
    public static class ListCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("= LISTANDO AS CATEGORIAS = ");
            Console.WriteLine("=========================");
            List();
            Console.WriteLine("=========================");
            Console.WriteLine("");
            Console.WriteLine("Aperter ENTER para voltar para o menu");
            Console.ReadLine();
            MenuCategoryScreen.Load();
        }

        private static void List()
        {
            try
            {
                var repository = new Repository<Category>();
                var categories = repository.Get();

                foreach (var category in categories)
                {
                    Console.WriteLine($"{category.Id} - {category.Name} ({category.Slug})");
                }
            }
            catch (Exception ex)
            {
                // Lembrando que não é legal fazer dessa forma, passando a msg de erro, etc
                // O certo seria criar uma msg customizada, mas para o desafio ta valendo isso msm
                // E eu só vou fazer isso msm aqui em categoria pra ficar de exemplo, no resto das telas não irei fazer o try/catch
                Console.WriteLine("Não foi possivel criar a Categoria");
                Console.WriteLine(ex.Message);
            }
        }
    }
}