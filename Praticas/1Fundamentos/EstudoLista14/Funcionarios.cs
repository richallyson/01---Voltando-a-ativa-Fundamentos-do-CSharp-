using System;
using System.Threading;

namespace EstudoLista14
{
    public class Funcionario
    {
        public struct Funcionarios
        {
            public Guid Id { get; set; }
            public string Nome { get; set; }
            // Dentro da vaga eu vou criar um switch onde se existem 4 vagas para serem escolhdidas
            public string Vaga { get; set; }
            public decimal Salario { get; set; }
            public int HorasTrabalhadas { get; set; }

            public Funcionarios(Guid id, string nome, string vaga, decimal salario, int horasTrabalhadas)
            {
                Id = id;
                Nome = nome;
                Vaga = vaga;
                Salario = salario;
                HorasTrabalhadas = horasTrabalhadas;
            }

        }

        public static Guid GeradorDeId(Guid id)
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("O seu ID está sendo gerado, aguarde um momento...");
            Thread.Sleep(3000);
            Console.WriteLine("A ID do(a) funcionário(a) foi gerada com sucesso!");
            return id = Guid.NewGuid();
        }

        public static string NomeFuncionario(string nome)
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("Digite o nome do funcionário:");
            return nome = Console.ReadLine();
        }

        public static string VagaFuncionario(string vaga)
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("Digite o numero semelhante a sua vaga:");
            Console.WriteLine("1 - CEO");
            Console.WriteLine("2 - Designer");
            Console.WriteLine("3 - Programador(a)");
            Console.WriteLine("4 - Diretor(a) de Arte");

            var numVaga = int.Parse(Console.ReadLine());

            switch (numVaga)
            {
                case 1: vaga = "CEO"; break;
                case 2: vaga = "Designer"; break;
                case 3: vaga = "Programador(a)"; break;
                case 4: vaga = "Diretor(a) de Arte"; break;
                default:
                    Console.WriteLine("Você digitou algo fora do esperado.");
                    VagaFuncionario(vaga);
                    break;
            }

            return vaga;

            // Pensando bem, eu podia ter usando um enum pra isso aqui            
        }

        public static decimal SalarioFuncionario(decimal salario)
        {
            Console.WriteLine("==============================================");
            Console.WriteLine($"Digite o valor do salário:");
            return salario = decimal.Parse(Console.ReadLine());

        }

        public static int HorasFuncionario(int horas)
        {
            Console.WriteLine("==============================================");
            Console.WriteLine($"Digite o numero de horas que o funcionario precisa trabalhar na semana:");
            return horas = int.Parse(Console.ReadLine());
        }

        // Tava pensando em criar um enumerador, para separar cada um dos funcionarios em listas diferentes
        // Mas essa ideia vai ficar para depois
        // Preciso encerrar esse conteúdo para começar OO

        // public enum ETipo
        // {
        //     Treinee = 1,
        //     Junior = 2,
        //     Pleno = 3,
        //     Senior = 4
        // }
    }

}



