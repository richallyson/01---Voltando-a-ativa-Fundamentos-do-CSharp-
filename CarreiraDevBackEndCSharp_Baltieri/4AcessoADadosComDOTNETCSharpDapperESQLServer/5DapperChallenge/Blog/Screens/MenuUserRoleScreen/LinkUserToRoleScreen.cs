using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.MenuUserRoleScreen
{
    public static class LinkUserToRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("= VINCULANDO UM USUÁRIO A UMA ROLE =");
            Console.WriteLine("====================================");
            LinkUserToRole();
            Console.WriteLine("====================================");
            Console.WriteLine("");
            Console.WriteLine("Aperter ENTER para voltar para o menu");
            Console.ReadLine();
            MenuUserRoleScreen.Load();
        }

        private static void LinkUserToRole()
        {
            var repository = new Repository<UserRole>();
            var userRole = new UserRole();
            Console.Write("Digite o id do usuário: ");
            userRole.UserId = int.Parse(Console.ReadLine());
            Console.Write("Digite o id da role: ");
            userRole.RoleId = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            repository.Create(userRole);
            Console.WriteLine($"O usuário {userRole.UserId} foi vinculada a role {userRole.RoleId}");
        }
    }
}