// using System;

// namespace Payments
// {
//     class Program
//     {
//         // Esse projeto passa por cima de todos os conceitos de OO. 
//         // Para não ficar lotado demais, toda vez que eu achar necessário, vou dividir o conteúdo em outros arquivos chamados Parte
//         static void Main(string[] args)
//         {

//         }

//         // INTERFACES são contratos
//         // Mas como assim contratos? Bem, são um conjunto de regras que devem ser seguidos quando algo for implementado
//         // No .NET, todas as interfaces começam com I por boa prática. Pois como a interface é o contrato de algo...
//         // A classe que vai ser criada a partir desse contrato vai ter o mesmo nome, só que sem o I
//         // Então, a interface é um contrato definindo tudo o que a classe Pagamento tem que ter.
//         // Ou seja, dentro da interface você vai definir o que todo pagamento deve ter para se criado, seja propriedades, metodos ou eventos
//         // A diferença entre Interface e classe, é que interface não contém implementação
//         // O CSharp permite implementar código dentro da interface, porém isso só é valido para pouquissimos cenários, que não são o caso aqui
//         public interface IPagamento
//         {
//             // Não se coloca os modificadores de acesso na interface. 
//             // Isso é papel da classe que vai seguir o contrato, e ela pode fazer o que bem entender nessa questão
//             // Podendo setar qualquer coisa do contrato com qualquer modificador de acesso que ela deseja
//             DateTime Vencimento { get; set; }

//             // Como na interface não existe implementação, não é necessário abrir e fechar chaves
//             void Pagar(double valor);
//         }

//         // E para fazer com que uma classe criada chame a interface para realizar esse contrato...
//         // Você tem de além de usar os dois pontos na frente do nome da classe, como uma herança
//         // Tem também que preencher a classe com todos os elementos do contrato, como visto abaixo
//         // As interfaces são um cenário perfeito para idear. Tipo, você primeira pensa o que deve ter uma classe e depois...
//         // Na implementação da classe você pensa como faz
//         public class Pagamento : IPagamento
//         {
//             public DateTime Vencimento { get; set; }

//             public void Pagar(double valor)
//             {

//             }
//         }
//     }
// }