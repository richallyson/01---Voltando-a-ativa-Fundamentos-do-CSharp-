// using System;

// namespace Payments
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {

//         }

//         public interface IPagamento
//         {
//             DateTime Vencimento { get; set; }

//             void Pagar(double valor);
//         }

//         // Uma classe ABSTRACT não pode ser instanciada, apenas herdada
//         // E porquê transformar Pagamento em uma classe que não pode ser instanciada?
//         // Bem a ideia em si de pagamento é abastrata. Quando você pensa em realizar um pagamento por um sistema...
//         // Você pensa em pagamento via cartão, pix, applepay, etc. Mas nunca pensa como apenas pagamento
//         // Sendo assim, o pagamento é uma ideia, uma abstração, e as formas de pagar é que são as coisas não abstratas
//         public abstract class Pagamento : IPagamento
//         {
//             public DateTime Vencimento { get; set; }

//             public virtual void Pagar(double valor)
//             {

//             }
//         }

//         // Aqui eu to usando a interface na classe Pagamento, e ao invés de ficar sempre chamando a interface...
//         // E preenchendo com as coisas do contrato, eu herdo a classe Pagamento, e ta tudo resolvido
//         public class PagamentoCartaoCredito : Pagamento
//         {
//             public override void Pagar(double valor)
//             {
//                 base.Pagar(valor);
//             }
//         }

//         public class PagamentoBoleto : Pagamento
//         {
//             public override void Pagar(double valor)
//             {
//                 base.Pagar(valor);
//             }
//         }

//         public class PagamentoApplePay : Pagamento
//         {
//             public override void Pagar(double valor)
//             {
//                 base.Pagar(valor);
//             }
//         }
//     }
// }