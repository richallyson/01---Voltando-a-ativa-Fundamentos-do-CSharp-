namespace Balta.NotificationContext
{
    // Lembrando que o sealed impede que a classe seja extendida. Ou seja, usada por outras como herança
    // Isso foi aplicado pois eu não quero variações dessa classe, quero que por padrão ela seja sempre assim
    // E caso eu queria adicionar algo, venho aqui na classe mesmo e modifico direto nela
    public sealed class Notification
    {
        // Se tu criar um construtor vazio, tu pode instanciar essa classe como objeto sem precisar passar parametro nenhum
        public Notification()
        {

        }

        public Notification(string property, string message)
        {
            Property = property;
            Message = message;
        }

        public string Property { get; set; }
        public string Message { get; set; }
    }
}