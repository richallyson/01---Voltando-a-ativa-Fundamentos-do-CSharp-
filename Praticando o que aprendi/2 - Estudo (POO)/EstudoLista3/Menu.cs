using System;

namespace EstudoLista3
{
    public class Menu
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Black;

            DrawScreen();
            WriteOptions();

            var option = short.Parse(Console.ReadLine());
            HandleMenuOption(option);
        }

        public static void DrawScreen()
        {
            MenuDrawning.DrawPlusLine(90, "+", "-");
            Console.Write("\n");
            MenuDrawning.DrawPipeLine(30, "|", " ");
            MenuDrawning.DrawPlusLine(90, "+", "-");

        }

        public static void WriteOptions()
        {
            Console.SetCursorPosition(9, 1);
            Console.WriteLine("= Editor HTML =");
            Console.SetCursorPosition(1, 2);
            Console.WriteLine("===============================");
            Console.SetCursorPosition(3, 3);
            Console.WriteLine("Selecione uma opção abaixo:");
            Console.SetCursorPosition(1, 4);
            Console.WriteLine("===============================");
            Console.SetCursorPosition(2, 5);
            Console.WriteLine("1 - Novo arquivo");
            Console.SetCursorPosition(2, 6);
            Console.WriteLine("2 - Abrir arquivo");
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
                case 1: Menu.Show(); break;
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