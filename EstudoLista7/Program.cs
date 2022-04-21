using System;

namespace EstudoLista7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            var num = new int[10];
            var somaPar = 0;
            var somaImpar = 0;
            Console.WriteLine("Digite um numero para saber se ele é par ou impar:");
            for (int i = 0; i < num.Length; i++)
            {
                int numero = int.Parse(Console.ReadLine());
                if (numero < 0)
                {
                    Console.WriteLine("Numero negativo digitado. Encerrando o programa");
                    Environment.Exit(0);
                }

                if (numero % 2 == 0)
                {
                    somaPar += numero;
                    Console.WriteLine($"O numero {numero} é par");
                }
                else
                {
                    somaImpar += numero;
                    Console.WriteLine($"O numero {numero} é impar");
                }

            }

            Console.WriteLine($"Essa foram a soma de todo(s) o(s) numero(s) par(es) escolhidos: {somaPar}");
            Console.WriteLine($"Essa foram a soma de todo(s) o(s) numero(s) impar(es) escolhidos: {somaImpar}");
        }
    }
}
