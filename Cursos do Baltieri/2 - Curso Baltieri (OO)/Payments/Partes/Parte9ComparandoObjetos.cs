// using System;

// namespace Payments
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             // COMPARANDO OBJETOS
//             var pessoaA = new Pessoa(1, "Sasaki Kojiro");
//             var pessoaB = new Pessoa(1, "Sasaki Kojiro");

//             // Aqui será retornado False. Mas porquê?
//             // Lembra que as classe são tipos de referência? Assim como os objetos instanciados a partir delas?
//             // Psé. Nós não temos o valor real apenas o endereço pra onde esses objetos estão apontando para a memória
//             // Mas pq da False? Pq o pessoaA é um objeto que esta em um endereço diferente, assim como o pessoaB. Ou seja, são objetos diferentes.
//             //Console.WriteLine(pessoaA == pessoaB);

//             // Depois de ter herdado o IEquatable<Pessoa>
//             // Melhor forma de comparar objetos é assim
//             Console.WriteLine(pessoaA.Equals(pessoaB));

//         }


//         public class Pessoa : IEquatable<Pessoa>
//         {
//             public int Id { get; set; }
//             public string Nome { get; set; }

//             public Pessoa(int id, string nome)
//             {
//                 Id = id;
//                 Nome = nome;
//             }

//             // Interface gerada a partir da herança do IEquatable. Dentro dela você faz a validação que quiser
//             public bool Equals(Pessoa pessoa)
//             {
//                 return Id == pessoa.Id;
//             }
//         }

//     }
// }