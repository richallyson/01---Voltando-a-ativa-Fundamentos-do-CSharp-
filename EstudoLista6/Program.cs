using System;
using System.Threading;

namespace EstudoLista6
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            Console.Clear();

            Console.WriteLine("Digite o numero:");
            var numero = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Escolha o tipo de operação que deseja realizar");
            Console.WriteLine("=============================");

            Console.WriteLine("1 - Adição");
            Console.WriteLine("2 - Subtração");
            Console.WriteLine("3 - Divisão");
            Console.WriteLine("4 - Multiplicação");
            Console.WriteLine("Pressione qualquer outra tecla para sair");
            var escolha = int.Parse(Console.ReadLine());

            Console.WriteLine("Estamos preparando a sua tabuada, aguarde um segundo...");
            Thread.Sleep(1000);
            switch (escolha)
            {
                case 1: Adicao(numero); break;
                case 2: Subtracao(numero); break;
                case 3: Divisao(numero); break;
                case 4: Multiplica(numero); break;
                default: System.Environment.Exit(0); break;
            }

        }

        public static void Adicao(int num)
        {
            Console.WriteLine($"A tabuada de adição do numero {num} é:");
            Thread.Sleep(1000);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{num} + {i} = {num + i}");
            }
            Console.WriteLine("Pressione qualquer tecla para voltar para o menu");
            Console.ReadKey();
            Menu();
        }

        public static void Subtracao(int num)
        {
            Console.WriteLine($"A tabuada de subtração do numero {num} é:");
            Thread.Sleep(1000);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{num} - {i} = {num - i}");
            }
            Console.WriteLine("Pressione qualquer tecla para voltar para o menu");
            Console.ReadKey();
            Menu();
        }

        public static void Divisao(int num)
        {
            Console.WriteLine($"A tabuada de divisao do numero {num} é:");
            Thread.Sleep(1000);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{num} / {i} = {num / i}");
            }
            Console.WriteLine("Pressione qualquer tecla para voltar para o menu");
            Console.ReadKey();
            Menu();
        }

        public static void Multiplica(int num)
        {
            Console.WriteLine($"A tabuada de multiplicação do numero {num} é:");
            Thread.Sleep(1000);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{num} x {i} = {num * i}");
            }
            Console.WriteLine("Pressione qualquer tecla para voltar para o menu");
            Console.ReadKey();
            Menu();
        }

    }
}
