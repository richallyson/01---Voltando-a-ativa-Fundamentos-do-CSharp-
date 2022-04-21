using System;
using System.Linq;
using System.Threading;

namespace EstudoLista11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            Console.WriteLine("=== Escreva 10 valores inteiros ===");
            var valores = new int[10];
            int media = 0;
            Thread.Sleep(1500);
            for (int i = 0; i < valores.Length; i++)
            {
                Console.WriteLine($"Digite o numero {i} da lista");
                valores[i] = int.Parse(Console.ReadLine());
                media += valores[i];
                Console.WriteLine("=================================");
            }

            var ordenar = valores.OrderByDescending(n => n);
            var listaOrdenada = ordenar.ToArray();

            Console.Clear();

            Console.WriteLine($"O maior numero dessa lista é o {listaOrdenada[0]}");
            Console.WriteLine($"O menor numero dessa lista é o {listaOrdenada[listaOrdenada.Length - 1]}");
            Console.WriteLine($"A média de todos os numeros é {media / 10}");

            // === IMPRIMINDO OS MULTIPLOS DE 10 ==

            // var numeros = new int[101];

            // for (int i = 0; i < numeros.Length; i++)
            // {
            //     numeros[i] = i + 1;
            //     //Console.WriteLine(numeros[i] = i);
            //     if ((numeros[i] % 10) == 0)
            //     {
            //         Console.WriteLine($"O numero {numeros[i]} é multiplo de 10");
            //     }
            // }
        }
    }
}
