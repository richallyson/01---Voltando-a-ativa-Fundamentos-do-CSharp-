// using System;

// namespace Payments
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             // UPCAST
//             // Isso só é possivel pois as classes filhas tem todas as informações da classe pai
//             var pessoa = new Pessoa();
//             pessoa = new PessoaFisica();
//             pessoa = new PessoaJuridica();

//             // DOWNCAST
//             // Para realizar o contrário, na assimilação de uma filha para um pai, é necessário fazer um casting
//             // Novamente, isso só pode ser feito, se elas tiverem propriedades similares, ou seja, através de herança
//             var pessoaFisica = new PessoaFisica();
//             var pessoaJuridica = new PessoaJuridica();
//             pessoaFisica = (PessoaFisica)pessoa;

//             // Não é possivel fazer UPCAST ou DOWNCAST com quem está no mesmo nivel. Ou seja, não tem como fazer isso de classe filha para classe filha



//         }
//         // UPCAST é a assimilação de um objeto filho para o objeto pai
//         // E bem, esse conceito se da, pois é algo que vem de baixo para cima
//         // Mas como assim de baixo para cima?
//         // Podemos dizer que uma classe filha, também é poi, pois no fim, ela vai possuir todas as props...
//         // Metodos e eventos da classe pai + as suas próprias especificidades
//         // Sendo assim o UPCAST é possivel. É possivel instanciar uma classe pai e depois fazer uma assimilação de uma classe filha para o pai

//         public class Pessoa
//         {
//             public string Nome { get; set; }
//         }

//         public class PessoaFisica : Pessoa
//         {
//             public string CPF { get; set; }
//         }

//         public class PessoaJuridica : Pessoa
//         {
//             public string CNPJ { get; set; }
//         }




//     }
// }