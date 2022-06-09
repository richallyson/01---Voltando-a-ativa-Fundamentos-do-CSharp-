using System;

namespace Blog.Screens.MenuPostScreen
{
    public static class MenuPostScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("= GESTÃO DE POST = ");
            Console.WriteLine("=====================");
            Console.WriteLine("1 - Criar um Post");
            Console.WriteLine("2 - Listar Posts");
            Console.WriteLine("3 - Atualizar Post");
            Console.WriteLine("4 - Deletar Post");
            Console.WriteLine("5 - Listar post com sua categoria");
            Console.WriteLine("6 - Voltar ao menu principal");
            Console.WriteLine("");
            Console.Write("Digite a sua escolha: ");
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1: CreatePostScreen.Load(); break;
                case 2: ListPostScreen.Load(); break;
                case 3: UpdatePostScreen.Load(); break;
                case 4: DeletePostScreen.Load(); break;
                case 5: ListPostWithCategoryScreen.Load(); break;
                case 6: Program.Load(); break;
                default: Load(); break;
            }
        }
    }
}