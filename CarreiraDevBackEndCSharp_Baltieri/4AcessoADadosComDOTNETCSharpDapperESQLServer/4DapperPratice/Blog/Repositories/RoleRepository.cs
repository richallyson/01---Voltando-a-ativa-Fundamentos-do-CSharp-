using System.Collections.Generic;
using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;


// Esse código está aqui apenas para demonstração de como as coisas funcionariam caso a gente não fosse usar o Generics
// Porém, sempre use os generics para fazer o crud para os seus modelos. Todos possuem sempre algo em comum
// Em caso de especificidade (como one to many e many to many), crie um repo especifico
// Esse código é obsoleto e n iremos usar em lugar nenhum, fica mesmo só pra estudo
// O Generics se encontra em Repository.cs, e caso haja a necessidade de criar um repo especifico, iremos fazer a herança dele para usar as funções que ele já possui
namespace Blog.Repositories
{
    public class RoleRepository
    {
        private readonly SqlConnection _connection;
        public RoleRepository(SqlConnection connection) => _connection = connection;

        public IEnumerable<Role> Get() => _connection.GetAll<Role>();

        public Role Get(int id) => _connection.Get<Role>(id);

        public void Create(Role role)
        {
            role.Id = 0;
            _connection.Insert<Role>(role);
        }

        public void Update(Role role)
        {
            if (role.Id != 0)
                _connection.Update<Role>(role);
        }

        public void Delete(Role role)
        {
            if (role.Id != 0)
                _connection.Delete<Role>(role);
        }

        public void Delete(int id)
        {
            if (id != 0)
                return;

            var role = _connection.Get<Role>(id);
            _connection.Delete<Role>(role);
        }
    }
}