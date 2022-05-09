// using System;

// namespace Payments
// {
//     class Program
//     {
//         static void RealizarPagamento(double valor)
//         {
//             Console.WriteLine($"Pago o valor de {valor}");
//         }

//         static void Main(string[] args)
//         {
//             // DELEGATES = METODOS ANONIMOS
//             // E é assim que se realiza um delegate. A função Pagar vai delegar a tarefa para a função RealizarPagamento
//             var pagar = new Pagamento.Pagar(RealizarPagamento);
//             pagar(25);

//         }
//     }

//     public class Pagamento
//     {
//         // Vamos supor que eu quero delegar essa função para outra função
//         // Delegar é atribuir uma tarefa a algo
//         // E bem, vamos supor que eu quero delegar essa função, fazer com que outra função fora da classe faça o pagamento?
//         // Existe uma função fora do escopo da classe que já realiza a regra de negócio do pagamento, sendo assim...
//         // Não quero ter que criar a mesma função novamente. Tendo isso, podesse delegar a função
//         // Lembrando que a função que for realizar o Pagar, deve ter a mesma assinatura. Ou seja...
//         // Deve ser static, retornar vazio, e ter os mesmos parametros. O nome da função não importa.
//         // Ou seja, se eu retorno void e espero um double de entrada, a função delegada deve fazer o msm
//         public delegate void Pagar(double valor);
//     }
// }