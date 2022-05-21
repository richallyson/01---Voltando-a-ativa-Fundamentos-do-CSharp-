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
            var getCategorySql = @"SELECT [Id] FROM [Category] WHERE [Id] = @Id";
            connection.Execute(getCategorySql, new
            {
                Id = id
            });
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
        }
    }
}
