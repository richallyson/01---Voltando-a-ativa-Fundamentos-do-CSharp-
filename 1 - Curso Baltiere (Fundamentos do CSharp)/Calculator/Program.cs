using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();

            Console.WriteLine("");
            Console.WriteLine("Qual operação deseja realizar?");
            Console.WriteLine("");

            Console.WriteLine("1 - Soma");
            Console.WriteLine("2 - Subtração");
            Console.WriteLine("3 - Divisão");
            Console.WriteLine("4 - Multiplicação");
            Console.WriteLine("5 - Fatorial");
            Console.WriteLine("6 - Sair");

            Console.WriteLine("");
            Console.WriteLine("===============================");
            Console.WriteLine("");

            Console.WriteLine("Selecione uma opção:");
            short res = short.Parse(Console.ReadLine());

            switch (res)
            {
                case 1: Soma(); break;
                case 2: Subtracao(); break;
                case 3: Divisao(); break;
                case 4: Multiplicacao(); break;
                case 5: Fatorial(); break;
                case 6: System.Environment.Exit(0); break;
                default:
                    Console.WriteLine("Você não selecionou nenhuma das opções apresentadas");
                    Menu();
                    break;
            }
        }

        static void Soma()
        {
            Console.Clear();

            Console.WriteLine("Som - Primeiro valor:");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Soma - Segundo valor:");
            float v2 = float.Parse(Console.ReadLine());

            Console.WriteLine("");

            float resultado = v1 + v2;
            // Console.WriteLine("O resultado da soma é " + (v1 + v2));
            // Console.WriteLine($"O resultado da soma é {v1 + v2}");
            // Console.WriteLine("O resultado da soma é " + resultado);
            Console.WriteLine($"O resultado da soma é {resultado}");
            Console.ReadKey();
            Menu();
        }

        static void Subtracao()
        {
            Console.Clear();

            Console.WriteLine("Subtração - Primeiro valor");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Subtração - Segundo valor");
            float v2 = float.Parse(Console.ReadLine());

            Console.WriteLine("");

            float resultado = v1 - v2;
            Console.WriteLine($"O resultado da subtração é {resultado}");
            Console.ReadKey();
            Menu();
        }

        static void Divisao()
        {
            Console.Clear();

            Console.WriteLine("Divisão - Primeiro valor:");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Divisão - Segundo valor:");
            float v2 = float.Parse(Console.ReadLine());

            float resultado = v1 / v2;

            Console.WriteLine("");

            Console.WriteLine($"O resultado da divisão é {resultado}");
            Console.ReadKey();
            Menu();
        }

        static void Multiplicacao()
        {
            Console.Clear();

            Console.WriteLine("Multi - Primeiro valor:");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Multi - Segundo valor:");
            float v2 = float.Parse(Console.ReadLine());

            Console.WriteLine("");

            float resultado = v1 * v2;
            Console.WriteLine($"O resultado da multiplicação é {resultado}");

            Console.ReadKey();
            Menu();
        }

        static void Fatorial()
        {
            Console.Clear();

            Console.WriteLine("Fatorial - Digite o número:");
            int fatorial = int.Parse(Console.ReadLine());
            int valor = fatorial
;
            for (int i = fatorial - 1; i >= 1; i--)
            {
                fatorial = fatorial * i;
            }

            Console.WriteLine("");

            Console.WriteLine($"O resultado da fatorial de {valor} é {fatorial}");

            Console.ReadKey();
            Menu();
        }
    }
}