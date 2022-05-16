using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.Repositories
{
    // Repositórios ao invés de ter uma implementação concreta, tem apenas a abstração
    // Serve para testar se certas coisas já não existem em um banco
    public interface IStudentRepository
    {
        bool DocumentExists(string document);
        bool EmailExists(string email);
        void CreateSubscription(Student student);
    }
}