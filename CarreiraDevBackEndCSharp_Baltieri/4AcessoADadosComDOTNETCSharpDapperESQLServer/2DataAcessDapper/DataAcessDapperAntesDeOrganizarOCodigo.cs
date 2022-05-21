// using System;
// using Dapper;
// using DataAcessDapper.Models;
// using Microsoft.Data.SqlClient;

// namespace DataAcessDapper
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             // DAPPER
//             // O dapper é uma extensão ao Microsoft.Data.SqlClient, ele adiciona algumas funcionalidades a ele
//             // Toda a parte da conexão ele se vira melhor
//             // E a parte de comandos ele encapsula pra gente, podendo executar uma query e pedindo para ela ser trasformada em objeto para a gente
//             // Para instalar o Dapper, basta usar o dotnet add package Dapper
//             // A versão utilizada é a 2.0.90, como já disse antes é só adicionar o --version e a versão depois
//             // Outra coisa importante, é a criação da pasta Models. E dentro dela, a criação dos .cs, referente a cada tabela que a gente tem
//             // Ou seja, pra cada tabela que a gente tem no banco a gente vai ter uma classe no Models
//             // O Dapper ajuda no desafio de pegar a informação no SQLServer, que vem no formato Sequel Data Row, e transformar isso para um objeto
//             // O Dapper faz um Depara do SQL Server
//             const string connectionString = "Server=localhost,1433; Database=balta;User ID=sa;Password=1q2w3e4r@#$";

//             // INSERT
//             // Evite fazer tudo isso dentro do using, pois dado que a conexão com o servidor está aberta, deve se evitar de fazer muito processamento dentro do using
//             // E depois na hr que a gente abre a conexão a gente inclui a categória, e assim não ficamos ocupando a conexão com coisas a toa
//             var category = new Category();
//             category.Id = Guid.NewGuid();
//             category.Title = @"Acesso à dados com .NET, C#, Dapper e SQL Server";
//             category.Url = "acesso-a-dados-com-dotnet-csharp-dapper-e-sqlserver";
//             category.Summary = "Dapper para SQL Server";
//             category.Order = 8;
//             category.Description = "Categoria destinada ao uso de Dapper para SQL Server";
//             category.Featured = false;

//             // Existe um item muito importante, que temos que pegar, que se chama de SqlInjection
//             // SqlInjection é um ataque muito conhecido e muito executado, onde nele você passa parte de uma query...
//             // através de um insert, de um campo, de qualquer coisa que seja
//             // Imagine que você está executando essa inserção de categorias no seu site, e você lá tem um campo para alguém preencher o Url
//             // Então, o que impede que outra pessoa crie uma Url que execute uma outra query?
//             // Existem n formas de ataque, através de parametros, é muito comum e um dos primeiros ataques que as pessoas tentam
//             // E como evitar isso? O dapper já ajuda a gente nisso. Uma coisa que você nunca deve fazer para evitar isso, é concatenar string dentro da query
//             // Tipo, ao invés de passar o valor do campo como abaixo, usar um $ no começo da string e depois chamar um {category.Id}
//             // E isso se aplica a todo tipo de query
//             // E ao invés disso, iremos trabalhar com parametros. Lembrando que parametros no sql é defindo com um @ antes deles
//             // E é exatamente isso que foi feito abaixo dentro do insertSql
//             // Depois de ter criado os parametros, vamos para a nossa conexão inserir os parametros da categoria através desse insert
//             var insertSql = @"INSERT INTO
//                     [Category] 
//                 VALUES(
//                     @Id, 
//                     @Title, 
//                     @Url, 
//                     @Summary, 
//                     @Order, 
//                     @Description, 
//                     @Featured)";

//             using (var connection = new SqlConnection(connectionString))
//             {
//                 // Se o parametro do insert for criado com o mesmo nome do parametro do banco, você pode chamar o parametro do objeto direto dentro, que ele já vai entender
//                 // Caso contrário, você tem que chamar o parametro com o nome que você criou e passar o valor que você quer, tipo: abatace = category.Id (supondo que seu parametro Id se chama abacate na string do insert)
//                 // E é assim que conseguimos fazer a execução de uma query de insert, protegendo o nosso sistema de um SqlInjection
//                 // Diferente do connection.Query(), que vemos abaixo, o Execute() vai retornar para gente apenas um int, que é a quantidade de rows que foram afetadas
//                 // E caso queira executar um delete ou um update, também é usando o Execute()
//                 var rows = connection.Execute(insertSql, new
//                 {
//                     category.Id,
//                     category.Title,
//                     category.Url,
//                     category.Summary,
//                     category.Order,
//                     category.Description,
//                     category.Featured
//                 });

//                 Console.WriteLine($"{rows} - Linhas inseridas");

//                 // Fazendo o Depara
//                 // A função .Query é um IEnumerable de tipos dinamicos, sendo assim o Dapper permite que a gente já pode tipar qual o tipo de objeto..
//                 // ela vai retornar, no nosso caso, queremos uma lista de categorias
//                 // Apenas com essa linha de código, ele vai no banco, vai executar a conexão, vai executar a query pra gente...
//                 // e já vai trazer as categorias
//                 // Lembrando que o objeto criado tem que ter os mesmos campos da tabela do banco, inclusive com os mesmos nomes e tipos
//                 // Se por algum acaso você tenha que mudar para português ou para outro nome o parametro do objeto, use o alias referênciando isso
//                 // Você a invés de chamar o Id de Id no objeto chama de código, mas quando for dar o select, tem que chamar primeiro o [Id] e passar o nome do parametro que você botou como Alias
//                 //var categories = connection.Query<Category>("SELECT [Id] AS [Codigo], [Title] AS [Titulo] FROM [Category]");
//                 var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");

//                 // E o resto é o que a gente já viu nos cursos anteriores
//                 foreach (var item in categories)
//                 {
//                     Console.WriteLine($"{item.Id} - {item.Title}");
//                 }
//             }

//         }


//     }
// }
