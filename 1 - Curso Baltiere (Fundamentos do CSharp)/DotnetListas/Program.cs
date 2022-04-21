using System;

namespace DotnetListas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            var funcionarios = new Funcionario[5];

            for (int i = 0; i < funcionarios.Length; i++)
            {
                Console.WriteLine("Digite o id do funcionario");
                // Resposta do balta sobre a duvida: Neste caso, não, pois os itens já existem no array, 
                //agora se você tentar atribuir um valor ao Id de um item que não existe, vai dar erro.
                //funcionarios[i].Id = int.Parse(Console.ReadLine());
                funcionarios[i] = new Funcionario() { Id = int.Parse(Console.ReadLine()) };
            }

            Console.WriteLine("==============");

            foreach (var funcionario in funcionarios)
            {
                Console.WriteLine(funcionario.Id);
            }
        }

        public struct Funcionario
        {
            public int Id { get; set; }
        }
    }
}
