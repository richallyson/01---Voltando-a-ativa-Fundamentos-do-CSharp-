using System;

namespace EstudoAgenda
{
    class Program
    {
        static void Main(string[] args)
        {
            Agenda tarefa1 = new Agenda(1, "Programar", 8);
        }


    }

    struct Agenda
    {
        public Agenda(int id, string tarefa, float horas)
        {
            Id = id;
            Tarefa = tarefa;
            Horas = horas;

            Console.WriteLine($"A sua {id}º, tarefa é: {tarefa}. E você tem {horas} horas para realizar ela");
        }

        public int Id;
        public string Tarefa;
        public float Horas;
    }
}
