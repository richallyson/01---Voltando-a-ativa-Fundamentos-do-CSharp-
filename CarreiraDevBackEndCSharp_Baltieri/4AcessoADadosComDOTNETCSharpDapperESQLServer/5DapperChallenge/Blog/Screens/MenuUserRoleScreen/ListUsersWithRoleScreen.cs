using System;
using Blog.Repositories;

namespace Blog.Screens.MenuUserRoleScreen
{
    public static class ListUsersWithRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("= LISTANDO USUÁRIOS COM SUAS ROLES =");
            Console.WriteLine("====================================");
            ListUsersWithRoles();
            Console.WriteLine("====================================");
            Console.WriteLine("");
            Console.WriteLine("Aperter ENTER para voltar para o menu");
            Console.ReadLine();
            MenuUserRoleScreen.Load();
        }

        private static void ListUsersWithRoles()
        {
            var repository = new UserRepository();
            var users = repository.GetUsersWithRole();

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Name}");
                foreach (var role in user.Roles)
                {
                    Console.WriteLine($"- {role.Name}");
                }
            }
        }
    }
}