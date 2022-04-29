using System;

namespace EstudoLista2
{
    class Program
    {
        static void Main(string[] args)
        {
            // O intuito desse programa é criar animais, e contar quantos animais são instanciados
            // Temos 3 tipos de animais: Gatos, Cachorros e peixes
            // Devemos informar ao final quantos de cada tipo foi informado
            // Pensei em fazer esse contador na própria classe Animals, mas vou fazer logo abaixo desse menuzinho
            Console.Clear();

            Console.WriteLine("Preencha o dado de 5 animais");
            Console.WriteLine("=================================");
            Console.WriteLine("Primeiro animal:");
            var animal1 = new Animals();
            animal1.nome = animal1.SetNome();
            animal1.tipo = animal1.SetTipo();
            Console.WriteLine("=================================");
            Console.WriteLine("Segundo animal:");
            var animal2 = new Animals();
            animal2.nome = animal2.SetNome();
            animal2.tipo = animal2.SetTipo();
            Console.WriteLine("=================================");
            Console.WriteLine("Terceiro animal:");
            var animal3 = new Animals();
            animal3.nome = animal3.SetNome();
            animal3.tipo = animal3.SetTipo();
            Console.WriteLine("=================================");
            Console.WriteLine("Quarto animal:");
            var animal4 = new Animals();
            animal4.nome = animal4.SetNome();
            animal4.tipo = animal4.SetTipo();
            Console.WriteLine("=================================");
            Console.WriteLine("Quinto animal:");
            var animal5 = new Animals();
            animal5.nome = animal5.SetNome();
            animal5.tipo = animal5.SetTipo();


            // Contador dos bixos
            // Vou botar todos os animais em uma array, pq vai facilitar dms o trabalho
            var animais = new Animals[] { animal1, animal2, animal3, animal4, animal5 };
            var contadorCachorro = 0;
            var contadorGato = 0;
            var contadorPeixe = 0;

            for (int i = 0; i < animais.Length; i++)
            {
                if (animais[i].tipo == EAnimalType.Cachorro)
                    contadorCachorro += 1;

                if (animais[i].tipo == EAnimalType.Gato)
                    contadorGato += 1;

                if (animais[i].tipo == EAnimalType.Peixe)
                    contadorPeixe += 1;
            }

            Console.WriteLine($"Numero de cachorros: {contadorCachorro}");
            Console.WriteLine($"Numero de gatos: {contadorGato}");
            Console.WriteLine($"Numero de peixes: {contadorPeixe}");



        }
    }
}
