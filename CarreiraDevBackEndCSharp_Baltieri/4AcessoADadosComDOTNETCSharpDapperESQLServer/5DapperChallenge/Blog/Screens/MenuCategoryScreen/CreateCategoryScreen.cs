using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.MenuCategoryScreen
{
    public static class CreateCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("= CRIANDO UMA NOVA CATEGORIA = ");
            Console.WriteLine("=========================");
            Create();
            Console.WriteLine("=========================");
            Console.WriteLine("");
            Console.WriteLine("Aperter ENTER para voltar para o menu");
            Console.ReadLine();
            MenuCategoryScreen.Load();
        }

        private static void Create()
        {
            try
            {
                var repository = new Repository<Category>();
                var category = new Category();
                Console.Write("Digite o nome da categoria: ");
                category.Name = Console.ReadLine();
                Console.Write("Digite o slug da tag: ");
                category.Slug = Console.ReadLine();
                Console.WriteLine("");
                repository.Create(category);
                Console.WriteLine($"Categoria ({category.Name}) adicionada com sucesso!");
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