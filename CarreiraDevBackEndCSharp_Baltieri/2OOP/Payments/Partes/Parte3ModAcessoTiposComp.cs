// using System;

// namespace Payments
// {
//     class Parte3
//     {
//         static void Main(string[] args)
//         {
//             var pag = new Pagamento();
//         }

//         // === MODIFICADORES DE ACESSO ===
//         // Os modificadores são o public, internal, protected e private        
//         // Internal = Pode ser acessivel dentro do mesmo namespace
//         // Public = pode ser acessado em qualquer lugar
//         public class Pagamento
//         {
//             // Private = Só vai ser visivel dentro da classe
//             private DateTime Vencimento;

//             // Caso você não defina o modificador de acesso de algo, ele como padrão vem private, como na variavel teste.            
//             protected int Test;

//             // Protected = Só pode ser acessado pelas classes filhas
//             protected void Pagar()
//             {

//             }
//         }

//         // === TIPOS COMPLEXOS ===
//         // Toda vez que criamos uma classe ou struct, estamos criando um tipo
//         // Qualquer tipo que contenha uma complexidade em si, é chamado de tipo complexo
//         // A classe pagamento foi criada, e dentro dela temos (caso queira) propriedades, metodos e eventos
//         // Após isso eu posso instanciar um objeto usando essa classe
//         // Ou seja, uma classe é um tipo complexo, assim como o DateTime, etc
//         // Como dito, qualquer tipo coisa que tenha uma complexidade dentro dela, e possa ser instanciado com a criação de um objeto, é um tipo complexo
//         // Evite usar apenas tipos primitivos nas suas classes, como int, bol, char, etc...
//         // Sempre procure usar tipos complexos, pois isso vai facilitar tanto a sua vida quanto a vida da sua memória
//         public class PagamentoBoleto : Pagamento
//         {
//             Adress adress;
//             // Para acessar algo protected da classe pai, você precisa antes botar o base.
//             void Teste()
//             {
//                 base.Pagar();
//             }
//         }

//         // Vamos supor que eu preciso da classe de endereço de cobrança, e ao invés de criar uma propriedade de uma string...
//         // Eu vou criar uma classe especifica disso que contém todas funcionalidades que seria nacessária dentro disso
//         public class Adress
//         {
//             string ZipCode;
//             int teste;
//             void Teste()
//             {

//             }
//         }
//     }
// }
