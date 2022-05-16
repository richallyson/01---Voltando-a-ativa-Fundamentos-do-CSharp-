using System;
using System.Text.RegularExpressions;

namespace EditorHTML
{

    public static class Viewer
    {
        public static void Show(string text)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("== MODO VISUALIZAÇÃO ==");
            Console.WriteLine("------------------");
            Replace(text);
            Console.WriteLine("------------------");
            Console.ReadKey();
            Menu.Show();
        }

        public static void Replace(string text)
        {
            // Regular expression é uma string que substitui outra string de n formas diferentes
            // Você basicamente coloca a expressão dentro do regex e ele converte para uma função 
            // Ou seja, ele vai pegar a string <strong> e </strong> e substituir pra uma funcionalidade, mesmo ela ainda sendo uma string
            // Se eu passei essa string strong, quando eu chamar ela dentro de algo, ele vai ativar a função atribuida aquela string
            // Você passa uma expressão regular dentro do regex
            // Uma expressão regular sempre tem caractere de escape, então tem sempre que botar o @ antes da string passada
            // Essa função dentro do regex vai trazer tudo o que entre o strong e o /strong
            var strong = new Regex(@"<\s*strong[^>]*>(.*?)<\s*/\s*strong>");
            // Pegando todas as palavras e separando elas
            var words = text.Split(' ');

            // Percorrer todas as palavras
            for (int i = 0; i < words.Length; i++)
            {
                // Saber se a palavra está entre strong e /strong
                // word[i] é pra avaliar cada indice dentro da array de strings
                if (strong.IsMatch(words[i]))
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write(
                        words[i].Substring(
                            words[i].IndexOf('>') + 1,
                            (
                                (words[i].LastIndexOf('<') - 1) -
                                 words[i].IndexOf('>')
                            )
                        )
                    );
                    Console.Write(" ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(words[i]);
                    Console.Write(" ");
                }
            }
        }
    }
}