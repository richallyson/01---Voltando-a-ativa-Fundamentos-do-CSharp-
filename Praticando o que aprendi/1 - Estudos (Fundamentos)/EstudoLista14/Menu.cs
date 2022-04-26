using System;
using System.Threading;

namespace EstudoLista14
{
    public static class Menu
    {
        public static void Show()
        {
            // Aqui eu poderia ter desenhado todas essas caixinhas usando um FOR, mas na aula EditorHTML do Balta...
            // Que esta na pasta cursos do balta/1 - Fundamentos, eu já fiz isso. Então resolvi fazer na mão msm
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("============= ESCOLHA SUA AÇÃO ===============");
            Console.WriteLine("==============================================");
            Console.WriteLine("=       1 - GERAR FOLHA DE PAGAMENTOS        =");
            Console.WriteLine("=       2 - ABRIR FOLHA DE PAGAMENTOS        =");
            Console.WriteLine("=                  3 - SAIR                  =");
            Console.WriteLine("==============================================");
            var escolha = int.Parse(Console.ReadLine());

            switch (escolha)
            {
                case 1: Actions.Criar(); break;
                case 2: Actions.Open(); break;
                case 3: Environment.Exit(0); break;
                default: Menu.Show(); break;
            }
        }
    }
}