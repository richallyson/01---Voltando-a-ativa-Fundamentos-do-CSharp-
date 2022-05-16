using System;

namespace EstudoLista8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            var arrNumeros = new double[19];
            int iterador = 0;
            Console.WriteLine("Iremos trazer a soma dos quadrados dos próximos 20 numeros digitados");
            Console.WriteLine("Lembrando que aceitamos apenas numeros impares, e entre 0 e 10");

            for (int i = 0; i < arrNumeros.Length; i = iterador)
            {
                Console.WriteLine($"{i} - Digite um numero:");
                var valor = double.Parse(Console.ReadLine());

                if (valor > 0 && valor <= 10)
                {
                    if (valor % 2 != 0)
                    {
                        arrNumeros[i] = valor * valor;
                        Console.WriteLine($"A soma dos quadrados do numero {valor} é igual a {arrNumeros[i]}");
                        iterador++;
                    }
                    else
                        Console.WriteLine("Seu valor é par. Não aceitamos pares");
                }
                else
                    Console.WriteLine("Seu valor é menor que 0 ou maior que 10");
            }
        }
    }
}