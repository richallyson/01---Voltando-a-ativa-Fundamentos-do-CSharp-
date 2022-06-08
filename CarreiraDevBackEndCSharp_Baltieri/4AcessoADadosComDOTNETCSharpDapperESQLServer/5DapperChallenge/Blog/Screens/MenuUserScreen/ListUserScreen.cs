using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.MenuUserScreen
{
    public static class ListUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("= LISTANDO USUÁRIOS =");
            Console.WriteLine("=====================");
            List();
            Console.WriteLine("=====================");
            Console.WriteLine("");
            Console.WriteLine("Aperter ENTER para voltar para o menu");
            Console.ReadLine();
            MenuUserScreen.Load();
        }

        private static void List()
        {
            var repository = new Repository<User>();
            var users = repository.Get();

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Name} - {user.Bio} ({user.Slug})");
            }

        }
    }
}