using System;

namespace Blog.Screens.MenuUserScreen
{
    public static class MenuUserScreen
    {
        public static void Load()
        {

            Console.Clear();
            Console.WriteLine("= GESTÃO DE USUÁRIO = ");
            Console.WriteLine("=====================");
            Console.WriteLine("1 - Criar um Usuário");
            Console.WriteLine("2 - Listar Usuários");
            Console.WriteLine("3 - Atualizar Usuário");
            Console.WriteLine("4 - Deletar Usuário");
            Console.WriteLine("5 - Voltar ao menu principal");
            Console.WriteLine("");
            Console.Write("Digite a sua escolha: ");
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1: CreateUserScreen.Load(); break;
                case 2: ListUserScreen.Load(); break;
                case 3: UpdateUserScreen.Load(); break;
                case 4: DeleteUserScreen.Load(); break;
                case 5: Program.Load(); break;
                default: Load(); break;
            }

        }
    }
}