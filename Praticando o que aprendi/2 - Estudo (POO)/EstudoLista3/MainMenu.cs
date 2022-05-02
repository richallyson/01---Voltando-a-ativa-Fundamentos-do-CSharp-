using System;
using System.Collections.Generic;
using System.Threading;

namespace EstudoLista3
{
    public class MainMenu
    {
        public static void Show()
        {
            Console.Clear();

            DrawScreen();
            WriteOptions();

            var option = short.Parse(Console.ReadLine());
            HandleMenuOption(option);
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
            Console.WriteLine("= ESCOLHA SUA AÇÃO =");
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
            var Products = new List<Product>();
            var guid = Guid.NewGuid();
            //Products.Add(new Product(guid, "Macarrão", DateTime.Now));
            var Cachiers = new List<ShopCashiers>();
            var supermarket = new Supermarket(Products, DateTime.Now, DateTime.Now, Cachiers);
            int supermarketListLenght = supermarket.Products.Count;
            switch (option)
            {
                case 1:
                    if (supermarketListLenght == 0)
                    {
                        Console.SetCursorPosition(1, 11);
                        MenuDrawning.DrawEqualLine(60, "=");
                        Console.SetCursorPosition(6, 12);
                        Console.WriteLine("Não temos produto. Pedimos desculpas pelo indevido!");
                        Console.SetCursorPosition(1, 13);
                        MenuDrawning.DrawEqualLine(60, "=");
                        Thread.Sleep(3000);
                        Show();
                    }
                    else
                        ClientMenu.Show();
                    break;
                case 2: CashierMenu.Show(); break;
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