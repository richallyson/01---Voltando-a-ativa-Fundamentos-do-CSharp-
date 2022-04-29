using System;

namespace EstudoLista1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vamos preencher as informações de três pessoas.");
            var maiorValor = 0;
            var pessoa1 = new Pessoa("teste", 1);
            var pessoa2 = new Pessoa("Tatiana Cabral", 40);
            maiorValor = pessoa1.Idade < pessoa2.Idade ? pessoa2.Idade : pessoa1.Idade;
            var pessoa3 = new Pessoa("Edward Elric", 20);
            maiorValor = maiorValor < pessoa3.Idade ? pessoa3.Idade : maiorValor;

            if (pessoa1.Idade == maiorValor)
            {
                //Console.WriteLine($"A pessoa mais velha é a: {pessoa1.Nome}");
                pessoa1.ExibirDados();
            }
            else if (pessoa2.Idade == maiorValor)
            {
                //Console.WriteLine($"A pessoa mais velha é a: {pessoa2.Nome}");
                pessoa2.ExibirDados();
            }
            else if (pessoa3.Idade == maiorValor)
            {
                //Console.WriteLine($"A pessoa mais velha é a: {pessoa3.Nome}");
                pessoa3.ExibirDados();
            }

        }
    }

}
