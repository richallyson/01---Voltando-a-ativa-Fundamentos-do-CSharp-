using System;
using System.Collections.Generic;

namespace EstudoLista3
{

    public class CashierMenu
    {
        public static void Show()
        {
            Console.Clear();

            var products = new List<Product>();
            var guid = Guid.NewGuid();
            DrawScreen();
            ProductsAddMenu.AddProducts(products);
            //products.ForEach(p => Console.WriteLine(p.NomeDoProduto));
        }

        public static void DrawScreen()
        {
            MenuDrawning.DrawPlusLine(60, "+", "-");
            Console.Write("\n");
            MenuDrawning.DrawPipeLine(30, 60, "|", " ");
            MenuDrawning.DrawPlusLine(60, "+", "-");
        }

        public static void WriteOptions()
        {
            Console.SetCursorPosition(20, 1);
            Console.WriteLine("= MENU DO CAIXA =");
            Console.SetCursorPosition(1, 2);
            MenuDrawning.DrawEqualLine(60, "=");
            Console.SetCursorPosition(3, 3);
            Console.WriteLine("Você deseja entrar como:");
            Console.SetCursorPosition(1, 4);
            MenuDrawning.DrawEqualLine(60, "=");
            Console.SetCursorPosition(2, 5);
            Console.WriteLine("1 - Cliente");
            Console.SetCursorPosition(2, 6);
            Console.WriteLine("2 - Funcionário");
            Console.SetCursorPosition(2, 7);
            Console.WriteLine("0 - Sair");
            Console.SetCursorPosition(2, 10);
            Console.WriteLine("Opção: ");
            Console.SetCursorPosition(9, 10);
        }

        public static void HandleMenuOption(short option)
        {
            switch (option)
            {
                case 1: MainMenu.Show(); break;
                case 2: Console.WriteLine("View"); break;
                case 0:
                    {
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    }

                default: Show(); break;
            }

        }
    }
}