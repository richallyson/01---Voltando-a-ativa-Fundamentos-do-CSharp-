using System;
using System.Collections;
using System.Data;
using Dapper;
using DataAcessDapper.Models;
using Microsoft.Data.SqlClient;

namespace DataAcessDapper
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=localhost,1433; Database=balta;User ID=sa;Password=1q2w3e4r@#$";

            using (var connection = new SqlConnection(connectionString))
            {
                //UpdateCategory(connection);                
                //CreateCategory(connection);
                //CreateManyCategories(connection);
                //DeleteManyCategories(connection, "2398a209-7a8a-4805-aea7-c6f4a8db6196", "dd0d0723-02cd-4c67-987d-b6fdf9f3456b");
                //UpdateManyCategories(connection, "ad914c09-b965-43fd-9b5d-a7f5c22e7dfe", "25d510c8-3108-44c2-86c5-924d9832aa8c");
                //ListCategories(connection);
                //GetCategory(connection, "25d510c8-3108-44c2-86c5-924d9832aa8c");
                //ExecuteProcedure(connection);
                //ExecuteReadProcedure(connection);
                //ExecuteScalar(connection);
                ReadView(connection);

            }
        }

        static void ListCategories(SqlConnection connection)
        {
            var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");

            foreach (var item in categories)
            {
                Console.WriteLine($"{item.Id} - {item.Title}");
            }
        }

        static void GetCategory(SqlConnection connection, string id)
        {
            var getCategorySql = connection.Query<Category>(@"SELECT [Id], [Title] FROM [Category] WHERE [Id] = @Id", new
            {
                Id = id
            });
            foreach (var item in getCategorySql)
            {
                if (id == item.Id.ToString())
                {
                    Console.WriteLine($"{item.Id} - {item.Title}");
                }
            }
        }

        static void CreateCategory(SqlConnection connection)
        {
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = @"Acesso à dados com .NET, C#, Dapper e SQL Server";
            category.Url = "acesso-a-dados-com-dotnet-csharp-dapper-e-sqlserver";
            category.Summary = "Dapper para SQL Server";
            category.Order = 8;
            category.Description = "Categoria destinada ao uso de Dapper para SQL Server";
            category.Featured = false;

            var insertSql = @"INSERT INTO
                    [Category] 
                VALUES(
                    @Id, 
                    @Title, 
                    @Url, 
                    @Summary, 
                    @Order, 
                    @Description, 
                    @Featured)";

            var rows = connection.Execute(insertSql, new
            {
                category.Id,
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            });

            Console.WriteLine($"{rows} - Linhas inseridas");
        }

        static void UpdateCategory(SqlConnection connection)
        {
            var updateQuery = "UPDATE [Category] SET [Title] = @Title WHERE [Id] = @Id";

            var rows = connection.Execute(updateQuery, new
            {
                Id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
                Title = "Frontend 2022"
            });

            Console.WriteLine($"{rows} - Registros atualizados");
        }

        static void DeleteCategory(SqlConnection connection, string id)
        {
            var deleteCategorySql = @"DELETE FROM [Category] WHERE [Id] = @Id";
            connection.Execute(deleteCategorySql, new
            {
                Id = id
            });

            Console.Write($"{deleteCategorySql} - Categoria foi excluida");
        }

        // O ExecuteMany vai realizar diversas ações, no nosso caso abaixo, vamos adicionar diversas categorias de uma vez
        static void CreateManyCategories(SqlConnection connection)
        {
            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = @"Acesso à dados com .NET, C#, Dapper e SQL Server";
            category.Url = "acesso-a-dados-com-dotnet-csharp-dapper-e-sqlserver";
            category.Summary = "Dapper para SQL Server";
            category.Order = 8;
            category.Description = "Categoria destinada ao uso de Dapper para SQL Server";
            category.Featured = false;

            var category2 = new Category();
            category2.Id = Guid.NewGuid();
            category2.Title = @"Amazon AWS";
            category2.Url = "amazon";
            category2.Summary = "Categoria destinada a serviços AWS";
            category2.Order = 9;
            category2.Description = "AWS Cloud";
            category2.Featured = true;

            // O insert permanece o mesmo
            var insertSql = @"INSERT INTO
                    [Category] 
                VALUES(
                    @Id, 
                    @Title, 
                    @Url, 
                    @Summary, 
                    @Order, 
                    @Description, 
                    @Featured)";

            // E no Execute, ao invés de criar apenas um objeto, iremos criar uma array de objetos, passando o que a gente quer
            // Ou seja, iremos passar um array de itens, e o Dapper é inteligente o suficiente a ponto de fazer essa inserção para a gente
            var rows = connection.Execute(insertSql, new[]{
                new
                {
                    category.Id,
                    category.Title,
                    category.Url,
                    category.Summary,
                    category.Order,
                    category.Description,
                    category.Featured
                },
                new
                {
                    category2.Id,
                    category2.Title,
                    category2.Url,
                    category2.Summary,
                    category2.Order,
                    category2.Description,
                    category2.Featured
                }
            });

            Console.WriteLine($"{rows} - Linhas inseridas");
        }

        static void DeleteManyCategories(SqlConnection connection, string id1, string id2)
        {
            var deleteCategoriesSql = @"DELETE FROM [Category] WHERE [Id] = @Id";
            var rows = connection.Execute(deleteCategoriesSql, new[]
            {
                new{Id = id1},
                new{Id = id2}
            });

            Console.WriteLine($"{rows} - Categorias foram excluida");
        }

        static void UpdateManyCategories(SqlConnection connection, string id1, string id2)
        {
            var updateQuery = "UPDATE [Category] SET [Title] = @Title WHERE [Id] = @Id";

            var rows = connection.Execute(updateQuery, new[]{
                new {Id = id1, Title = "Amazon AWS 2022"},
                new {Id = id2, Title = "Fullstack 2022"}
            });

            Console.WriteLine($"{rows} - Registros atualizados");
        }

        // Executando Stored Procedure
        static void ExecuteProcedure(SqlConnection connection)
        {
            // Para ficar mais coerente, sempre use os mesmos parametros criados no banco
            // No banco foi criada uma procedure que espera como parametro exatamente um @StudentId
            // Quando se coloca o CommandType visto na varievel rows, você não precisa declarar o comando como na variavel sql abaixo que foi comentada
            //var sql = "EXEC [spDeleteStudent] @StudentId";
            // Ao invés disso, pode apenas chamar o nome da procedure, sem botar o EXEC, e sem passar o paremetro. O parametro ele já vai mapear automaticamente
            var procedure = "[spDeleteStudent]";
            // Caso tivesse mais parametros, era só colocar após separando com uma virgula
            var pars = new { StudentId = "1e5bf176-36b2-4240-970c-4f5613f85056" };
            // Na Stored Procedure, você deve definir o command type como parametro quando for dar o execute, como fizemos no ADO.NET
            var rows = connection.Execute(procedure, pars, commandType: CommandType.StoredProcedure);

            if (rows <= 1)
            {
                Console.WriteLine($"{rows} - Linha afetada");
            }
            else
                Console.WriteLine($"{rows} - Linhas afetadas");

        }

        // Lendo uma Stored Procedure
        static void ExecuteReadProcedure(SqlConnection connection)
        {
            // É o mesmo processo do Execute, só que ao invés disso, usar um query
            var procedure = "[spGetCoursesByCategory]";
            var pars = new { CategoryId = "09ce0b7b-cfca-497b-92c0-3290ad9d5142" };
            var courses = connection.Query(procedure, pars, commandType: CommandType.StoredProcedure);

            // Lembrando que no ListCategories, a gente passou o tipo pro Query, que era um Category, que foi a classe criada em Models
            // Nesse caso aqui iremos usar mesmo o Query como um dynamic, que é o seu tipo básico
            // Mas muito cuidado, na hora de digitar as coisas que você quer imprimir, lembrar de sempre escrever as propriedades do curso como está no banco de dados
            // Não temos as propriedades de curso em tempo de compilação, apenas em tempo de execução. Ou seja, essa é uma tipagem anomina
            foreach (var item in courses)
            {
                Console.WriteLine($"{item.Title}");
            }

        }

        // O Execute Scalar permite que a gente execute algo e retorne um valor diferente de um int
        // Como vemos acima, temos um retorno de um inteiro mostrando quantas linhas foram afetadas pelas execuções
        // No nosso caso, a gente vai inserir um item no banco, e ter o retorno do Id do item gerado
        // Você pode ter qualquer coisa como retorno, contanto que exista dentro da tabela
        // Em vários cenários onde a gente usa um int ao invés do guid, a gente não tem controle da geração desse id
        // Ou em um cenário onde você deseja gerar o id direto do sqlserver
        // Ou mesmo em um cenário onde você vai pegar o ultimo id gerado, onde existe uma concorrência de pessoas inserindo dados no banco, você pode acabar pegando o id de outro item que não era o que você desejava
        // E como a gente precisa saber qual id que foi gerado, do qual é um id gerado no banco, a gente usa o ExecuteScalar nesse cenário

        static void ExecuteScalar(SqlConnection connection)
        {
            // Ao invés de passar o Id direto na categoria, vou passar no insert usando um NEWID()
            var category = new Category();
            category.Title = @"Acesso à dados com .NET, C#, Dapper e SQL Server";
            category.Url = "acesso-a-dados-com-dotnet-csharp-dapper-e-sqlserver";
            category.Summary = "Dapper para SQL Server";
            category.Order = 8;
            category.Description = "Categoria destinada ao uso de Dapper para SQL Server";
            category.Featured = false;

            // O OUTPUT inserted. [propriedade] retorna pra gente a saída da categoria inserida. Basicamente vai servir como um "SELECT" pra gente
            var insertSql = @"
                INSERT INTO
                    [Category] 
                OUTPUT inserted. [Id]
                VALUES(
                    NEWID(), 
                    @Title, 
                    @Url, 
                    @Summary, 
                    @Order, 
                    @Description, 
                    @Featured)";

            // É necessário tipar o ExecuteScalar com o retorno que a gente deseja
            var id = connection.ExecuteScalar<Guid>(insertSql, new
            {
                category.Title,
                category.Url,
                category.Summary,
                category.Order,
                category.Description,
                category.Featured
            });

            Console.WriteLine($"O ID do item inserido é: {id}");
        }

        // Executando uma View, que é básicamente um select nesse contexto, então á quase a mesma coisa que a função ListCategories, criada acima
        static void ReadView(SqlConnection connection)
        {
            var sql = "SELECT * FROM [vwCourses]";
            // Vamo deixar a query anonima, como a gente fez no ReadProcedure, então cuidado quando for chamar os campos
            var courses = connection.Query(sql);

            foreach (var item in courses)
            {
                Console.WriteLine($"{item.Id} - {item.Title}");
            }
        }

        // MAPEAMENTO
        // A partir daqui iremos entrar em alguns conteúdos mais avançados, especificamente o Mapeamento ou Mapping

        // Primeiro iremos começar com o relacionamento um para um. Lembra do INNER JOIN? Pois é. Vamos usar aqui
        // É necessário criar os modelos que serão usados aqui. Podemos até fazer de forma anomima, porém isso pode ficar confuso pro Dapper, e futuramente muitos erros
        static void OneToOne(SqlConnection connection)
        {
            // No mundo real a gente n usa o asterisco no SELECT kkkkk ELe ta aparecendo aqui só pra exemplo mesmo
            var sql = @"SELECT * FROM [CareerItem] INNER JOIN [Course] ON [CareerItem].[CourseId] = [Course].[Id]";
            var items = connection.Query(sql);

            foreach (var item in items)
            {

            }
        }
    }
}
