using System;
using System.Globalization;
using System.Threading;

namespace EstudoLista13
{
    class Program
    {
        static void Main(string[] args)
        {
            // Essa é uma atividade bem suave de se fazer. Vou fazer ela com uma barrinha de loading pra ficar diferenciada
            CalculaSalario();

            Console.WriteLine("");
            Console.WriteLine("==========================================");
            Console.WriteLine("Você deseja fechar o programa?");
            Console.WriteLine("S - Para fechar");
            Console.WriteLine("C - Para continuar usando");

            var escolha = Console.ReadLine().ToLower();

            switch (escolha)
            {
                case "s":
                    Console.WriteLine("Muito obrigado! Até mais.");
                    Thread.Sleep(1500);
                    Environment.Exit(0);
                    break;
                default: CalculaSalario(); break;
            }
        }

        public static void CalculaSalario()
        {

            Console.Clear();

            Console.WriteLine("== Calculando o salário a partir das horas trabalhadas ==");
            Console.WriteLine("==========================================================");

            Console.WriteLine("= Aperte ENTER para gerar o seu ID =");
            Console.ReadKey();
            Console.Clear();
            // Usar o Guid aqui, pois nunca apliquei ele em um projeto prático
            // Apesar de que nessa atividade ele não vai ter uso, mas vai ficar mais legal com ele do quê com um ID fixo
            // Não vou nem alocar a guid pra alguma outra varievel, apenas vou chamar ela no fim do programa
            Guid guid = Guid.NewGuid();
            Loading();

            Console.Clear();
            Console.WriteLine("Agora digite o numero de horas que você trabalhou nesse mês:");
            Console.WriteLine(" ");
            var horasTrabalhadas = int.Parse(Console.ReadLine());
            var horasExtras = horasTrabalhadas;

            if (horasTrabalhadas > 50)
            {
                horasExtras = horasTrabalhadas;
                horasTrabalhadas = 50;
                horasExtras = horasExtras - 50;
            }
            else
                horasExtras = 0;

            var salarioTotal = 0.0m;
            var salarioExcedente = 0.0m;

            // Só estou usando uma estrutura de repetição pra treinar mesmo, mas nesse contexto não teria necessidade
            // O contexto é de que a hr trabalhada vale 10 reais, eu poderia muito bem multiplicar direto na variavel
            // Assim como a hora extra tbm
            for (int i = 0; i < horasTrabalhadas; i++)
            {
                salarioTotal += 10;
            }

            // Aqui abaixo eu vou usar a forma como eu falei acima, de pegar o excedente da hora extra e já multiplicar pelo valor 20
            // Vou fazer um if só pra saber da existência da hora extra, mas isso não é necessário
            if (horasExtras > 0)
            {
                salarioExcedente = horasExtras * 20;
            }

            // Vou aplicar um culture para ele já trazer o valor em real
            Console.Clear();
            Console.WriteLine($"Sua id é: {guid}");
            Console.WriteLine($"Nesse mês você trabalhou {horasTrabalhadas} horas e {horasExtras} horas extras");
            Console.WriteLine($"Seu salário esse mês é de {salarioTotal.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"))} das horas normais e {salarioExcedente.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR"))} de horas extras");
        }

        public static void Loading()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Estamos gerando o seu ID. Aguarde...");
            Console.CursorVisible = false;
            Console.SetCursorPosition(1, 1);

            for (int i = 0; i < 101; i++)
            {
                for (int y = 0; y < i; y++)
                {
                    string bar = "\u2551";
                    Console.Write(bar);
                }
                Console.Write(i + " /100");
                Console.SetCursorPosition(0, 1);
                Thread.Sleep(50);

            }

            Console.WriteLine("");
            Console.WriteLine("Seu código está pronto. Aperte ENTER para continuar");
            Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorVisible = true;
            Console.SetCursorPosition(0, 0);

        }
    }
}
