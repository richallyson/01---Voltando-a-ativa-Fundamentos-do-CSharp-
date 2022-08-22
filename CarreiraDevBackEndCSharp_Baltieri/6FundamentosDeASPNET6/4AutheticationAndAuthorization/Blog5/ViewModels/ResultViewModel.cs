namespace Blog.ViewModels
{
    // = Padronização de retorno de requisição =
    // Sempre que a gente faz uma requisição na tela, a gente tem aquele processo de ir no banco através dos controllers e retornar o que se deseja pras views
    // Porém, esse retorno pra view é bem estranho quando acontece um erro, onde nele a gente tem o type, title, status e traceId
    // Seria bem mais interessante pra a gente trazer esse retorno da nossa API pra tela de forma mais organizada e bonitinha
    // Por exemplo, se eu dou um Get nas catégorias o retorno vai estar esperando um objeto. Se eu dou um Get, mas existe algum problema, ele vai esperar uma string falando do erro
    // Se por algum acaso o servidor estiver fora do ar, o retorno esperado vai ser um objeto de bad request com as coisas que foram faladas na segunda linha
    // E isso não é interessante para o front. Seria bem mais interessante se houvesse alguma padronização que sempre retornasse o mesmo tipo de dado, para que assim não haja mais trabalho na hora de receber os dados
    // Essa padronização vai fazer com que o front-end assimila isso de forma mais fácil
    // E é pra isso que existe o ResultViewModel, para apresentar essas informações de forma mais organizada
    // Todos os resultados da nossa API, toda requisição, vai retornar o ResultViewModel. Sendo assim a gente vai ta sempre padronizado
    // Então se der erro, nossa API vai retornar o ResultViewModel como o erro dentro dela
    // Se der um BadRequest, ele vai retornar um ResultViewModel com a lista de erros
    // Se der sucesso, vai ser retornado um ResultViewModel com os dados de sucesso da requisição
    // É uma parada bem simples, e que ajuda MUITO a vida do front-end 
    // A classe ResultViewModel deve ser genérica, pois assim ela vai se adaptar aos diversos tipos de retorno que a gente deseja
    // Pois a gente quer que ela retorne qualquer ViewModel da nossa API pra gente. Seja categoria, usuário, role, etc
    // Dentro dessa classe genérica, a gente possui duas propriedades. A T Data, que recebe justamente os dados que vão ser retornados pra tela
    // O tipo T no data, é pra quando for usado em algum cenário, ele se adapte aquele cenário. Sendo assim, se a gente usar o ResultViewModel em catégoria, seu tipo vai ser Category
    // Assim também como a propriedade Data, que trás o tipo da classe
    // E também temos uma lista de strings de erros, que vai conter os possiveis erros que possam vim a acontecer
    // A gente poderia fazer algo mais complexo pra essa lista de erros, poderiamos criar uma classe especifica pra essa lista, Porém, vai ficar pra outros cursos
    // Os dois itens estão privados pois a gente não quer possibilitar que haja a alteração desses itens depois de setados
    // E como a gente vai usar muita essa classe, em todos os métodos dos controllers, pelo menos duas vezes, uma quando der certo e outra quando der errado, a gente vai precisar de métodos construtores pra nos ajudar
    // E dentro dessa classe temos diversos métodos construtores que tratam todos os possiveis cenários dentro de uma requisição
    // Depois de ler tudo pode ir pra CategoryController

    public class ResultViewModel <T>
    {

        public ResultViewModel(T data, List<string> errors)  // Cenário que retorna os dados e uma possivel lista de erros, ou uma lista de erros vazia
        {
            Data = data;
            Errors = errors;
        }

        public ResultViewModel(T data) // Cenário onde apenas os dados são retornados sem erro nenhum
        {
            Data = data;
        }

        public ResultViewModel(List<string> errors) // Cenário onde diversos erros são retornados
        {
            Errors = errors;
        }

        public ResultViewModel(string error) // Cenário onde apenas um erro é retornado
        {
            Errors.Add(error);
        }

        public T Data { get; private set; }
        public List<string> Errors { get; set; } = new();
        //public List<string> Success { get; private set; }
    }
}
