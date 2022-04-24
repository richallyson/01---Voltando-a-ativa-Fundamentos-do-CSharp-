using System;
using System.Threading;

namespace Stopwatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Como você deseja realizar a sua contagem?");
            Console.WriteLine("S = Segundos => 10s = 10 segundos");
            Console.WriteLine("M = Minutos => 1m = 1 minuto");
            Console.WriteLine("0 = Sair");

            Console.WriteLine("");
            Console.WriteLine("==============================");
            Console.WriteLine("");

            Console.WriteLine("Você deseja incrementar ou decrementar o tempo?");
            Console.WriteLine("I = Incrementar");
            Console.WriteLine("D = Decrementar");

            char timeMode = char.Parse(Console.ReadLine().ToLower());

            Console.WriteLine("");
            Console.WriteLine("==============================");
            Console.WriteLine("");

            Console.WriteLine("Quanto tempo deseja contar?");

            string data = Console.ReadLine().ToLower();
            // Aqui no char ele vai pegar o ultimo caractere, e apenas um caractere da lista de strings
            // O primeiro parametro retorna de onde eu quero começar a pegar o caractere
            // E o segundo parametro diz quantos caracteres quero pegar
            // Se eu digitasse 1 e 1, ele pegaria o segundo caractere e apenas

            char type = char.Parse(data.Substring(data.Length - 1, 1));
            //Exemplo com a string data
            // Aqui eu vou pegar a string que recebo no data, do 0 até 4. Se eu digitar "testando", vou pegar apenas o terecho test
            //var teste = (data.Substring(0, 4));
            //Aqui no int ele vai pegar do caractere 0 da string, até o penultimo.
            int time = int.Parse(data.Substring(0, data.Length - 1));
            int multiplier = 1;

            if (type == 'm')
                multiplier = 60;

            if (time == 0)
                System.Environment.Exit(0);

            if (timeMode == 'i')
                IncreaseTime(time * multiplier);

            if (timeMode == 'd')
            {
                if (type == 'm')
                {
                    DecreaseTime(time * multiplier);
                }
                else
                    DecreaseTime(time * multiplier);
            }
        }

        static void IncreaseTime(int time)
        {

            //int currentTime = 0;

            for (int i = 1; i != time; i++)
            {
                Console.Clear();
                //currentTime++;
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }

            // while (currentTime != time)
            // {
            //     Console.Clear();
            //     currentTime++;
            //     Console.WriteLine(currentTime);
            //     Thread.Sleep(1000);
            // }

            Console.Clear();
            Console.WriteLine("Stopwatch crescente finalizado!");
            Thread.Sleep(2500);
            Menu();
        }

        static void DecreaseTime(int time)
        {
            //int currentTime = time;

            for (int i = time; i != 0; i--)
            {
                Console.Clear();
                //currentTime--;
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }

            // while (currentTime != 0)
            // {
            //     Console.Clear();
            //     currentTime--;
            //     Console.WriteLine(currentTime);
            //     Thread.Sleep(1000);
            // }

            Console.Clear();
            Console.WriteLine("Stopwatch decrescente finalizado!");
            Thread.Sleep(2500);
            Menu();
        }
    }
}
