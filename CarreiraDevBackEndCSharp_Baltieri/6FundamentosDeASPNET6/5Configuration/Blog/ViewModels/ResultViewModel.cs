namespace Blog.ViewModels
{
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
