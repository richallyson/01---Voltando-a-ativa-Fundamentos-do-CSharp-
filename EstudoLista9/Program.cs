using System;

namespace EstudoLista9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            Console.WriteLine("Digite o numero de alunos que a sala possui:");
            var alunos = new int[int.Parse(Console.ReadLine()), 2];
            var notas = 0;

            for (int l = 0; l < alunos.GetLength(0); l++)
            {
                for (int c = 0; c < alunos.GetLength(1); c++)
                {
                    Console.WriteLine("Digite o numero da matricula do aluno e depois sua nota:");
                    alunos[l, c] += int.Parse(Console.ReadLine());
                    if (c == 1)
                        notas = notas + alunos[l, c];
                }
            }

            Console.WriteLine(notas);
        }
    }
}
