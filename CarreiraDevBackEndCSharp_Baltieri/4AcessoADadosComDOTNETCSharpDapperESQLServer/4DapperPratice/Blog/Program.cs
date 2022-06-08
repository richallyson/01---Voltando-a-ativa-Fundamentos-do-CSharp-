using System;
using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    // Iremos utilizar o Dapper.Contrib nesse mão na massa, que é uma paradinha que facilita muito a nossa vida
    // Vou evitar ficar explicando código aqui no mão na massa. No máximo digito uma linha bem resumida sobre algo, quando necessário
    // Afinal, se você já chegou até aqui, tem um bom conhecimento e basicamente tudo o que está sendo feito aqui já foi aplicado
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$";
        static void Main(string[] args)
        {
            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();
            //ReadUsers(connection);
            ReadUsersWithRoles(connection);
            //ReadRoles(connection);
            //ReadTags(connection);
            //CreateUser(connection);
            //UpdateUser(connection);
            //DeleteUser(connection);
            connection.Close();

        }

        public static void ReadUsers(SqlConnection connection)
        {
            // Instanciando um repositório genérico
            var repository = new Repository<User>(connection);
            var users = repository.Get();
            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
            }
        }

        public static void ReadUsersWithRoles(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var users = repository.GetUsersWithRole();
            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
                foreach (var roles in user.Roles)
                {
                    Console.WriteLine($" - {roles.Name}");
                }
            }
        }

        public static void CreateUser(SqlConnection connection)
        {
            var newUser = new User()
            {
                Name = "Teodhore Fonseca",
                Email = "fonseca@theo.com",
                PasswordHash = "hash",
                Bio = "I am Theodore, the Wrong",
                Image = "https://",
                Slug = "theo"
            };
            var repository = new Repository<User>(connection);
            repository.Create(newUser);
        }
        public static void UpdateUser(SqlConnection connection)
        {
            var updateUser = new User()
            {
                Id = 3,
                Name = "Sanchupança Fonseca",
                Email = "fonseca@theo.com",
                PasswordHash = "hash",
                Bio = "I am Theodore, the Wrong",
                Image = "https://",
                Slug = "theo"
            };
            var repository = new Repository<User>(connection);
            repository.Update(updateUser);
        }
        public static void DeleteUser(SqlConnection connection)
        {
            var user = connection.Get<User>(3);
            var repository = new Repository<User>(connection);
            repository.Delete(user);
            //repository.Delete(1);
        }
        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var roles = repository.Get();

            foreach (var role in roles)
                Console.WriteLine(role.Name);
        }
        public static void ReadTags(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var tags = repository.Get();

            foreach (var tag in tags)
                Console.WriteLine(tag.Name);
        }
    }
}
