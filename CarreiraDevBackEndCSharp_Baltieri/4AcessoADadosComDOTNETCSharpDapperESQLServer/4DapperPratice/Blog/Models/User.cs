using System.Collections.Generic;
using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    // Isso aqui abaixo se chama Notação. Uma Notação ou também chamado de Metadados...
    // são informações adicionais que a gente pode passar sobre uma classe
    // Existe uma Notação especifica do Dapper.Contrib que vai buscar em uma tabela especifica
    // Apesar da nossa classe se chamar User, com a Notação, iremos apontar para a tabela User do banco
    // Ou seja, caso seja feita uma Query ou Execute, ao invés ele vai diretamente na tabela User do banco
    // Mas e porquê fazer isso? Bem, por padrão o Dapper.Contrib tenta pluralizar a nossa entidade
    // Ou seja, se não fizermos a notação, ele vai no banco procurar por uma tabela chamada de Users
    // E essa tabela não existe nem no nosso banco, nem aqui no nosso código. Sendo assim, é necessário apontar para que tabela o Dapper.Contrib deve ser direcionada

    [Table("[User]")]
    public class User
    {
        public User()
        {
            Roles = new List<Role>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }
        // Necessário criar uma lista de roles para fazer uma ligação de um para muitos
        // Essa notação faz com que na hora de criar um usuário, ele não inclua os roles na hora de salvar
        // Se não adicionar essa notação, vai acontecer um erro na hora de compilar
        // E não faz sentido adicionar um role através de um usuário, pelo fato de que o role é uma entidade que tem seus parametros    
        [Write(false)]
        public List<Role> Roles { get; set; }
    }
}
