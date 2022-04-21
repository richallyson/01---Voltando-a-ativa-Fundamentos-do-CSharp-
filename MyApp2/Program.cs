using System;
using System.Text;

namespace MyApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            // === GUIDS === Gerador de id automatico
            // var id = Guid.NewGuid();
            // id.ToString();

            // //id = new Guid("7b9213fc-8d5c-4179-9fe9-5186de7a116f");
            // Console.WriteLine(id);

            // === TIPOS DE INTERPOLAÇÃO DE STRING ===
            // var price = 10.2;
            // // Pega o valor assemelhado e concatena na string
            // var texto = string.Format(
            // "O preço do produto é {0} apenas na promoção e {1}",
            // price,
            // true);

            // var texto2 = string.Format(
            // "O preço do produto é {1} apenas na promoção e {2}",
            // price,
            // true);

            // // O clássico cifrão
            // // Se adicionar um @ antes da string, é possivel quebrar linha
            // // O @ também é bom caso precise usar algum caractere especial de string dentro da string, como o /n. Ele não vai quebrar linha se tiver o @
            // var texto3 = $@"Quanto é o 
            // preço do teste? É {price}";

            // Console.WriteLine(texto2);

            // === COMPARAÇÃO DE STRING ===
            // var texto = "Testando";
            // CompateTo retorna um int, sendo 0 true e 1 false
            // Console.WriteLine(texto.CompareTo("Testando"));
            // Console.WriteLine(texto.CompareTo("testando"));

            // var texto2 = "Este texto é um teste";
            // Contains retorna um booleano, e analisa se contém algo dentro do texto, e n uma comparação
            // Console.WriteLine(texto2.Contains("teste"));
            // Console.WriteLine(texto2.Contains("Teste"));
            // // Esse argumento dps da string, faz com que o case sensitive seja ignorado. Sendo assim, n importa se a letra ta maiuscula ou minuscula. Ele vai achar a palavra ou letra, caso ela esteja dentro da string
            // // Tanto o Compare quanto o Contains pode comparar a string com qualquer coisa, seja objeto, array, etc. Porém vai dar erro se o objeto n for valido
            // Console.WriteLine(texto2.Contains("Teste", StringComparison.OrdinalIgnoreCase));
            // Console.WriteLine(texto2.Contains(null));

            // === StartsWith e EndsWith ===
            // var texto = "Este texto é um teste.";
            // // Não da pra usar o ToLower para transformar a string em minuscula, pois o starts retorna um booleano. A não ser que transforma em string 
            // Console.WriteLine(texto.StartsWith("Este"));
            // // Essa é uma forma de ignorar o case sentitive
            // Console.WriteLine(texto.StartsWith("este", StringComparison.OrdinalIgnoreCase));
            // Console.WriteLine(texto.StartsWith("texto"));

            // Console.WriteLine(texto.EndsWith("Teste"));
            // Console.WriteLine(texto.EndsWith("teste"));
            // Console.WriteLine(texto.EndsWith("teste", StringComparison.OrdinalIgnoreCase));

            // === Equals ===
            // var texto = "Este texto é um teste";
            // A string tem que ser exatamente igual para retornar true
            // Equals serve pra qualquer tipo de objeto, e sempre precisa ser igual para retornar true
            // var teste = 33;
            // teste.Equals(33);
            // Console.WriteLine(texto.Equals("Este"));
            // Console.WriteLine(texto.Equals("Este texto é um teste"));
            // Console.WriteLine(texto.Equals("este texto é um teste"));
            // Console.WriteLine(texto.Equals("este texto é um teste", StringComparison.OrdinalIgnoreCase));

            // // === Indices ===
            // var texto = "Este texto é um teste";
            // // Retorna uma posição dentro de uma array
            // // Uma string é uma lista/array de caracteres
            // // Index pode ser usado pra qualquer tipo, e você deve passar o tipo especifico ao que vc quer
            // // Talvez dê pra converter dentro e talz, aquelas paradas
            // Console.WriteLine(texto.IndexOf("é"));
            // // Para caso eu queria encontrar o ultimo indice
            // // Por exemplo, no texto eu tenho mais de um s, com essa função ele retornaria o ultimo s, seja de uma letra ou uma palavra
            // Console.WriteLine(texto.LastIndexOf("s"));
            // // Aqui ele retorna a ultima letra da palavra dentro da array de strings
            // Console.WriteLine(texto.LastIndexOf("te"));

            // === Metodos adicionais ===
            // var texto = "Este texto é um teste";
            // Console.WriteLine(texto.ToLower());
            // Console.WriteLine(texto.ToUpper());
            // // Insere algo dentro de uma array. Como o texto é uma, ele vai inserir o texto aqui na posição 5
            // Console.WriteLine(texto.Insert(5, "AQUI "));
            // // Remove algo da lista. Abaixo a partir da posição 5, ele vai remover os próximos 5 coisas que você quer da lista
            // Console.WriteLine(texto.Remove(5, 5));
            // // Retorna o tamanho da lista. No caso, o tanto de caracteres que a string tem
            // Console.WriteLine(texto.Length);

            // === Manipulando Strings ===
            // var texto = " Este texto é um teste ";
            // // Pede algo que você quer que seja substituido da lista
            // // Recebe o objeto antigo e substitui pelo novo que vocÊ deseja
            // Console.WriteLine(texto.Replace("Este", "isto"));
            // // Aqui ele vai pegar todos os elementos "e" da string e substituir por "x" 
            // Console.WriteLine(texto.Replace("e", "x"));

            // // Aqui eu to quebrando os caracteres sempre que houver um espaço
            // // Fazendo isso, o var abaixo vai se tornar uma lista
            // var divisao = texto.Split(" ");
            // Console.WriteLine(divisao[0]);
            // Console.WriteLine(divisao[1]);
            // Console.WriteLine(divisao[2]);
            // Console.WriteLine(divisao[3]);

            // // No substring eu digo onde devo começar a pegar caracteres, e quantos caracteres a frente devo retornar
            // var resultado = texto.Substring(5, 5);
            // Console.WriteLine(resultado);

            // // Remove os espaços do começo e do fim da string
            // Console.WriteLine(texto.Trim());

            // === StringBuilder ===

            // Dessa forma, toda vez que for adicionado algo ao texto, ele vai criar uma terceira variavel
            // Sendo assim, para quesito de economia de memoria, isso é não usual
            // Pois em textos enormes, como com 400 mil linhas, pode dar tela azul por falta de memoria
            var texto0 = " Este texto é um teste ";
            texto0 += "Testeandoasdaksd";

            // A melhor forma de se economizar memória é com o StringBuilder

            var texto = new StringBuilder();

            // O Append adiciona a string dento do builder, sem precisar criar uma copia, sendo assim, ocupando menos memoria
            texto.Append("Este texto é um texte");
            texto.Append("Este é um texte");
            texto.Append("Este texto é um");
            texto.Append("texte");
            texto.Append(" um texte");

            // O texto acima n é mais um tipo string, mas sim o StringBuilder
            // Sendo assim, em alguns casos, é melhor transformar o texto em string, para corre tudo bem
            texto.ToString();
        }
    }
}

