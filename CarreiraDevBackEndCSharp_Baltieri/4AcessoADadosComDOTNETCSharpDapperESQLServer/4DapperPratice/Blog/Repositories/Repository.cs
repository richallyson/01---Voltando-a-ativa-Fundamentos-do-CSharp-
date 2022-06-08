using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    // Bem, esse é um repositório generico. Mas pra quê ele serve?
    // Imagina que você tem 700 modelos, e imagina criar um repository para cada modelo desses? Uma trabalheira né?
    // O repositório genérico é justamente para eliminar esse gasto de tempo com um código que vai ser usado por todos os modelos
    // Lembrando que as funções de CRUD não podem ficar travadas para um modelo especifico, como o User
    // Ao invés disso, iremos trabalhar com os GENERICS. E como fazemos isso?
    // Basta dizer que a nossa classe é de um tipo genérico. Mas o que é um tipo genérico?
    // É basicamente uma classe indefinida, que será assemelhada a algo da sua escolha, como por exemplo o User...
    // e na hora de instanciar o repositorio (que acontece em tempo de compliação), ele vai ser assemelhado a aquele Modelo que você escolheu
    // E bem, para criar uma classe genérica, basta você botar o <T> depois do nome da classe
    // E porquê o T? Pois é uma convenção. Você pode usar qualquer letra, mas o T é basicamente a abreviação da palavra Type
    // Ou seja, essa classe GENERICA é do tipo T, onde T pode ser qualquer coisa
    // E diferente de como fizemos no UserRepository, onde passavamos o tipo especifico tanto nas funções do connection quando nos retornos de IEnumerable...
    // Aqui nós iremos passar esse tipo generico TModel. Pois, a gente já vai saber que aqui nós iremos passar um Modelo quando for feito a instância do repositorio
    // Já no caso do where T : class, a gente ta dizendo que nós só podemos receber classe pra esse tipo de genérico
    // Se deixarmos em aberto, qualquer coisa pode ser recebida, e isso pode causar problemas no futuro. Se fecharmos o escopo para receber apenas classes...
    // que no nosso caso, são os modelos, podemos ter um controle bem melhor sobre isso
    // Sendo assim, eu só vou aceitar a criação de Repository genéricos de algum tipo, onde esse tipo seja uma classe
    // E quando for feita a instância de repositório, você vai passar o tipo que deseja (ver isso em Program.cs)
    // var repository = new Repository<User>(connection); -- Quando vc for criar um repo, o código vai ficar assim. Passando entre os sinais o tipo que vc deseja
    // E uma coisa importante é que esse repo genérico serve apenas para o CRUD dos nossos modelos
    // Para itens mais especificos, como uma propriedade especifica (uma lista por exemplo) do modelo, se faz necessária a criação de um repo especifico
    public class Repository<TModel> where TModel : class
    {
        private readonly SqlConnection _connection;
        public Repository(SqlConnection connection)
        {
            _connection = connection;
        }

        // Como eu disse, ao invés de passarmos o tipo especifico, passamos o tipo GENERICO
        public IEnumerable<TModel> Get() => _connection.GetAll<TModel>();

        public TModel Get(int id) => _connection.Get<TModel>(id);

        public void Create(TModel model) => _connection.Insert<TModel>(model);

        public void Update(TModel model) => _connection.Update<TModel>(model);

        public void Delete(TModel model) => _connection.Delete<TModel>(model);

        public void Delete(int id)
        {
            var model = _connection.Get<TModel>(id);
            _connection.Delete<TModel>(model);
        }
    }
}