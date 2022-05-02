using System;

namespace EstudoLista3
{

    public static class MenuDrawning
    {

        public static void DrawPlusLine(int size, string character1, string character2)
        {
            Console.Write(character1);
            for (int i = 0; i <= size; i++)
                Console.Write(character2);

            Console.Write(character1);
        }

        public static void DrawPipeLine(int size, int sizeHeight, string character1, string character2)
        {
            for (int lines = 0; lines <= size; lines++)
            {
                Console.Write(character1);
                for (int i = 0; i <= sizeHeight; i++)
                    Console.Write(character2);

                Console.Write(character1);
                Console.Write("\n");
            }
        }

        public static void DrawEqualLine(int size, string character1)
        {
            for (int i = 0; i <= size; i++)
                Console.Write(character1);

        }

    }
}