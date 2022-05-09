// using System;

// namespace Payments
// {
//     class Program
//     {

//         static void Main(string[] args)
//         {
//             //var pagamento = new Pagamento();
//             // pagamento.Dispose();

//             // Testando classe estatica
//             Settings.API_URL = "5";

//             using (var pagamento = new Pagamento())
//             {
//                 Console.WriteLine("Processando o pagamento");
//             }
//         }
//     }

//     // IDisposable é um herança que funciona a partir de uma interface criada, chamada Dispose
//     // Essa função Dispose serve para destruir o arquivo que você chamou, sendo assim, limpando espaço na memória
//     // Porém, é sempre bom usar o using, pois ele já faz todo esse serviço de criar e destruir. 
//     // Mas é sempre bom conhecer

//     public class Pagamento : IDisposable
//     {
//         public Pagamento()
//         {
//             Console.WriteLine("Inicializando o projeto");
//         }

//         public void Dispose()
//         {
//             Console.WriteLine("Finalizando o projeto");
//         }
//     }

//     // CLASSES static não podem ser instanciadas. Ela vai ser setada assim que iniciar o programa
//     // Sendo assim, você não precisa nem instanciar ela, mas simplesmente chamar algo de dentro dela como mostrado na main
//     // A vantagem dessa classe vem quando você precisa usar uma classe de forma global e que não vai ser instanciada
//     // Abaixo segue um exemplo de um tipo de classe que é vantajosa ser static
//     // Como as settings são coisas relacionadas a toda a aplicação, é de boa prática deixar ela também como static
//     public static class Settings
//     {
//         // Tudo que for criado dentro duma classe static tem que ser também instanciado como static
//         // Seja propriedades, metedos, etc
//         public static string API_URL { get; set; }
//     }

//     // SEALED é usado para selar uma classe. Ou seja, se eu criar outra classe... 
//     // não posso usar uma classe sealed como pai, não posso fazer herança dela
//     // Isso se aplica em um cenário que se deseja a garantia que uma classe tenha apenas uma forma

//     public sealed class PagamentoCartao
//     {

//     }
// }