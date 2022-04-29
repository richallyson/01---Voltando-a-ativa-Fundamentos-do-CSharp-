using System;

namespace EstudoLista2
{

    class Animals
    {
        private string Nome;
        public string nome
        {
            get
            {
                return Nome;
            }
            set
            {
                Nome = value;
            }
        }
        private EAnimalType Tipo;
        public EAnimalType tipo
        {
            get
            {
                return Tipo;
            }
            set
            {
                Tipo = value;
            }
        }

        public Animals(string nomeAnimal, EAnimalType tipoAnimal)
        {
            // Sinceramente eu não sei se isso é usual kkkkk quando eu desenvolvia jogos, nunca fiz nada parecido com isso, pois tinha medo de quebrar o jogo todo
            // No caso eu to falando de usar essa forma aqui de setar as infos do construtor usando funções
            // Não façam programa assim, pois caso você queira usar, por exemplo, em uma função aqui dentro do escopo msm da classe...
            // ELe sempre vai chamar as funções e vai ficar tudo maluco
            // Mas pra esse programa eu vou deixar assim msm, pela ciência
            nome = SetNome(nomeAnimal);
            tipo = SetTipo(tipoAnimal);
        }

        public string SetNome(string nomeAnimal)
        {
            Console.WriteLine("Digite o nome do seu animalzinho:");
            nomeAnimal = Console.ReadLine();
            return nome = nomeAnimal;
        }

        public EAnimalType SetTipo(EAnimalType tipoAnimal)
        {
            var escolha = 0;
            Console.WriteLine("Qual o tipo do seu animal? Digite o numero relacionado a ele.");
            Console.WriteLine("1 - Gato");
            Console.WriteLine("2 - Cachorro");
            Console.WriteLine("3 - Peixe");
            Console.WriteLine("Caso digite algum numero fora da lista, seu animal automaticamente vai ser considerado um peixe.");
            escolha = int.Parse(Console.ReadLine());
            switch (escolha)
            {
                case 1: tipoAnimal = EAnimalType.Gato; break;
                case 2: tipoAnimal = EAnimalType.Cachorro; break;
                case 3: tipoAnimal = EAnimalType.Peixe; break;
                default: tipoAnimal = EAnimalType.Peixe; break;

                    // if (tipo != EAnimalType.Cachorro && tipo != EAnimalType.Gato && tipo != EAnimalType.Peixe)
                    // {
                    //     tipo = EAnimalType.Peixe;
                    // }
                    // break;
            }
            return tipoAnimal;
        }
    }

    enum EAnimalType
    {
        Gato = 1,
        Cachorro = 2,
        Peixe = 3
    }
}