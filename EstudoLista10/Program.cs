using System;
using System.Linq;
using System.Threading;

namespace EstudoLista10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            Console.WriteLine("Digite o quantos numeros tem a lista");
            var listaNum = new int[int.Parse(Console.ReadLine())];
            //var listaClone = (int[])listaNum.Clone();

            Console.Clear();

            Console.WriteLine("Agora vamos preencher essa lista com numeros!!");
            Thread.Sleep(2000);

            for (int i = 0; i < listaNum.Length; i++)
            {
                if (listaNum[i] >= 0)
                {
                    Console.WriteLine("Digite um numero:");
                    listaNum[i] = int.Parse(Console.ReadLine());
                    Console.Clear();
                }
                if (listaNum[i] < 0)
                {
                    Console.WriteLine("O programa foi encerrado, pois você digitou um numero negativo!");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                }

            }

            int maiorNum = 0;
            int menorNum = 0;

            var ordenar = listaNum.OrderByDescending(n => n);
            var listaOrdenada = ordenar.ToArray();

            maiorNum = listaOrdenada[0];
            menorNum = listaOrdenada[listaOrdenada.Length - 1];

            Console.WriteLine($"O maior numero da lista é o {maiorNum} e o menor numero da lista é o {menorNum}");


        }
    }
}
