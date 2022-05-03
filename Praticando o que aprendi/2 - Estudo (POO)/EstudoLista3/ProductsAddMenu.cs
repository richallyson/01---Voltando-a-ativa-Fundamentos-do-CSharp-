using System;
using System.Collections.Generic;
using System.Threading;

namespace EstudoLista3
{
    public class ProductsAddMenu
    {
        // public static void Show()
        // {
        //     Console.Clear();
        //     var Products = new List<Product>();
        //     DrawScreen();
        //     AddProducts();
        // }

        public static List<Product> AddProducts(List<Product> products)
        {
            Console.SetCursorPosition(12, 1);
            Console.WriteLine("Quantos produtos deseja adicionar:");
            Console.SetCursorPosition(1, 2);
            MenuDrawning.DrawEqualLine(60, "=");
            Console.SetCursorPosition(47, 1);
            var numProdutos = int.Parse(Console.ReadLine());

            Console.SetCursorPosition(20, 3);
            Console.WriteLine("= ADICIONE UM PRODUTO =");
            Console.SetCursorPosition(1, 4);
            MenuDrawning.DrawEqualLine(60, "=");

            for (int i = 0; i < numProdutos; i++)
            {
                Console.SetCursorPosition(2, 5 + i);
                Console.WriteLine($"{i + 1})");
                Console.SetCursorPosition(5, 5 + i);
                var guid = Guid.NewGuid();
                Console.WriteLine($"Digite o nome do produto: ");
                Console.SetCursorPosition(31, 5 + i);
                var product = new Product(guid, Console.ReadLine(), DateTime.Now);
                products.Add(product);

                if (i + 1 == numProdutos)
                {
                    Console.WriteLine("Os produtos foram adicionados ao mercado.");
                    Console.WriteLine("Você está sendo redirecionado(a) para o menu principal");
                    Thread.Sleep(3000);
                    MainMenu.Show();
                }
            }

            return products;
        }

        public static void DrawScreen()
        {
            MenuDrawning.DrawPlusLine(60, "+", "-");
            Console.Write("\n");
            MenuDrawning.DrawPipeLine(30, 60, "|", " ");
            MenuDrawning.DrawPlusLine(60, "+", "-");

        }
    }
}