using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.MenuPostScreen
{
    public static class DeletePostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("= DELETANDO POST =");
            Console.WriteLine("==================");
            Delete();
            Console.WriteLine("==================");
            Console.WriteLine("");
            Console.WriteLine("Aperter ENTER para voltar para o menu");
            Console.ReadLine();
            MenuPostScreen.Load();
        }

        private static void Delete()
        {
            var repository = new Repository<Post>();
            Console.Write("Digite a id do post que deseja deletar: ");
            var id = int.Parse(Console.ReadLine());
            repository.Delete(id);
            Console.WriteLine("");
            Console.WriteLine($"Post {id} deletado com sucesso");
        }
    }
}