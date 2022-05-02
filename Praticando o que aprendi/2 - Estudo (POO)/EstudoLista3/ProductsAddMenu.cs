using System;
using System.Collections.Generic;

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

        public static Product AddProducts(Product product)
        {
            DrawScreen();
            Console.SetCursorPosition(20, 1);
            Console.WriteLine("= ADICIONE UM PRODUTO =");
            Console.SetCursorPosition(1, 2);
            MenuDrawning.DrawEqualLine(60, "=");
            Console.SetCursorPosition(3, 3);
            var guid = Guid.NewGuid();
            Console.WriteLine($"Digite o nome do produto: ");
            product = new Product(guid, Console.ReadLine(), DateTime.Now);
            return product;
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