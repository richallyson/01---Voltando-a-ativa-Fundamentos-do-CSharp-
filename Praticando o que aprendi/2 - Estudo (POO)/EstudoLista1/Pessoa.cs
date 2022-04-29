using System;

namespace EstudoLista1
{
    class Pessoa
    {
        public string Nome { get; set; }
        public int Idade { get; set; }

        public Pessoa(string nome, int idade)
        {
            // Eu poderia setar o valor normal, como Nome = nome. Mas resolvi logo passar a função como atributo. Teste das duas formas
            Nome = SetNome(nome);
            Idade = SetIdade(idade);
        }

        static string SetNome(string nome)
        {
            Console.WriteLine("Escreva o nome da pessoa:");
            return nome = Console.ReadLine();
        }

        static int SetIdade(int idade)
        {
            Console.WriteLine("Escreva a idade da pessoa:");
            return idade = int.Parse(Console.ReadLine());
        }

        public void ExibirDados()
        {
            Console.WriteLine($"O nome da pessoa é: {this.Nome}");
            Console.WriteLine($"A idade da pessoa é: {this.Idade}");
        }
    }
}
