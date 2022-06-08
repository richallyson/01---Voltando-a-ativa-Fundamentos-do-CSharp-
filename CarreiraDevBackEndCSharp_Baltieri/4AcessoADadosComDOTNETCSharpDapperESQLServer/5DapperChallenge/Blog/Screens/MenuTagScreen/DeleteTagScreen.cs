using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.MenuTagScreen
{
    public static class DeleteTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("= DELETANDO UMA TAG =");
            Console.WriteLine("=====================");
            Delete();
            Console.WriteLine("=====================");
            Console.WriteLine("");
            Console.WriteLine("Aperter ENTER para voltar para o menu");
            Console.ReadLine();
            MenuTagScreen.Load();
        }

        private static void Delete()
        {
            var repository = new Repository<Tag>();
            Console.Write("Digite o Id da tag que deseja deletar: ");
            var id = int.Parse(Console.ReadLine());
            repository.Delete(id);

            Console.WriteLine("");
            Console.WriteLine($"Tag {id} deletada com sucesso!");
        }
    }
}