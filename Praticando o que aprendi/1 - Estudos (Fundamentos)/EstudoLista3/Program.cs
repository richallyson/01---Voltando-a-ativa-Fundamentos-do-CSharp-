using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace EstudoLista3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Digite o texto para converter para lingua Daniel:");
            string texto = Console.ReadLine();

            string pattern = @"^[a-zA-Z ]+$";
            string replace = "mulher";
            string result = Regex.Replace(texto, pattern, replace);
            Console.WriteLine(result);

            //Console.Write(texto.GetType());
        }

    }
}