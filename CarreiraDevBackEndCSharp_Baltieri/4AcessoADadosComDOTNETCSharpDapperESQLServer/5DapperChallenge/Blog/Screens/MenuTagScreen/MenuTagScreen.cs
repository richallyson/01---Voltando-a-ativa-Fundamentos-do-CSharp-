using System;

namespace Blog.Screens.MenuTagScreen
{
    public static class MenuTagScreen
    {
        public static void Load()
        {

            Console.Clear();
            Console.WriteLine("= GESTÃO DE TAG = ");
            Console.WriteLine("=====================");
            Console.WriteLine("1 - Criar uma Tag");
            Console.WriteLine("2 - Listar Tags");
            Console.WriteLine("3 - Atualizar Tag");
            Console.WriteLine("4 - Deletar Tag");
            Console.WriteLine("5 - Listar quantidade de posts que uma tag tem");
            Console.WriteLine("6 - Voltar ao menu principal");
            Console.WriteLine("");
            Console.Write("Digite a sua escolha: ");
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1: CreateTagScreen.Load(); break;
                case 2: ListTagScreen.Load(); break;
                case 3: UpdateTagScreen.Load(); break;
                case 4: DeleteTagScreen.Load(); break;
                case 5: ListTagWithPostQuantityScreen.Load(); break;
                case 6: Program.Load(); break;
                default: Load(); break;
            }

        }
    }
}