using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;

namespace EstudoLista14
{
    public class Actions
    {
        public static void Criar()
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("============= FOLHA DE PAGAMENTO =============");
            Console.WriteLine("==============================================");
            Console.WriteLine("== Quantos funcionarios na folha desse mês? ==");
            Console.WriteLine("==============================================");
            var funcionario = new Funcionario.Funcionarios[int.Parse(Console.ReadLine())];
            Console.WriteLine("==============================================");
            Console.WriteLine("Cada um dos funcionários possui um conjunto de dados, e esses dados são: ");
            Console.WriteLine("1 - O ID, que é gerado de forma automática");
            Console.WriteLine("2 - O Nome do funcionário");
            Console.WriteLine("3 - A Vaga que o funcionário trabalha dentro da empresa");
            Console.WriteLine("4 - O Salário que esse funcionario recebe");
            Console.WriteLine("5 - As Horas Trabalhadas que o funcionário tem por semana");
            Console.WriteLine("");
            Console.WriteLine("Pressione ENTER para continuar");
            Console.ReadKey();
            Console.WriteLine("");
            Console.WriteLine("Agora vamos preencher os dados de cada um dos funcionários da lista.");
            Thread.Sleep(3000);

            StringBuilder text = new StringBuilder();

            for (int i = 0; i < funcionario.Length; i++)
            {
                Console.WriteLine("");
                Console.WriteLine("==============================================");
                Console.WriteLine($"    Preenchendo os dados do funcionario {i + 1}");
                funcionario[i].Id = Funcionario.GeradorDeId(funcionario[i].Id);
                funcionario[i].Nome = Funcionario.NomeFuncionario(funcionario[i].Nome);
                funcionario[i].Vaga = Funcionario.VagaFuncionario(funcionario[i].Vaga);
                funcionario[i].Salario = Funcionario.SalarioFuncionario(funcionario[i].Salario);
                funcionario[i].HorasTrabalhadas = Funcionario.HorasFuncionario(funcionario[i].HorasTrabalhadas);

                text.Append("==============================================");
                text.Append(Environment.NewLine);
                text.Append("          DADOS DO FUNCIONÁRIO: " + i + "     ");
                text.Append(Environment.NewLine);
                text.Append("==============================================");
                text.Append(Environment.NewLine);
                text.Append("Id: " + funcionario[i].Id);
                text.Append(Environment.NewLine);
                text.Append("Nome completo: " + funcionario[i].Nome);
                text.Append(Environment.NewLine);
                text.Append("Vaga ocupada: " + funcionario[i].Vaga);
                text.Append(Environment.NewLine);
                text.Append("Salário: " + funcionario[i].Salario.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR")));
                text.Append(Environment.NewLine);
                text.Append("Horas semanais: " + funcionario[i].HorasTrabalhadas);
                text.Append(Environment.NewLine);
                text.Append("==============================================");
                text.Append(Environment.NewLine);
                Console.WriteLine("");

            }

            Save(text.ToString());

        }

        public static void Open()
        {
            Console.Clear();
            Console.WriteLine("Digite o endereço do arquivo que você deseja abrir:");
            var path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }

            Console.WriteLine("");
            Console.WriteLine("Pressione ENTER para voltar para o menu...");
            Console.ReadLine();
            Menu.Show();
        }

        public static void Save(string text)
        {
            Console.Clear();
            Console.WriteLine("===========================================================");
            Console.WriteLine("Em qual caminho deseja salvar o arquivo? Digite o caminho.");
            Console.WriteLine("===========================================================");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.WriteLine("==============================================");
            Console.WriteLine($"Arquivo salvo com sucesso, no caminho {path}");
            Console.WriteLine("Pressione ENTER para voltar para o Menu");
            Console.WriteLine("==============================================");
            Console.ReadLine();
            Menu.Show();
        }
    }
}