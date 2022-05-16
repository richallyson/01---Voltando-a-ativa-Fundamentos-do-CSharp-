using System;

namespace EstudoLista12
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

            Console.WriteLine("=== CALCULADORA DE DOIS NUMEROS ===");
            Console.WriteLine("====================");
            Console.WriteLine("Qual operação deseja realizar?");
            Console.WriteLine("1 - Soma");
            Console.WriteLine("2 - Subtração");
            Console.WriteLine("3 - Divisão");
            Console.WriteLine("4 - Multiplicação");
            var op = int.Parse(Console.ReadLine());

            switch (op)
            {
                case 1: Soma(); break;
                case 2: Subtracao(); break;
                case 3: Divisao(); break;
                case 4: Multi(); break;
            }

        }

        public static void Soma()
        {
            Console.Clear();
            Console.WriteLine("=== SOMA ===");
            Console.WriteLine("");
            Console.WriteLine("Digite o primeiro numero");
            var num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o segundo numero");
            var num2 = int.Parse(Console.ReadLine());

            Console.WriteLine($"O resultado da soma é: {num1 + num2}");
            Console.WriteLine("");

            Console.WriteLine("Deseja voltar para o menu novamente?");
            Console.WriteLine("Digite S para continar, ou qualquer outra tecla para sair");
            var escolha = Console.ReadLine().ToLower();

            if (escolha == "s")
            {
                Menu();
            }
            else
                Environment.Exit(0);
        }

        public static void Subtracao()
        {
            Console.Clear();
            Console.WriteLine("=== SUBTRAÇÃO ===");
            Console.WriteLine("");
            Console.WriteLine("Digite o primeiro numero");
            var num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o segundo numero");
            var num2 = int.Parse(Console.ReadLine());

            Console.WriteLine($"O resultado da soma é: {num1 - num2}");
            Console.WriteLine("");

            Console.WriteLine("Deseja voltar para o menu novamente?");
            Console.WriteLine("Digite S para continar, ou qualquer outra tecla para sair");
            var escolha = Console.ReadLine().ToLower();

            if (escolha == "s")
            {
                Menu();
            }
            else
                Environment.Exit(0);
        }

        public static void Divisao()
        {
            Console.Clear();
            Console.WriteLine("=== DIVISÃO ===");
            Console.WriteLine("");
            Console.WriteLine("Digite o primeiro numero");
            var num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o segundo numero");
            var num2 = int.Parse(Console.ReadLine());

            Console.WriteLine($"O resultado da soma é: {num1 / num2}");
            Console.WriteLine("");

            Console.WriteLine("Deseja voltar para o menu novamente?");
            Console.WriteLine("Digite S para continar, ou qualquer outra tecla para sair");
            var escolha = Console.ReadLine().ToLower();

            if (escolha == "s")
            {
                Menu();
            }
            else
                Environment.Exit(0);
        }

        public static void Multi()
        {
            Console.Clear();
            Console.WriteLine("=== MULTIPLICAÇÃO ===");
            Console.WriteLine("");
            Console.WriteLine("Digite o primeiro numero");
            var num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o segundo numero");
            var num2 = int.Parse(Console.ReadLine());

            Console.WriteLine($"O resultado da soma é: {num1 * num2}");
            Console.WriteLine("");

            Console.WriteLine("Deseja voltar para o menu novamente?");
            Console.WriteLine("Digite S para continar, ou qualquer outra tecla para sair");
            var escolha = Console.ReadLine().ToLower();

            if (escolha == "s")
            {
                Menu();
            }
            else
                Environment.Exit(0);

        }
    }
}