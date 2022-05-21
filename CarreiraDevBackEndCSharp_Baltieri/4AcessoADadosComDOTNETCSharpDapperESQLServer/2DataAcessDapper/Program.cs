using System;
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
                UpdateCategory(connection);
                ListCategories(connection);
                // Caso você tenha ro
                CreateCategory(connection);
            }

        }

        // Vá no arquivo DataAcessDapperAntes... para ver como o código era antes de refatorar o código para ficar mais organizado
        // Lá eu explico todos os conceitos básicos sobre o que é o Dapper, como funciona um insert, leitura, etc
        // Inclusive recomendo primeiro rodar aquele código. Lembrando que você tem que ta com o Sqlserver rodando no Docker, e com o Azure Data conectado ao servidor sql, e claro, com o banco de dados criado

        static void ListCategories(SqlConnection connection)
        {
            var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");

            foreach (var item in categories)
            {
                Console.WriteLine($"{item.Id} - {item.Title}");
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

        // Aqui iremos aprender como se faz um update aqui pelo código C#
        // Esse modulo do curso foi finalizado. Agora iremos aprofundar mais sobre dapper no modulo de imersão
        // Que se encontra na pasta 3DataAcessDapperImmersion
        static void UpdateCategory(SqlConnection connection)
        {
            var updateQuery = "UPDATE [Category] SET [Title] = @Title WHERE [Id] = @Id";

            // Aqui também vai ser retornado apenas um int com o numero de rows afetadas
            var rows = connection.Execute(updateQuery, new
            {
                // Aqui se você passar só a string já vai funcionar. Essa Id eu peguei no banco, é da categoria Frontend
                // Se você passar um guid que não existe, ele vai rodar mesmo assim, porém, não vai atualizar nada pois o objeto não será encontrado
                Id = new Guid("af3407aa-11ae-4621-a2ef-2028b85507c4"),
                Title = "Frontend 2022"

            });

            Console.WriteLine($"{rows} - Registros atualizados");
        }
    }
}
