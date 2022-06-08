using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.MenuUserScreen
{
    public static class DeleteUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("= DELETAND USUÁRIO =");
            Console.WriteLine("====================");
            Delete();
            Console.WriteLine("====================");
            Console.WriteLine("");
            Console.WriteLine("Aperter ENTER para voltar para o menu");
            Console.ReadLine();
            MenuUserScreen.Load();
        }

        public static void Delete()
        {
            var repository = new Repository<User>();
            Console.Write("Digite a id do usuário que você deseja deletar: ");
            var id = int.Parse(Console.ReadLine());
            repository.Delete(id);

            Console.WriteLine("");
            Console.WriteLine($"Usuário {id} foi deletado com sucesso!");
        }
    }
}