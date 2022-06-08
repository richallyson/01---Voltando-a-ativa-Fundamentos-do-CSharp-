using System;

namespace Blog.Screens.MenuPostTagScreen
{
    public static class MenuPostTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("= VINCULAR POST COM TAG =");
            Console.WriteLine("=========================");
            Console.WriteLine("1 - Vincular uma tag a um post");
            Console.WriteLine("2 - Listar posts com suas tags");
            Console.WriteLine("3 - Voltar ao menu principal");
            Console.WriteLine("");
            Console.Write("Digite a sua escolha: ");
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1: LinkPostToTagScreen.Load(); break;
                case 2: ListPostWithTagsScreen.Load(); break;
                case 3: Program.Load(); break;
                default:
                    Load(); break;
            }
        }
    }
}