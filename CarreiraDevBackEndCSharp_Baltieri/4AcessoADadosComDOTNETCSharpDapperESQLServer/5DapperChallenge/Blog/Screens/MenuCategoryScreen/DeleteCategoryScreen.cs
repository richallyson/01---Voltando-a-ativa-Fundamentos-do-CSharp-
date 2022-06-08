using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.MenuCategoryScreen
{
    public static class DeleteCategoryScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("= DELETANDO UMA CATEGORIA =");
            Console.WriteLine("=====================");
            Delete();
            Console.WriteLine("=====================");
            Console.WriteLine("");
            Console.WriteLine("Aperter ENTER para voltar para o menu");
            Console.ReadLine();
            MenuCategoryScreen.Load();
        }

        private static void Delete()
        {
            try
            {
                var repository = new Repository<Category>();
                Console.Write("Digite o Id da Categoria que deseja deletar: ");
                var id = int.Parse(Console.ReadLine());
                repository.Delete(id);
                Console.WriteLine("");
                Console.WriteLine($"Categoria {id} deletada com sucesso!");
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