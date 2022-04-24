using System;
using System.Linq;
using System.Threading;

namespace EstudoLista4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            int[] numeros = new int[3];

            Console.WriteLine("Digite o valor de A:");
            do
            {
                numeros[0] = int.Parse(Console.ReadLine());

                if (numeros[0] <= 0)
                {
                    Console.WriteLine("Valor inválido. Digite novamente...");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("Digite o valor de A:");
                }
            } while (numeros[0] <= 0);

            //Console.WriteLine(numeros[0]);

            Console.WriteLine("Digite o valor de B:");
            do
            {
                numeros[1] = int.Parse(Console.ReadLine());

                if (numeros[1] <= 0)
                {
                    Console.WriteLine("Valor inválido. Digite novamente...");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("Digite o valor de B:");
                }
            } while (numeros[1] <= 0);

            //Console.WriteLine(numeros[1]);

            Console.WriteLine("Digite o valor de C:");
            do
            {
                numeros[2] = int.Parse(Console.ReadLine());

                if (numeros[2] <= 0)
                {
                    Console.WriteLine("Valor inválido. Digite novamente...");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("Digite o valor de A:");
                }
            } while (numeros[2] <= 0);

            //Console.WriteLine(numeros[2]);

            var ordenar = numeros.OrderByDescending(n => n);

            int[] dec = new int[3];
            int i = 0;

            foreach (var o in ordenar)
            {
                dec[i] = o;
                i++;
            }

            int menor = dec[2];
            int maior = dec[0];

            Console.WriteLine($"O menor valor digitado foi {menor}");
            Console.WriteLine($"O maior valor digitado foi {maior}");
            Console.WriteLine("========================================");
            Console.WriteLine($"O menor valor lido multiplicado pelo maior é {menor * maior}");
            Console.WriteLine($"O maior valor lido dividido pelo menor é {maior / menor}");

        }

        static void MaiorZero(int num, string valor)
        {

            do
            {
                num = int.Parse(Console.ReadLine());

                if (num <= 0)
                {
                    Console.WriteLine("Valor inválido. Digite novamente...");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine($"Digite o valor de {valor}:");
                }
            } while (num <= 0);

        }
    }
}
