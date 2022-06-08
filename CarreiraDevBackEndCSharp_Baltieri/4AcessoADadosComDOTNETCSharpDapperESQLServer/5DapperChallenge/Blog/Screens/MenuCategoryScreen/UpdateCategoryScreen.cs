using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.MenuCategoryScreen
{
    public static class UpdateCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("= ATUALIZANDO UMA CATEGORIA = ");
            Console.WriteLine("=========================");
            Update();
            Console.WriteLine("=========================");
            Console.WriteLine("");
            Console.WriteLine("Aperter ENTER para voltar para o menu");
            Console.ReadLine();
            MenuCategoryScreen.Load();
        }

        private static void Update()
        {
            try
            {
                var repository = new Repository<Category>();
                var category = new Category();
                Console.Write("Digite a id da categoria que deseja atualizar: ");
                category.Id = int.Parse(Console.ReadLine());
                Console.Write("Digite o nome da categoria: ");
                category.Name = Console.ReadLine();
                Console.Write("Digite o slug da categoria: ");
                category.Slug = Console.ReadLine();
                repository.Update(category);
                Console.WriteLine("");
                Console.WriteLine($"Categoria {category.Id} foi atualizada com sucesso");
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