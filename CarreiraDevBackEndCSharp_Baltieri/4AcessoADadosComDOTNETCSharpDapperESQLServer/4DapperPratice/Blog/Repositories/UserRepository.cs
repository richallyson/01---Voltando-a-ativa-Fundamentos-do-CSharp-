using System.Collections.Generic;
using System.Linq;
using Blog.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class UserRepository : Repository<User>
    {
        private readonly SqlConnection _connection;
        public UserRepository(SqlConnection connection) : base(connection)
        {
            _connection = connection;
        }

        public List<User> GetUsersWithRole()
        {
            // Mesmo código que usamos nas aulas. O Dapper Contrib não tem uma forma de fazer as acontecerem magicamente como faz com o CRUD
            var query = @"
            SELECT
                [User].*,
                [Role].*
            FROM
                [User]
                LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]";

            var users = new List<User>();

            var items = _connection.Query<User, Role, User>(
                query,
                (user, role) =>
                {
                    var usr = users.FirstOrDefault(x => x.Id == user.Id);
                    if (usr == null)
                    {
                        usr = user;
                        // Lembrando que é de grande importância sempre inicializar as listas de um modelo em seu construtor
                        // Se a lista de roles de user não for inicializada em user, a linha abaixo vai gerar um erro pra gente
                        // Pelo fato de que aqui nós estamos populando uma lista que já existe, e não criado uma
                        // Esse if tem de ser adicionado, pois caso um usuário n possua uma role, quando ele for printar pra gente esse usuário, ele vai dar erro
                        // Sendo assim, se a role do usuário for nula, ele vai só ignorar esse add, e não vai acontecer o erro
                        if (role != null)
                            usr.Roles.Add(role);
                        users.Add(usr);
                    }
                    else
                        usr.Roles.Add(role);

                    return user;
                }, splitOn: "Id");

            return users;
        }
    }
}