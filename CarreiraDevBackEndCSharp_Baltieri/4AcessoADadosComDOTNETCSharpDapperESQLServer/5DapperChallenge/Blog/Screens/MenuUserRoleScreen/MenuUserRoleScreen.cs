using System;

namespace Blog.Screens.MenuUserRoleScreen
{
    public static class MenuUserRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("= VINCUNLAR USUÁRIO A UMA ROLE =");
            Console.WriteLine("================================");
            Console.WriteLine("1 - Vincular usuário a uma role");
            Console.WriteLine("2 - Listar usuários com suas roles");
            Console.WriteLine("3 - Voltar ao menu principal");
            Console.WriteLine("");
            Console.Write("Digite a sua escolha: ");
            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1: LinkUserToRoleScreen.Load(); break;
                case 2: ListUsersWithRoleScreen.Load(); break;
                case 3: Program.Load(); break;
                default: Load(); break;
            }

        }
    }
}