using System;
using System.Globalization;

namespace Moedas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            // === Melhor tipo para moeda

            // // Para se trabalhar com valores de moeda o decimal é bom caso se precise de uma precisão maior
            // // O mais recomendado pra trabalhar com moeda
            // // lembrando de sempre colocar o m depois do valor
            // // Trabalhor com preço, bufunfa, usar o decimal
            // decimal valor = 10586.25m;

            // === Formatadores ===

            // // Abaixo vamos mostrar o valor da moeda para a cultura especifica
            // // Se a gente só imprimir o valor, ele vai vir com o ponto, mas por exemplo
            // // Na cultura br a gente usa a virgula ao invés do ponto
            // // Então, para transformar a apresentação desse valor para a cultura do BR, a gente faz isso:
            // Console.WriteLine(valor.ToString(CultureInfo.CreateSpecificCulture("pt-BR")));

            // // Agora aqui abaixo a gente vai ver alguns formatadores, como os que o date tem
            // // Lembrando que os do date eram aqueles: m, M, d, D, y, yyy, etc...
            // // Depois pesquisar os formatadores, existem alguns, mas não tão livres quanto os de date
            // // O formatador g, é o padrão, ele transforma no valor que foi apresentado dentro da variavel criada, sem alterar pra cultura nenhuma
            // // O formatador C é de currency, ele já coloca tudo em padrão de moeda, com o R$ e tudo
            // // No caso da moeda que a gente ta chamando, que é o real, se a cultura for outra, ele vai apresentar o cifrão daquela outra moeda
            // Console.WriteLine(valor.ToString("G", CultureInfo.CreateSpecificCulture("pt-BR")));
            // Console.WriteLine(valor.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR")));
            // Console.WriteLine(valor.ToString("E04", CultureInfo.CreateSpecificCulture("pt-BR")));
            // Console.WriteLine(valor.ToString("F", CultureInfo.CreateSpecificCulture("pt-BR")));
            // Console.WriteLine(valor.ToString("N", CultureInfo.CreateSpecificCulture("pt-BR")));
            // Console.WriteLine(valor.ToString("P", CultureInfo.CreateSpecificCulture("pt-BR")));

            // === Math ===

            decimal valor = 10586.25m;

            // O math são expressões matematicas que são usadas para um certo contexto
            // Muito usadas para moedas

            // Abaixo os metodos mais utilizados, segundo o Balta, quando se trabalha com moedas e whatever

            // Abaixo vemos um exemplo do uso de math para arredondar o valor da moeda
            Console.WriteLine(Math.Round(valor));

            // O Ceiling arredonda sempre pra cima
            Console.WriteLine(Math.Ceiling(valor));

            // O Floor arredonda para baixo
            Console.WriteLine(Math.Floor(valor));



        }
    }
}
