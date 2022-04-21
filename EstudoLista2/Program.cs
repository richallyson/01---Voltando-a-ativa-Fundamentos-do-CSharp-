using System;
using System.Threading;

namespace EstudoLista2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Digite o valor de v1:");
            int v1 = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Digite o valor de v2:");
            int v2 = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Digite o valor de v3:");
            int v3 = int.Parse(Console.ReadLine());

            // 14 1 19
            int aux = 0;

            // v1 é 14 e v2 é 1. Não acontece nada e continua a msm coisa - 14 1 19
            if (v1 < v2)
            {
                aux = v1;
                v1 = v2;
                v2 = aux;
            }

            // v1 é 14 e v3 é 19. v1 recebe o valor de v3 e v3 recebe o valor de v1 - 19 1 14
            // Valor de v3 é 14
            if (v1 < v3)
            {
                aux = v1;
                v1 = v3;
                v3 = aux;
            }

            // v2 é 1 e v3 é 19. v2 recebe o valor de v3 e v3 recebe o valor de v2 - 19 14 1
            // Valor de v2 agora é 14 e o de v3 é 1
            if (v2 < v3)
            {
                aux = v2;
                v2 = v3;
                v3 = aux;
            }

            Console.WriteLine($"Em ordem decrescente, o primeiro valor é {v1}, o segundo valor é {v2} e o ultimo valor é {v3}.");
        }
    }
}