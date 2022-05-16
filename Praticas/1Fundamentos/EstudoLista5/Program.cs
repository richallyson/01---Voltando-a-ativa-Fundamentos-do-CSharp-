using System;
using System.Collections;
using System.Linq;
using System.Threading;

namespace EstudoLista5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            Console.WriteLine("Digite o tamanho da Array:");
            var qtd = new int[int.Parse(Console.ReadLine())];

            for (int i = 0; i < qtd.Length; i++)
            {
                Console.WriteLine($"Digite o valor de do indice {i}:");
                qtd[i] = int.Parse(Console.ReadLine());

                var valorAntigo = qtd[i];

                var fatorado = Fatorial_Recursao(qtd[i]);

                Console.WriteLine("Estamos aplicando o fatorial no seu numero!");
                Thread.Sleep(1000);

                Console.WriteLine(@$"O valor {valorAntigo} fatorado é {fatorado}");
            }
        }

        public static int Fatorial_Recursao(int numero)
        {
            if (numero == 1)
                return 1;
            else
                return numero * Fatorial_Recursao(numero - 1);
        }
    }
}
